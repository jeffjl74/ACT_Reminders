namespace ACT_Reminders
{
    partial class ReminderControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbAlerts = new System.Windows.Forms.RichTextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.numericUpDownVisual = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAudio = new System.Windows.Forms.NumericUpDown();
            this.checkBoxVisual = new System.Windows.Forms.CheckBox();
            this.checkBoxAudio = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVisual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAudio)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbAlerts);
            this.groupBox1.Controls.Add(this.panel9);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 120);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Title";
            // 
            // rtbAlerts
            // 
            this.rtbAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAlerts.Location = new System.Drawing.Point(3, 39);
            this.rtbAlerts.Name = "rtbAlerts";
            this.rtbAlerts.Size = new System.Drawing.Size(204, 78);
            this.rtbAlerts.TabIndex = 0;
            this.rtbAlerts.Text = "";
            this.rtbAlerts.TextChanged += new System.EventHandler(this.rtbAlerts_TextChanged);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel9.Controls.Add(this.numericUpDownVisual);
            this.panel9.Controls.Add(this.numericUpDownAudio);
            this.panel9.Controls.Add(this.checkBoxVisual);
            this.panel9.Controls.Add(this.checkBoxAudio);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 16);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(204, 23);
            this.panel9.TabIndex = 2;
            // 
            // numericUpDownVisual
            // 
            this.numericUpDownVisual.Location = new System.Drawing.Point(166, 2);
            this.numericUpDownVisual.Name = "numericUpDownVisual";
            this.numericUpDownVisual.Size = new System.Drawing.Size(35, 20);
            this.numericUpDownVisual.TabIndex = 12;
            this.numericUpDownVisual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownVisual.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownVisual.ValueChanged += new System.EventHandler(this.numericUpDownVisual_ValueChanged);
            // 
            // numericUpDownAudio
            // 
            this.numericUpDownAudio.Location = new System.Drawing.Point(64, 2);
            this.numericUpDownAudio.Name = "numericUpDownAudio";
            this.numericUpDownAudio.Size = new System.Drawing.Size(35, 20);
            this.numericUpDownAudio.TabIndex = 11;
            this.numericUpDownAudio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownAudio.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownAudio.ValueChanged += new System.EventHandler(this.numericUpDownAudio_ValueChanged);
            // 
            // checkBoxVisual
            // 
            this.checkBoxVisual.AutoSize = true;
            this.checkBoxVisual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxVisual.Checked = true;
            this.checkBoxVisual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVisual.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxVisual.Location = new System.Drawing.Point(103, 4);
            this.checkBoxVisual.Name = "checkBoxVisual";
            this.checkBoxVisual.Size = new System.Drawing.Size(54, 17);
            this.checkBoxVisual.TabIndex = 1;
            this.checkBoxVisual.Text = "Visual";
            this.checkBoxVisual.UseVisualStyleBackColor = true;
            this.checkBoxVisual.CheckedChanged += new System.EventHandler(this.checkBoxVisual_CheckedChanged);
            // 
            // checkBoxAudio
            // 
            this.checkBoxAudio.AutoSize = true;
            this.checkBoxAudio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAudio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxAudio.Location = new System.Drawing.Point(8, 4);
            this.checkBoxAudio.Name = "checkBoxAudio";
            this.checkBoxAudio.Size = new System.Drawing.Size(53, 17);
            this.checkBoxAudio.TabIndex = 0;
            this.checkBoxAudio.Text = "Audio";
            this.checkBoxAudio.UseVisualStyleBackColor = true;
            this.checkBoxAudio.CheckedChanged += new System.EventHandler(this.checkBoxAudio_CheckedChanged);
            // 
            // ReminderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ReminderControl";
            this.Size = new System.Drawing.Size(218, 127);
            this.Load += new System.EventHandler(this.ReminderControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVisual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAudio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbAlerts;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.NumericUpDown numericUpDownVisual;
        private System.Windows.Forms.NumericUpDown numericUpDownAudio;
        private System.Windows.Forms.CheckBox checkBoxVisual;
        private System.Windows.Forms.CheckBox checkBoxAudio;
    }
}
