using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT_Reminders
{
    public partial class AlertForm : Form
    {
        public List<string> Alerts = new List<string>();
        public int labelHeight = 17;
        public event EventHandler FormMoved; //callback
        public bool Blink { get; set; }

        System.Timers.Timer timer = new System.Timers.Timer();

        // form drag
        bool mouseDown;
        Point lastLocation;

        class AlertLabel : Label
        {
            public AlertLabel(AlertForm form, int posn, string text)
            {
                this.Text = text;
                this.AutoSize = true;
                this.Location = new Point(5, posn * form.labelHeight);
                this.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
                this.MouseDown += form.AlertForm_MouseDown;
                this.MouseUp += form.AlertForm_MouseUp;
                this.MouseMove += form.AlertForm_MouseMove;
            }
        }

        public AlertForm()
        {
            InitializeComponent();
            Alerts.Clear();
        }

        // do not take the focus when the form is shown
        // but we do want topmost
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        private const int WS_EX_TOPMOST = 0x00000008;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_TOPMOST;
                return createParams;
            }
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {
            if (Alerts.Count > 0)
            {
                for (int i = 0; i < Alerts.Count; i++)
                {
                    AlertLabel alertLabel = new AlertLabel(this, i, Alerts[i]);
                    this.Controls.Add(alertLabel);
                    // Label height is adjusted after the control is added to the form.
                    // This works b/c the i==0 label constructor multiplies by zero so "labelHeight" is irrelevant for the top control constructor.
                    labelHeight = alertLabel.Height;
                }
                this.Height = (Alerts.Count * labelHeight) + (this.Height - this.ClientRectangle.Height);
                //AnimateWindow(this.Handle, 1000, VertPositive);

                if (Blink)
                {
                    timer.SynchronizingObject = this;
                    timer.Interval = 1000;
                    timer.AutoReset = true;
                    timer.Enabled = true;
                    timer.Elapsed += Timer_Elapsed;
                    timer.Start();
                }
            }
            if(this.Height < buttonClose.Height)
            {
                this.Height = buttonClose.Height + (this.Height - this.ClientRectangle.Height);
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.BackColor != Color.Green)
            {
                this.BackColor = Color.Green;
                this.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            Alerts.Clear();
        }

        private void AlertForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        private void AlertForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void AlertForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            OnMoveDone(e);
        }

        private void AlertForm_Shown(object sender, EventArgs e)
        {
            
        }

        protected void OnMoveDone(EventArgs e)
        {
            if(FormMoved != null)
            {
                FormMoved.Invoke(this, e);
            }
        }

        private void AlertForm_ResizeEnd(object sender, EventArgs e)
        {
            OnMoveDone(e);
        }
    }
}
