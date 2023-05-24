using Advanced_Combat_Tracker;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ACT_Reminders
{
    public partial class PlayerControl : UserControl
    {
        PlayerList _playerList;
        FlowLayoutPanel _flowLayoutPanel;
        Player _currentPlayer;
        string _helpUrl;

        public PlayerControl()
        {
            InitializeComponent();
        }

        public void Setup(PlayerList playerList, FlowLayoutPanel flp, string helpUrl)
        {
            _playerList = playerList;
            _flowLayoutPanel = flp;
            _helpUrl = helpUrl;
            LoadCombobox();
            Player p = GetDisplayedPlayer();
            if (p != null)
            {
                foreach (AlertData ad in p.Alerts)
                {
                    ReminderType rt = playerList.Reminders.FirstOrDefault(x => x.ID == ad.ReminderId);
                    if (rt != null)
                        rt.Use = true;
                }
            }
        }

        public Player GetDisplayedPlayer()
        {
            Player player = null;
            if (_playerList != null)
            {
                if (_playerList.Players.Count > 0 && comboBoxPlayer.SelectedIndex >= 0)
                {
                    return _playerList[comboBoxPlayer.Text];
                }
            }
            return player;
        }

        public Player AddOrFindPlayer(string name)
        {
            if (!string.IsNullOrEmpty(name)
                && _playerList != null
                && _flowLayoutPanel != null)
            {
                Player player = new Player();
                player.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
                if (!_playerList.Players.Contains(player))
                {
                    int index = comboBoxPlayer.Items.Add(player.Name);
                    _playerList.Players.Add(player);
                    comboBoxPlayer.SelectedIndex = index;
                    return player;
                }
                return _playerList[name];
            }
            else
                return null;
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxPlayer.Text)
                && _playerList != null
                && _flowLayoutPanel != null)
            {
                Player player = new Player();
                player.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(comboBoxPlayer.Text);
                if (!_playerList.Players.Contains(player))
                {
                    int index = comboBoxPlayer.Items.Add(player.Name);
                    _playerList.Players.Add(player);
                    comboBoxPlayer.SelectedIndex = index;
                }
            }
        }

        private void ClearFLP()
        {
            _flowLayoutPanel.SuspendLayout();
            if (_flowLayoutPanel.Controls.Count > 0)
            {
                for (int i = (_flowLayoutPanel.Controls.Count - 1); i >= 0; i--)
                {
                    ReminderControl rc = _flowLayoutPanel.Controls[i] as ReminderControl;
                    if (rc != null)
                    {
                        _flowLayoutPanel.Controls.Remove(rc);
                        rc.Dispose();
                    }
                }
            }
            _flowLayoutPanel.ResumeLayout();
        }

        private void buttonCopyPlayer_Click(object sender, EventArgs e)
        {
            // copy displayed settings to another player
            GetPlayer getPlayer = new GetPlayer();
            getPlayer.Text = "Destination Player Name";
            if (getPlayer.ShowDialog() == DialogResult.OK)
            {
                if (!comboBoxPlayer.Items.Contains(getPlayer.PlayerName))
                {
                    // new player
                    Player np = new Player();
                    np.Name = getPlayer.PlayerName;
                    Player dp = GetDisplayedPlayer();
                    np.Copy(dp);
                    _playerList.Players.Add(np);
                    int index = comboBoxPlayer.Items.Add(np.Name);
                    comboBoxPlayer.SelectedIndex = index;
                }
                else
                {
                    // copy displayed settings to existing player
                    Player existing = _playerList[getPlayer.PlayerName];
                    Player dp = GetDisplayedPlayer();
                    if (existing != null && dp != null)
                    {
                        existing.Copy(dp);
                        for (int i = 0; i < comboBoxPlayer.Items.Count; i++)
                        {
                            if (comboBoxPlayer.Items[i].ToString() == getPlayer.PlayerName)
                            {
                                comboBoxPlayer.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }

        }

        private void buttonACTplayer_Click(object sender, EventArgs e)
        {
            if (!comboBoxPlayer.Items.Contains(ActGlobals.charName))
            {
                int index = comboBoxPlayer.Items.Add(ActGlobals.charName);
                Player p = new Player();
                p.Name = ActGlobals.charName;
                _playerList.Players.Add(p);
                comboBoxPlayer.SelectedIndex = index;
            }
            else
            {
                for (int i = 0; i < comboBoxPlayer.Items.Count; i++)
                {
                    if (comboBoxPlayer.Items[i].ToString() == ActGlobals.charName)
                    {
                        comboBoxPlayer.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void buttonDeletePlayer_Click(object sender, EventArgs e)
        {
            if (_playerList != null)
            {
                int index = _playerList.Players.FindIndex(p => p.Name == comboBoxPlayer.Text);
                if (index >= 0)
                {
                    if (_currentPlayer == _playerList.Players[index])
                        _currentPlayer = null;
                    _playerList.Players.RemoveAt(index);
                    LoadCombobox();
                }
            }
        }

        private void LoadCombobox()
        {
            comboBoxPlayer.Items.Clear();
            if (_playerList != null)
            {
                if (_playerList.Players.Count > 0)
                {
                    foreach (Player player in _playerList.Players)
                    {
                        comboBoxPlayer.Items.Add(player.Name);
                    }
                    comboBoxPlayer.SelectedIndex = 0;
                }
            }
        }

        private void comboBoxPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            RedrawPlayerControls();
        }

        public void RedrawPlayerControls()
        {
            ClearFLP();
            foreach (ReminderType rt in _playerList.Reminders)
                rt.Use = false;
            if (comboBoxPlayer.SelectedIndex >= 0)
                LoadPlayerControls();
            else
            {
                // non-tracked player
                _currentPlayer = null;
            }
        }

        private void LoadPlayerControls()
        {
            _currentPlayer = GetDisplayedPlayer();
            if (_currentPlayer != null)
            {
                foreach (AlertData ad in _currentPlayer.Alerts)
                {
                    string title = "";
                    ReminderType rt = _playerList.Reminders.FirstOrDefault(x => x.ID == ad.ReminderId);
                    if (rt != null)
                    {
                        title = rt.Title;
                        rt.Use = true;
                    }
                    ReminderControl rc = new ReminderControl(ad, title);
                    _flowLayoutPanel.Controls.Add(rc);
                }
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_helpUrl);
        }
    }
}
