using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VectorSoftware
{
    public partial class InputLinePanel : Form
    {
        private InputPanel inputPanel; 

        public InputLinePanel(InputPanel ip)
        {
            inputPanel = ip;
            List<Point> points = inputPanel.pointsInScene;
            InitializeComponent();

            //Don't allow the functionality of chosing two points to create the line between if there are no existing points
            if (points.Count <= 0)
            {
                buttonExistingPoints.Enabled = false;
            }
        }

        //Calculates the final point on the line from the inputted equation of the line
        private float[] calculateFinalPoint(float x, float y, float z, float s, float a, float b, float c)
        {            
            float fx = x + (s * a);
            float fy = y + (s * b);
            float fz = z + (s * c);

            return new float[] { fx, fy, fz };
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            float x = 0;
            float y = 0;
            float z = 0;
            float s = 0;
            float a = 0;
            float b = 0;
            float c = 0;
            bool valid = true;

            //Attempt to read in data from each of the text boxes
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

            try
            {
                s = float.Parse(textBoxS.Text);
            }
            catch
            {
                valid = false;                
            }

            if (s == 0)
            {
                valid = false;
                labelMagnitude.Visible = true;
            }

            try
            {
                a = float.Parse(textBoxA.Text);
            }
            catch
            {
                valid = false;                
            }

            try
            {
                b = float.Parse(textBoxB.Text);
            }
            catch
            {
                valid = false;                
            }

            try
            {
                c = float.Parse(textBoxC.Text);
            }
            catch
            {
                valid = false;                
            }

            if ((a == 0) && (b == 0) && (c == 0))
            {
                valid = false;
                directionLabel.Visible = true;
            }
            
            if (valid)
            {
                //If all of the data is successfully read in, pass the line data to the input panel
                float[] finalPoint = calculateFinalPoint(x, y, z, s, a, b, c);
                inputPanel.addLine(x, y, z, finalPoint[0], finalPoint[1], finalPoint[2]);

                //Close this panel
                this.Close();
            }
			else
			{			
                //If any of the data is invalid, show to error label
                labelInvalid.Visible = true;
			}
        }

        private void buttonExistingPoints_Click(object sender, EventArgs e)
        {         
            //Open inputLineFromPointsPanel, and then close this panel
            InputLineFromPointsPanel inputLineFromPointsPanel = new InputLineFromPointsPanel(inputPanel);
            this.Close();
        }

        
    }
}
