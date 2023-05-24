using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Data;
using System.ComponentModel;

[assembly: AssemblyTitle("Reminders Plugin")]
[assembly: AssemblyDescription("An ACT plugin to generate reminders when zoning, joining a raid, etc.")]
[assembly: AssemblyCompany("Mineeme")]
[assembly: AssemblyVersion("1.0.0.0")]

namespace ACT_Reminders
{
	public partial class Reminders : UserControl, IActPluginV1
	{


        Label lblStatus;    // The status label that appears in ACT's Plugin tab
		string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\Reminders.config.xml");
        PlayerList playerList = new PlayerList();
        XmlSerializer xmlSerializer;
        System.Timers.Timer charTimer = new System.Timers.Timer();
        WindowsFormsSynchronizationContext mUiContext = new WindowsFormsSynchronizationContext();
        AlertForm alertForm = null;
        Player activePlayer = null;
        AlertString sbAudio = new AlertString(AlertString.AlertType.AUDIO);
        AlertString sbVisual = new AlertString(AlertString.AlertType.VISUAL);
        ConcurrentQueue<string> audioQ = new ConcurrentQueue<string>();
        ConcurrentQueue<string> visualQ = new ConcurrentQueue<string>();
        public const string helpUrl = "https://github.com/jeffjl74/ACT_Reminders#act-reminders-plugin";


        public Reminders()
        {
            InitializeComponent();
        }

        #region Act Interaction
        
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;           // Hand the status label's reference to our local var
			pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
			this.Dock = DockStyle.Fill;             // Expand the UserControl to fill the tab's client space
            xmlSerializer = new XmlSerializer(typeof(PlayerList));
            LoadSettings();

            LoadReminders();
            playerControl1.Setup(playerList, flowLayoutPanel1, helpUrl);

            // check for a character change once a second
            charTimer.Interval = 1000;
            charTimer.Enabled = true;
            charTimer.AutoReset = true;
            charTimer.SynchronizingObject = this;
            charTimer.Elapsed += CharTimer_Elapsed;
            charTimer.Start();

            // Create some sort of parsing event handler.  After the "+=" hit TAB twice and the code will be generated for you.
            ActGlobals.oFormActMain.OnLogLineRead += OFormActMain_OnLogLineRead;

            if (ActGlobals.oFormActMain.GetAutomaticUpdatesAllowed())
            {
                // If ACT is set to automatically check for updates, check for updates to the plugin
                // If we don't put this on a separate thread, web latency will delay the plugin init phase
                new Thread(new ThreadStart(oFormActMain_UpdateCheckClicked)).Start();
            }

            lblStatus.Text = "Plugin Started";
		}

        public void DeInitPlugin()
        {
            // Unsubscribe from any events you listen to when exiting!
            ActGlobals.oFormActMain.OnLogLineRead -= OFormActMain_OnLogLineRead;

            SaveSettings();
            lblStatus.Text = "Plugin Exited";
        }

        private void OFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (!isImport)
            {
                if (activePlayer != null)
                {
                    sbAudio.Clear();
                    sbVisual.Clear();

                    foreach (ReminderType rt in playerList.Reminders)
                    {
                        if(rt.Use)
                        {
                            if(rt.Trigger.Match(logInfo.logLine).Success)
                            {
                                bool triggered = false;
                                AlertData ad = activePlayer[rt.ID];
                                if(ad != null)
                                {
                                    if (ad.AudioAlert && (DateTime.Now - rt.Started).TotalSeconds > rt.QuietTime)
                                    {
                                        sbAudio.Append(ad.Text, ad.AudioDelay);
                                        triggered = true;
                                    }
                                    if (ad.VisualAlert && (DateTime.Now - rt.Started).TotalSeconds > rt.QuietTime)
                                    {
                                        sbVisual.Append(ad.Text, ad.VisualDelay);
                                        triggered = true;
                                    }
                                }
                                if(triggered)
                                    rt.Started = DateTime.Now;
                            }
                        }
                    }

                    if(!sbAudio.IsEmpty() || !sbVisual.IsEmpty())
                        RunAlerts(sbAudio, sbVisual);
                }
            }
        }

        private void CharTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (playerList.Players == null)
                return;

            // look for player change
            if (activePlayer != null)
            {
                if (activePlayer.Name != ActGlobals.charName)
                    activePlayer = playerList[ActGlobals.charName];
            }
            else
                activePlayer = playerList[ActGlobals.charName];
        }

        void oFormActMain_UpdateCheckClicked()
        {
            int pluginId = 92;

            try
            {
                Version localVersion = this.GetType().Assembly.GetName().Version;
                // Strip any leading 'v' from the string before passing to the Version constructor
                Version remoteVersion = new Version(ActGlobals.oFormActMain.PluginGetRemoteVersion(pluginId).TrimStart(new char[] { 'v' }));
                if (remoteVersion > localVersion)
                {
                    Rectangle screen = Screen.GetWorkingArea(ActGlobals.oFormActMain);
                    DialogResult result = SimpleMessageBox.Show(new Point(screen.Width / 2 - 100, screen.Height / 2 - 100),
                          @"There is an update for the Reminders plugin."
                        + @"\line Update it now?"
                        + @"\line (If there is an update to ACT"
                        + @"\line you should click No and update ACT first.)"
                        + @"\line\line Release notes at project website:"
                        + @"{\line\ql " + helpUrl + "}"
                        , "Reminders New Version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        FileInfo updatedFile = ActGlobals.oFormActMain.PluginDownload(pluginId);
                        ActPluginData pluginData = ActGlobals.oFormActMain.PluginGetSelfData(this);
                        pluginData.pluginFile.Delete();
                        updatedFile.MoveTo(pluginData.pluginFile.FullName);
                        Application.DoEvents();
                        ThreadInvokes.CheckboxSetChecked(ActGlobals.oFormActMain, pluginData.cbEnabled, false);
                        Application.DoEvents();
                        ThreadInvokes.CheckboxSetChecked(ActGlobals.oFormActMain, pluginData.cbEnabled, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(ex, "Reminders Plugin Update Download failed");
            }
        }


        #endregion ACT Interaction

        #region Data Management

        private void LoadReminders()
        {
            CompileReminders();
            bindingSource1.DataSource = playerList.Reminders;
            dataGridView1.DataSource = bindingSource1;
        }

        private void CompileReminders()
        {
            foreach(ReminderType rt in playerList.Reminders)
            {
                rt.Trigger = new Regex(rt.Regexp, RegexOptions.Compiled);
            }
        }

        void LoadSettings()
        {
            if (File.Exists(settingsFile))
            {
                try
                {
                    using (FileStream fs = new FileStream(settingsFile, FileMode.Open))
                    {
                        playerList = (PlayerList)xmlSerializer.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error loading settings: " + ex.Message;
                }
            }
        }

        void SaveSettings()
        {
            using (TextWriter writer = new StreamWriter(settingsFile))
            {
                xmlSerializer.Serialize(writer, playerList);
                writer.Close();
            }
        }

        private void bindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {
            // If added a new reminder, it's ID will be zero.
            // Fix it.
            foreach (ReminderType rt in playerList.Reminders)
            {
                if (rt.ID == 0)
                {
                    rt.ID = playerList.NextReminderId;
                    break;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["colUse"].Index)
            {
                Player p = playerControl1.GetDisplayedPlayer();
                if (p != null && dataGridView1.Rows[e.RowIndex].Cells["colID"].Value != null)
                {
                    int id = (int)dataGridView1.Rows[e.RowIndex].Cells["colID"].Value;
                    if ((bool)dataGridView1.Rows[e.RowIndex].Cells["colUse"].Value == true)
                    {
                        if (p.Alerts.FirstOrDefault(x => x.ReminderId == id) == null)
                        {
                            // add it to this players alerts
                            AlertData ad = new AlertData { ReminderId = id, VisualAlert = true };
                            p.Alerts.Add(ad);

                            // add the control to the UI
                            string title = dataGridView1.Rows[e.RowIndex].Cells["colTitle"].Value.ToString();
                            ReminderControl rc = new ReminderControl(ad, title);
                            flowLayoutPanel1.Controls.Add(rc);
                        }
                    }
                    else
                    {
                        // remove the alert from this player
                        try
                        {
                            p.Alerts.Remove(p.Alerts.First(x => x.ReminderId == id));

                            flowLayoutPanel1.SuspendLayout();
                            if (flowLayoutPanel1.Controls.Count > 0)
                            {
                                for (int i = (flowLayoutPanel1.Controls.Count - 1); i >= 0; i--)
                                {
                                    ReminderControl rc = flowLayoutPanel1.Controls[i] as ReminderControl;
                                    if (rc != null)
                                    {
                                        if (rc.ID == id)
                                        {
                                            flowLayoutPanel1.Controls.Remove(rc);
                                            rc.Dispose();
                                            break;
                                        }
                                    }
                                }
                            }
                            flowLayoutPanel1.ResumeLayout();
                        }
                        catch { } // ignore failure
                    }
                }
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["colUse"].Index)
            {
                dataGridView1.EndEdit();
            }
        }

        private void tabControl1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && playerList.Players.Count == 0)
            {
                if (SimpleMessageBox.Show(ActGlobals.oFormActMain, 
                    "Setup some default reminders for ACT's current player?", 
                    "Reminders - Initial Setup", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    playerControl1.AddOrFindPlayer(ActGlobals.charName);
                    Player player = playerList.Players[0];

                    // set some EQ2 defaults
                    playerList.Reminders.Add(new ReminderType { ID = playerList.NextReminderId, Title = "AFK", QuietTime = 0, Regexp = "You are now afk" });
                    playerList.Reminders.Add(new ReminderType { ID = playerList.NextReminderId, Title = "Off AFK", QuietTime = 0, Regexp = "You are no longer afk" });
                    playerList.Reminders.Add(new ReminderType { ID = playerList.NextReminderId, Title = "Enter Instance", QuietTime = 0, Regexp = "You have entered .*]" });
                    playerList.Reminders.Add(new ReminderType { ID = playerList.NextReminderId, Title = "Join Raid", QuietTime = 1800, Regexp = "You have a new voice channel available:[^<]+<Raid>" });
                    playerList.Reminders.Add(new ReminderType { ID = playerList.NextReminderId, Title = "Join Group", QuietTime = 60, Regexp = "You have a new voice channel available:[^<]+<Group>" });
                    playerList.Reminders.Add(new ReminderType { ID = playerList.NextReminderId, Title = "AA Changed", QuietTime = 5, Regexp = "Your prefix title, .* has been removed" });
                    playerList.Reminders.Add(new ReminderType { ID = playerList.NextReminderId, Title = "Revived", QuietTime = 0, Regexp = "You regain consciousness" });

                    // select some default reminders
                    int id = 3; //enter instance
                    playerList.Reminders.First(x => x.ID == id).Use = true;
                    player.Alerts.Add(new AlertData { ReminderId = id, VisualAlert = true, Text = "Field Medic\nFamiliar" });

                    id = 4; // join raid
                    playerList.Reminders.First(x => x.ID == id).Use = true;
                    player.Alerts.Add(new AlertData { ReminderId = id, VisualAlert = true, Text = "Price Paid\nPainlink\nTemp adorns\nHeartbound\nMerc Buff" });

                    playerControl1.RedrawPlayerControls();
                }
                else
                {
                    SimpleMessageBox.ShowDialog(ActGlobals.oFormActMain,
                      @"{\ql Reminders requires at least one Player on the {\b Player} tab "
                    + @"and at least one Reminder on the {\b Reminders} tab. \par\par}"
                    + @"{\*\pn\pnlvlblt\pnf1\pnindent0\ql{\pntxtb\'B7}}On the {\b Player} tab, use one of the leftmost two buttons in the Players box to add either the current ACT player or the name typed in the edit box, respectively.\par"
                    + @"{\pntext\f1\'B7\tab}On the {\b Reminders} tab, enter a reminder by typing an (arbitrary) Title and the regular expression that matches the desired log line.\par"
                    + @"{\pntext\f1\'B7\tab}Check the {\b Use} checkbox to use a reminder for the player currently selected on the {\b Player} tab.\par"
                    + @"{\pntext\f1\'B7\tab}The Player tab allows editing of the details of each reminder whose {\b Use} checkbox is checked. Enter the text in the texbox to use for the audio and visual alerts.\par"
                    + @"\pard\par This window may be left open while performing those steps.\par"
                    + @"{\par Further info at " + helpUrl + " }"
                    , "Reminders - Initial Setup");
                }
            }

        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            bool ok = true;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if(!row.IsNewRow)
            {
                if (row.Cells["colRegexp"].Value != null)
                {
                    DataGridViewCell reCell = row.Cells["colRegexp"];
                    string re = reCell.Value.ToString();
                    if (!string.IsNullOrEmpty(re))
                    {
                        try
                        {
                            Regex retest = new Regex(re);
                            reCell.ErrorText = string.Empty;
                            CompileReminders();
                        }
                        catch (Exception ex)
                        {
                            reCell.ErrorText = ex.Message;
                            ok = false;
                        }
                    }
                }
            }
            e.Cancel = !ok;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                int id = (int)e.Row.Cells["colID"].Value;

                foreach (Player p in playerList.Players)
                {
                    AlertData data = p.Alerts.FirstOrDefault(x => x.ReminderId == id);
                    if (data != null)
                    {
                        p.Alerts.Remove(data);
                    }
                }
                playerControl1.RedrawPlayerControls();
            }
        }

        #endregion Data Management

        #region Alerts

        private void RunAlerts(AlertString audioData, AlertString visualData)
        {
            if (!audioData.IsEmpty() && activePlayer != null)
            {
                audioQ.Enqueue(audioData.ToString());
                Task.Run(() =>
                {
                    if (audioData.Delay > 0)
                        Thread.Sleep(audioData.Delay * 1000);
                    mUiContext.Post(UiAudio, null);
                });
            }
            if (!visualData.IsEmpty() && activePlayer != null)
            {
                visualQ.Enqueue(visualData.ToString());
                Task.Run(() =>
                {
                    if (visualData.Delay > 0)
                        Thread.Sleep(visualData.Delay * 1000);
                    mUiContext.Post(UiPopup, null);
                });
            }
        }

        void UiAudio(object o)
        {
            string say;
            if (audioQ.TryDequeue(out say))
            {
                ActGlobals.oFormActMain.TTS(say);
            }
        }

        void UiPopup(object o)
        {
            string popAlerts;
            if (visualQ.TryDequeue(out popAlerts))
            {
                if (alertForm != null)
                {
                    List<string> lines = alertForm.Alerts;
                    List<string> newLines = popAlerts.Split('\n').ToList();
                    foreach(string line in newLines)
                    {
                        if(!lines.Contains(line))
                            lines.Add(line);
                    }
                    alertForm.Close();
                    alertForm = null;
                    alertForm = new AlertForm();
                    alertForm.Alerts = lines;
                }
                else
                {
                    List<string> lines = popAlerts.Split('\n').ToList();
                    alertForm = new AlertForm();
                    alertForm.Alerts = lines;
                }
                if (activePlayer != null)
                {
                    alertForm.Blink = activePlayer.Blink;
                    if (activePlayer.AlertLocX == 0 && activePlayer.AlertLocY == 0)
                    {
                        // if it has never been positioned, put it center screen
                        Size size = Screen.PrimaryScreen.WorkingArea.Size;
                        activePlayer.AlertLocX = size.Width / 2 - alertForm.Width / 2;
                        activePlayer.AlertLocY = size.Height / 2 - alertForm.Height / 2;
                    }
                    if (activePlayer.AlertWidth != 0)
                        alertForm.Width = activePlayer.AlertWidth;
                    alertForm.Location = new Point(activePlayer.AlertLocX, activePlayer.AlertLocY);
                }
                else
                {
                    Size size = Screen.PrimaryScreen.WorkingArea.Size;
                    int X = size.Width / 2 - alertForm.Width / 2;
                    int Y = size.Height / 2 - alertForm.Height / 2;
                    alertForm.Location = new Point(X, Y);
                }
                alertForm.FormMoved += AlertForm_FormMoved;
                alertForm.Show();
            }
        }

        private void AlertForm_FormMoved(object sender, EventArgs e)
        {
            if (activePlayer != null)
            {
                activePlayer.AlertLocX = alertForm.Location.X;
                activePlayer.AlertLocY = alertForm.Location.Y;
                activePlayer.AlertWidth = alertForm.Width;
            }
        }

        #endregion Alerts

    }
}
