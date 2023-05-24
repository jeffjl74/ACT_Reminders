namespace ACT_Reminders
{
    partial class PlayerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerControl));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxBlink = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonACTplayer = new System.Windows.Forms.ToolStripButton();
            this.buttonAddPlayer = new System.Windows.Forms.ToolStripButton();
            this.buttonCopyPlayer = new System.Windows.Forms.ToolStripButton();
            this.buttonDeletePlayer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonHelp = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPlayer = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxBlink);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxPlayer);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 120);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Players";
            // 
            // checkBoxBlink
            // 
            this.checkBoxBlink.AutoSize = true;
            this.checkBoxBlink.Checked = true;
            this.checkBoxBlink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBlink.Location = new System.Drawing.Point(5, 78);
            this.checkBoxBlink.Name = "checkBoxBlink";
            this.checkBoxBlink.Size = new System.Drawing.Size(107, 17);
            this.checkBoxBlink.TabIndex = 12;
            this.checkBoxBlink.Text = "Blink visual alerts";
            this.checkBoxBlink.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonACTplayer,
            this.buttonAddPlayer,
            this.buttonCopyPlayer,
            this.buttonDeletePlayer,
            this.toolStripSeparator1,
            this.buttonHelp});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(204, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonACTplayer
            // 
            this.buttonACTplayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonACTplayer.Image = ((System.Drawing.Image)(resources.GetObject("buttonACTplayer.Image")));
            this.buttonACTplayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonACTplayer.Name = "buttonACTplayer";
            this.buttonACTplayer.Size = new System.Drawing.Size(23, 22);
            this.buttonACTplayer.Text = "toolStripButton4";
            this.buttonACTplayer.ToolTipText = "Copy the player name from ACT";
            this.buttonACTplayer.Click += new System.EventHandler(this.buttonACTplayer_Click);
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAddPlayer.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddPlayer.Image")));
            this.buttonAddPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddPlayer.Name = "buttonAddPlayer";
            this.buttonAddPlayer.Size = new System.Drawing.Size(23, 22);
            this.buttonAddPlayer.Text = "Add Player";
            this.buttonAddPlayer.ToolTipText = "Add a new player named below";
            this.buttonAddPlayer.Click += new System.EventHandler(this.buttonAddPlayer_Click);
            // 
            // buttonCopyPlayer
            // 
            this.buttonCopyPlayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCopyPlayer.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyPlayer.Image")));
            this.buttonCopyPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCopyPlayer.Name = "buttonCopyPlayer";
            this.buttonCopyPlayer.Size = new System.Drawing.Size(23, 22);
            this.buttonCopyPlayer.Text = "Copy Player";
            this.buttonCopyPlayer.ToolTipText = "Copy shown settings to a new or existing other player";
            this.buttonCopyPlayer.Click += new System.EventHandler(this.buttonCopyPlayer_Click);
            // 
            // buttonDeletePlayer
            // 
            this.buttonDeletePlayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDeletePlayer.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeletePlayer.Image")));
            this.buttonDeletePlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDeletePlayer.Name = "buttonDeletePlayer";
            this.buttonDeletePlayer.Size = new System.Drawing.Size(23, 22);
            this.buttonDeletePlayer.Text = "Delete Player";
            this.buttonDeletePlayer.ToolTipText = "Delete the \'Player\' selected below";
            this.buttonDeletePlayer.Click += new System.EventHandler(this.buttonDeletePlayer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonHelp
            // 
            this.buttonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonHelp.Image = ((System.Drawing.Image)(resources.GetObject("buttonHelp.Image")));
            this.buttonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(23, 22);
            this.buttonHelp.Text = "Help";
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Player";
            // 
            // comboBoxPlayer
            // 
            this.comboBoxPlayer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPlayer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPlayer.FormattingEnabled = true;
            this.comboBoxPlayer.Location = new System.Drawing.Point(47, 43);
            this.comboBoxPlayer.Name = "comboBoxPlayer";
            this.comboBoxPlayer.Size = new System.Drawing.Size(150, 21);
            this.comboBoxPlayer.TabIndex = 8;
            this.comboBoxPlayer.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayer_SelectedIndexChanged);
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(218, 127);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxBlink;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonACTplayer;
        private System.Windows.Forms.ToolStripButton buttonAddPlayer;
        private System.Windows.Forms.ToolStripButton buttonCopyPlayer;
        private System.Windows.Forms.ToolStripButton buttonDeletePlayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonHelp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxPlayer;
    }
}
