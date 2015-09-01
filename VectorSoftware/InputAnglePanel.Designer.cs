namespace VectorSoftware
{
    partial class InputAnglePanel
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
            this.firstLineListBox = new System.Windows.Forms.ListBox();
            this.secondLineListBox = new System.Windows.Forms.ListBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.existLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstLineListBox
            // 
            this.firstLineListBox.FormattingEnabled = true;
            this.firstLineListBox.HorizontalScrollbar = true;
            this.firstLineListBox.Location = new System.Drawing.Point(12, 65);
            this.firstLineListBox.Name = "firstLineListBox";
            this.firstLineListBox.Size = new System.Drawing.Size(120, 134);
            this.firstLineListBox.TabIndex = 0;
            // 
            // secondLineListBox
            // 
            this.secondLineListBox.FormattingEnabled = true;
            this.secondLineListBox.HorizontalScrollbar = true;
            this.secondLineListBox.Location = new System.Drawing.Point(152, 65);
            this.secondLineListBox.Name = "secondLineListBox";
            this.secondLineListBox.Size = new System.Drawing.Size(120, 134);
            this.secondLineListBox.TabIndex = 1;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(197, 227);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(9, 237);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(167, 13);
            this.errorLabel.TabIndex = 7;
            this.errorLabel.Text = "The two lines cannot be the same";
            this.errorLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select the 2 points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "First Line";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Second Line";
            // 
            // existLabel
            // 
            this.existLabel.AutoSize = true;
            this.existLabel.ForeColor = System.Drawing.Color.Red;
            this.existLabel.Location = new System.Drawing.Point(9, 213);
            this.existLabel.Name = "existLabel";
            this.existLabel.Size = new System.Drawing.Size(185, 13);
            this.existLabel.TabIndex = 11;
            this.existLabel.Text = "At least one of the lines does not exist";
            this.existLabel.Visible = false;
            // 
            // InputAnglePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.existLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.secondLineListBox);
            this.Controls.Add(this.firstLineListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputAnglePanel";
            this.Text = "Input Angle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox firstLineListBox;
        private System.Windows.Forms.ListBox secondLineListBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label existLabel;
    }
}