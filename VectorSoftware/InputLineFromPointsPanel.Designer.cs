namespace VectorSoftware
{
    partial class InputLineFromPointsPanel
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
            this.firstPointListBox = new System.Windows.Forms.ListBox();
            this.secondPointListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.existLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstPointListBox
            // 
            this.firstPointListBox.FormattingEnabled = true;
            this.firstPointListBox.HorizontalScrollbar = true;
            this.firstPointListBox.Location = new System.Drawing.Point(12, 65);
            this.firstPointListBox.Name = "firstPointListBox";
            this.firstPointListBox.Size = new System.Drawing.Size(120, 134);
            this.firstPointListBox.TabIndex = 0;
            // 
            // secondPointListBox
            // 
            this.secondPointListBox.FormattingEnabled = true;
            this.secondPointListBox.HorizontalScrollbar = true;
            this.secondPointListBox.Location = new System.Drawing.Point(152, 65);
            this.secondPointListBox.Name = "secondPointListBox";
            this.secondPointListBox.Size = new System.Drawing.Size(120, 134);
            this.secondPointListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select the 2 points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Point";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Second Point";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(197, 227);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 5;
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
            this.errorLabel.Size = new System.Drawing.Size(174, 13);
            this.errorLabel.TabIndex = 6;
            this.errorLabel.Text = "The two points cannot be the same";
            this.errorLabel.Visible = false;
            // 
            // existLabel
            // 
            this.existLabel.AutoSize = true;
            this.existLabel.ForeColor = System.Drawing.Color.Red;
            this.existLabel.Location = new System.Drawing.Point(9, 211);
            this.existLabel.Name = "existLabel";
            this.existLabel.Size = new System.Drawing.Size(192, 13);
            this.existLabel.TabIndex = 7;
            this.existLabel.Text = "At least one of the points does not exist";
            this.existLabel.Visible = false;
            // 
            // InputLineFromPointsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.existLabel);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondPointListBox);
            this.Controls.Add(this.firstPointListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputLineFromPointsPanel";
            this.Text = "Input Line From Points";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox firstPointListBox;
        private System.Windows.Forms.ListBox secondPointListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label existLabel;

    }
}