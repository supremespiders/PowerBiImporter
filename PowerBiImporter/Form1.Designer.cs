namespace PowerBiImporter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WorkButton = new System.Windows.Forms.Button();
            this.ClearDbButton = new System.Windows.Forms.Button();
            this.startDateI = new System.Windows.Forms.DateTimePicker();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.inputPathI = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WorkButton
            // 
            this.WorkButton.Location = new System.Drawing.Point(931, 243);
            this.WorkButton.Name = "WorkButton";
            this.WorkButton.Size = new System.Drawing.Size(211, 71);
            this.WorkButton.TabIndex = 0;
            this.WorkButton.Text = "Work";
            this.WorkButton.UseVisualStyleBackColor = true;
            this.WorkButton.Click += new System.EventHandler(this.WorkButton_Click);
            // 
            // ClearDbButton
            // 
            this.ClearDbButton.Location = new System.Drawing.Point(931, 320);
            this.ClearDbButton.Name = "ClearDbButton";
            this.ClearDbButton.Size = new System.Drawing.Size(211, 71);
            this.ClearDbButton.TabIndex = 1;
            this.ClearDbButton.Text = "Clear Db";
            this.ClearDbButton.UseVisualStyleBackColor = true;
            this.ClearDbButton.Click += new System.EventHandler(this.ClearDbButton_Click);
            // 
            // startDateI
            // 
            this.startDateI.CustomFormat = "dd/MM/yyyy HH:mm";
            this.startDateI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateI.Location = new System.Drawing.Point(102, 12);
            this.startDateI.Name = "startDateI";
            this.startDateI.Size = new System.Drawing.Size(148, 27);
            this.startDateI.TabIndex = 3;
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(21, 112);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(895, 430);
            this.LogBox.TabIndex = 4;
            // 
            // inputPathI
            // 
            this.inputPathI.Location = new System.Drawing.Point(102, 45);
            this.inputPathI.Name = "inputPathI";
            this.inputPathI.Size = new System.Drawing.Size(430, 27);
            this.inputPathI.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 554);
            this.Controls.Add(this.inputPathI);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.startDateI);
            this.Controls.Add(this.ClearDbButton);
            this.Controls.Add(this.WorkButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button WorkButton;
        private Button ClearDbButton;
        private DateTimePicker startDateI;
        private TextBox LogBox;
        private TextBox inputPathI;
    }
}