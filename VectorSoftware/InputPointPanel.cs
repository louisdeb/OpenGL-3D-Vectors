using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using OpenGL;

namespace VectorSoftware
{
    public partial class InputPointPanel : Form
    {
        private InputPanel inputPanel;

        public InputPointPanel(InputPanel ip)
        {            
            InitializeComponent();
            inputPanel = ip;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            float x = 0;
            float y = 0;
            float z = 0;
            bool valid = true;

            //Attempt to get a float from each test box
            //If the data isn't valid, set valid to false

            try
            {
                x = float.Parse(textBoxX.Text);
            }
            catch
            {                
                valid = false;                
            }

            try
            {
                y = float.Parse(textBoxY.Text);
            }
            catch
            {
                valid = false;                
            }

            try
            {                
                z = float.Parse(textBoxZ.Text);
            }
            catch
            {
                valid = false;                
            }

            //If all data was successfully obtained as floats
            if (valid)
            {
                //Send the data to the input panel
                inputPanel.addPoint(x, y, z);
                this.Close();    
            }
			else
			{				
                //Display the error message if the data inputted isn't valid
                labelInvalid.Visible = true;
			}
        }       
    }
}
