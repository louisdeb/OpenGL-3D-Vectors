namespace VectorSoftware
{
    partial class ObjectInspectorPanel
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
            this.objectListBox = new System.Windows.Forms.ListBox();
            this.changeColorButton = new System.Windows.Forms.Button();
            this.deleteObjectButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // objectListBox
            // 
            this.objectListBox.FormattingEnabled = true;
            this.objectListBox.HorizontalScrollbar = true;
            this.objectListBox.Location = new System.Drawing.Point(12, 27);
            this.objectListBox.Name = "objectListBox";
            this.objectListBox.Size = new System.Drawing.Size(260, 186);
            this.objectListBox.TabIndex = 0;
            // 
            // changeColorButton
            // 
            this.changeColorButton.Location = new System.Drawing.Point(13, 220);
            this.changeColorButton.Name = "changeColorButton";
            this.changeColorButton.Size = new System.Drawing.Size(85, 23);
            this.changeColorButton.TabIndex = 1;
            this.changeColorButton.Text = "Change Colour";
            this.changeColorButton.UseVisualStyleBackColor = true;
            this.changeColorButton.Click += new System.EventHandler(this.changeColorButton_Click);
            // 
            // deleteObjectButton
            // 
            this.deleteObjectButton.Location = new System.Drawing.Point(105, 220);
            this.deleteObjectButton.Name = "deleteObjectButton";
            this.deleteObjectButton.Size = new System.Drawing.Size(82, 23);
            this.deleteObjectButton.TabIndex = 2;
            this.deleteObjectButton.Text = "Delete Object";
            this.deleteObjectButton.UseVisualStyleBackColor = true;
            this.deleteObjectButton.Click += new System.EventHandler(this.deleteObjectButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(194, 219);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // ObjectInspectorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.deleteObjectButton);
            this.Controls.Add(this.changeColorButton);
            this.Controls.Add(this.objectListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ObjectInspectorPanel";
            this.Text = "Object Inspector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox objectListBox;
        private System.Windows.Forms.Button changeColorButton;
        private System.Windows.Forms.Button deleteObjectButton;
        private System.Windows.Forms.Button refreshButton;
    }
}