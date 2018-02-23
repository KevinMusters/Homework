namespace HomeWork
{
    partial class frmAdd
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.calDate = new System.Windows.Forms.MonthCalendar();
            this.txtHomework = new System.Windows.Forms.TextBox();
            this.lblHomework = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tmrDate = new System.Windows.Forms.Timer(this.components);
            this.txtExplain = new System.Windows.Forms.RichTextBox();
            this.lblExplain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // calDate
            // 
            this.calDate.Location = new System.Drawing.Point(18, 18);
            this.calDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.calDate.Name = "calDate";
            this.calDate.TabIndex = 0;
            this.calDate.TabStop = false;
            // 
            // txtHomework
            // 
            this.txtHomework.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHomework.Location = new System.Drawing.Point(257, 34);
            this.txtHomework.Name = "txtHomework";
            this.txtHomework.Size = new System.Drawing.Size(264, 23);
            this.txtHomework.TabIndex = 1;
            // 
            // lblHomework
            // 
            this.lblHomework.AutoSize = true;
            this.lblHomework.Location = new System.Drawing.Point(254, 18);
            this.lblHomework.Name = "lblHomework";
            this.lblHomework.Size = new System.Drawing.Size(84, 13);
            this.lblHomework.TabIndex = 2;
            this.lblHomework.Text = "Homework Title:";
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(257, 81);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(264, 23);
            this.txtDate.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(254, 65);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(431, 247);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 500;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // txtExplain
            // 
            this.txtExplain.Location = new System.Drawing.Point(257, 129);
            this.txtExplain.Name = "txtExplain";
            this.txtExplain.Size = new System.Drawing.Size(264, 112);
            this.txtExplain.TabIndex = 3;
            this.txtExplain.Text = "";
            // 
            // lblExplain
            // 
            this.lblExplain.AutoSize = true;
            this.lblExplain.Location = new System.Drawing.Point(254, 113);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(98, 13);
            this.lblExplain.TabIndex = 7;
            this.lblExplain.Text = "Homework Explain:";
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 284);
            this.Controls.Add(this.lblExplain);
            this.Controls.Add(this.txtExplain);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblHomework);
            this.Controls.Add(this.txtHomework);
            this.Controls.Add(this.calDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAdd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Homework";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdd_FormClosing);
            this.Load += new System.EventHandler(this.frmAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calDate;
        private System.Windows.Forms.TextBox txtHomework;
        private System.Windows.Forms.Label lblHomework;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Timer tmrDate;
        private System.Windows.Forms.RichTextBox txtExplain;
        private System.Windows.Forms.Label lblExplain;
    }
}