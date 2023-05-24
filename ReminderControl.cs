using System;
using System.Windows.Forms;

namespace ACT_Reminders
{
    public partial class ReminderControl : UserControl
    {
        AlertData _alert = null;
        string _title = string.Empty;
        bool loading = true;

        public bool AudioChecked { get { return checkBoxAudio.Checked; } set { checkBoxAudio.Checked = value; } }
        public bool VideoChecked { get { return checkBoxVisual.Checked; } set { checkBoxVisual.Checked = value; } }
        public int ID { get { return _alert.ReminderId; } }

        public ReminderControl()
        {
            InitializeComponent();
        }
        public ReminderControl(AlertData alert, string title)
        {
            InitializeComponent();
            _alert = alert;
            _title = title;
        }

        private void ReminderControl_Load(object sender, EventArgs e)
        {
            if(_alert != null)
            {
                groupBox1.Text = _title;

                checkBoxAudio.Checked = _alert.AudioAlert;
                checkBoxVisual.Checked = _alert.VisualAlert;
                numericUpDownAudio.Value = _alert.AudioDelay;
                numericUpDownVisual.Value = _alert.VisualDelay;
                rtbAlerts.Text = _alert.Text;
            }
            loading = false;
        }

        private void rtbAlerts_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
                _alert.Text = rtbAlerts.Text;
        }

        private void checkBoxAudio_CheckedChanged(object sender, EventArgs e)
        {
            if(!loading)
                _alert.AudioAlert = checkBoxAudio.Checked;
        }

        private void numericUpDownAudio_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
                _alert.AudioDelay = (int)numericUpDownAudio.Value;
        }

        private void checkBoxVisual_CheckedChanged(object sender, EventArgs e)
        {
            if(!loading)
                _alert.VisualAlert = checkBoxVisual.Checked;
        }

        private void numericUpDownVisual_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
                _alert.VisualDelay = (int)numericUpDownVisual.Value;
        }
    }
}
