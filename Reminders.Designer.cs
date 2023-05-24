using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT_Reminders
{
    public partial class Reminders
    {
        #region Designer Created Code (Avoid editing)
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.playerControl1 = new ACT_Reminders.PlayerControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuietTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegexp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.playerControl1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(672, 352);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 384);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.VisibleChanged += new System.EventHandler(this.tabControl1_VisibleChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(678, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Player";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(678, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reminders";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colUse,
            this.colTitle,
            this.QuietTime,
            this.colRegexp});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(672, 352);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_RowValidating);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // playerControl1
            // 
            this.playerControl1.Location = new System.Drawing.Point(3, 3);
            this.playerControl1.Name = "playerControl1";
            this.playerControl1.Size = new System.Drawing.Size(218, 127);
            this.playerControl1.TabIndex = 8;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(ACT_Reminders.ReminderType);
            this.bindingSource1.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.bindingSource1_AddingNew);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colUse
            // 
            this.colUse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colUse.DataPropertyName = "Use";
            this.colUse.HeaderText = "Use";
            this.colUse.Name = "colUse";
            this.colUse.Width = 32;
            // 
            // colTitle
            // 
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 52;
            // 
            // QuietTime
            // 
            this.QuietTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QuietTime.DataPropertyName = "QuietTime";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QuietTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.QuietTime.HeaderText = "Quiet Time";
            this.QuietTime.Name = "QuietTime";
            this.QuietTime.Width = 83;
            // 
            // colRegexp
            // 
            this.colRegexp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRegexp.DataPropertyName = "Regexp";
            this.colRegexp.HeaderText = "Regexp";
            this.colRegexp.Name = "colRegexp";
            // 
            // Reminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Reminders";
            this.Size = new System.Drawing.Size(686, 384);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private ToolTip toolTip1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private BindingSource bindingSource1;

        #endregion
        private PlayerControl playerControl1;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewCheckBoxColumn colUse;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn QuietTime;
        private DataGridViewTextBoxColumn colRegexp;
    }
}
