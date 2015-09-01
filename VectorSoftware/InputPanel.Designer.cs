namespace VectorSoftware
{
    partial class InputPanel
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
            this.newPointButton = new System.Windows.Forms.Button();
            this.newLineButton = new System.Windows.Forms.Button();
            this.newAngleButton = new System.Windows.Forms.Button();
            this.objectInspectorButton = new System.Windows.Forms.Button();
            this.createNewSceneButton = new System.Windows.Forms.Button();
            this.closeSceneButton = new System.Windows.Forms.Button();
            this.anaglyphCheckBox = new System.Windows.Forms.CheckBox();
            this.openSceneButton = new System.Windows.Forms.Button();
            this.saveSceneButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.trackBarAnaglyph = new System.Windows.Forms.TrackBar();
            this.anaglyphLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnaglyph)).BeginInit();
            this.SuspendLayout();
            // 
            // newPointButton
            // 
            this.newPointButton.Enabled = false;
            this.newPointButton.Location = new System.Drawing.Point(12, 12);
            this.newPointButton.Name = "newPointButton";
            this.newPointButton.Size = new System.Drawing.Size(165, 23);
            this.newPointButton.TabIndex = 0;
            this.newPointButton.Text = "Add New Point";
            this.newPointButton.UseVisualStyleBackColor = true;
            this.newPointButton.Click += new System.EventHandler(this.newPointButton_Click);
            // 
            // newLineButton
            // 
            this.newLineButton.Enabled = false;
            this.newLineButton.Location = new System.Drawing.Point(12, 41);
            this.newLineButton.Name = "newLineButton";
            this.newLineButton.Size = new System.Drawing.Size(165, 23);
            this.newLineButton.TabIndex = 1;
            this.newLineButton.Text = "Add New Line";
            this.newLineButton.UseVisualStyleBackColor = true;
            this.newLineButton.Click += new System.EventHandler(this.newLineButton_Click);
            // 
            // newAngleButton
            // 
            this.newAngleButton.Enabled = false;
            this.newAngleButton.Location = new System.Drawing.Point(12, 71);
            this.newAngleButton.Name = "newAngleButton";
            this.newAngleButton.Size = new System.Drawing.Size(165, 23);
            this.newAngleButton.TabIndex = 2;
            this.newAngleButton.Text = "Add New Angle";
            this.newAngleButton.UseVisualStyleBackColor = true;
            this.newAngleButton.Click += new System.EventHandler(this.newAngleButton_Click);
            // 
            // objectInspectorButton
            // 
            this.objectInspectorButton.Enabled = false;
            this.objectInspectorButton.Location = new System.Drawing.Point(13, 101);
            this.objectInspectorButton.Name = "objectInspectorButton";
            this.objectInspectorButton.Size = new System.Drawing.Size(164, 23);
            this.objectInspectorButton.TabIndex = 3;
            this.objectInspectorButton.Text = "Open Object Inspector";
            this.objectInspectorButton.UseVisualStyleBackColor = true;
            this.objectInspectorButton.Click += new System.EventHandler(this.objectInspectorButton_Click);
            // 
            // createNewSceneButton
            // 
            this.createNewSceneButton.Location = new System.Drawing.Point(12, 131);
            this.createNewSceneButton.Name = "createNewSceneButton";
            this.createNewSceneButton.Size = new System.Drawing.Size(165, 23);
            this.createNewSceneButton.TabIndex = 4;
            this.createNewSceneButton.Text = "Create New Scene";
            this.createNewSceneButton.UseVisualStyleBackColor = true;
            this.createNewSceneButton.Click += new System.EventHandler(this.createNewSceneButton_Click);
            // 
            // closeSceneButton
            // 
            this.closeSceneButton.Enabled = false;
            this.closeSceneButton.Location = new System.Drawing.Point(13, 161);
            this.closeSceneButton.Name = "closeSceneButton";
            this.closeSceneButton.Size = new System.Drawing.Size(164, 23);
            this.closeSceneButton.TabIndex = 5;
            this.closeSceneButton.Text = "Close Scene";
            this.closeSceneButton.UseVisualStyleBackColor = true;
            this.closeSceneButton.Click += new System.EventHandler(this.closeSceneButton_Click);
            // 
            // anaglyphCheckBox
            // 
            this.anaglyphCheckBox.AutoSize = true;
            this.anaglyphCheckBox.Enabled = false;
            this.anaglyphCheckBox.Location = new System.Drawing.Point(202, 12);
            this.anaglyphCheckBox.Name = "anaglyphCheckBox";
            this.anaglyphCheckBox.Size = new System.Drawing.Size(70, 17);
            this.anaglyphCheckBox.TabIndex = 6;
            this.anaglyphCheckBox.Text = "Anaglyph";
            this.anaglyphCheckBox.UseVisualStyleBackColor = true;
            this.anaglyphCheckBox.CheckedChanged += new System.EventHandler(this.anaglyphCheckBox_CheckedChanged);
            // 
            // openSceneButton
            // 
            this.openSceneButton.Location = new System.Drawing.Point(13, 191);
            this.openSceneButton.Name = "openSceneButton";
            this.openSceneButton.Size = new System.Drawing.Size(164, 23);
            this.openSceneButton.TabIndex = 7;
            this.openSceneButton.Text = "Open Scene";
            this.openSceneButton.UseVisualStyleBackColor = true;
            this.openSceneButton.Click += new System.EventHandler(this.openSceneButton_Click);
            // 
            // saveSceneButton
            // 
            this.saveSceneButton.Enabled = false;
            this.saveSceneButton.Location = new System.Drawing.Point(13, 221);
            this.saveSceneButton.Name = "saveSceneButton";
            this.saveSceneButton.Size = new System.Drawing.Size(163, 23);
            this.saveSceneButton.TabIndex = 8;
            this.saveSceneButton.Text = "Save Scene";
            this.saveSceneButton.UseVisualStyleBackColor = true;
            this.saveSceneButton.Click += new System.EventHandler(this.saveSceneButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Scene.csv";
            this.openFileDialog.Filter = "Scene Files (.csv)|*.csv|All Files|*.*";
            this.openFileDialog.Title = "Open Scene";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "csv";
            this.saveFileDialog.FileName = "scene";
            this.saveFileDialog.Title = "Save Scene";
            // 
            // trackBarAnaglyph
            // 
            this.trackBarAnaglyph.Enabled = false;
            this.trackBarAnaglyph.Location = new System.Drawing.Point(183, 71);
            this.trackBarAnaglyph.Name = "trackBarAnaglyph";
            this.trackBarAnaglyph.Size = new System.Drawing.Size(104, 45);
            this.trackBarAnaglyph.TabIndex = 9;
            this.trackBarAnaglyph.ValueChanged += new System.EventHandler(this.trackBarAnaglyph_ValueChanged);
            // 
            // anaglyphLabel
            // 
            this.anaglyphLabel.AutoSize = true;
            this.anaglyphLabel.Enabled = false;
            this.anaglyphLabel.Location = new System.Drawing.Point(199, 51);
            this.anaglyphLabel.Name = "anaglyphLabel";
            this.anaglyphLabel.Size = new System.Drawing.Size(83, 13);
            this.anaglyphLabel.TabIndex = 10;
            this.anaglyphLabel.Text = "Adjust Anaglyph";
            // 
            // InputPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.anaglyphLabel);
            this.Controls.Add(this.trackBarAnaglyph);
            this.Controls.Add(this.saveSceneButton);
            this.Controls.Add(this.openSceneButton);
            this.Controls.Add(this.anaglyphCheckBox);
            this.Controls.Add(this.closeSceneButton);
            this.Controls.Add(this.createNewSceneButton);
            this.Controls.Add(this.objectInspectorButton);
            this.Controls.Add(this.newAngleButton);
            this.Controls.Add(this.newLineButton);
            this.Controls.Add(this.newPointButton);
            this.Name = "InputPanel";
            this.Text = "Vector Software";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputPanel_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnaglyph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newPointButton;
        private System.Windows.Forms.Button newLineButton;
        private System.Windows.Forms.Button newAngleButton;
        private System.Windows.Forms.Button objectInspectorButton;
        private System.Windows.Forms.Button createNewSceneButton;
        private System.Windows.Forms.Button closeSceneButton;
        private System.Windows.Forms.CheckBox anaglyphCheckBox;
        private System.Windows.Forms.Button openSceneButton;
        private System.Windows.Forms.Button saveSceneButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TrackBar trackBarAnaglyph;
        private System.Windows.Forms.Label anaglyphLabel;
    }
}