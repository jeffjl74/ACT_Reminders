using System;
using System.Windows.Forms;

namespace ACT_Reminders
{
    public partial class GetPlayer : Form
    {
        public string PlayerName { get; set; }

        public GetPlayer()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            PlayerName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(textBoxName.Text);
        }
    }
}
