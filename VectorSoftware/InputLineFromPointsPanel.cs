using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Windows.Forms;

namespace VectorSoftware
{
    public partial class InputLineFromPointsPanel : Form
    {
        private InputPanel inputPanel;
        private BindingList<Point> pointsInScene;

        public InputLineFromPointsPanel(InputPanel ip)
        {            
            inputPanel = ip;
            InitializeComponent();
            
            pointsInScene = getPoints();

            //Create two appropriate lists to be displayed to the user
            BindingList<string> firstPointsToBeDisplayed = convertPointsToStrings(pointsInScene);
            BindingList<string> secondPointsToBeDisplayed = convertPointsToStrings(pointsInScene); ;

            //Assign the two above lists to the list boxes
            firstPointListBox.DataSource = firstPointsToBeDisplayed;
            secondPointListBox.DataSource = secondPointsToBeDisplayed;

            this.Show();
        }

        //Get a list of points in the scene from the input panel
        private BindingList<Point> getPoints()
        {
            List<Point> points = inputPanel.pointsInScene;
            BindingList<Point> bindingPoints = new BindingList<Point>(points);
            return bindingPoints;
        }

        //Turn the list of points into intelligible data to be displayed to the user
        private BindingList<string> convertPointsToStrings(BindingList<Point> points)
        {
            BindingList<string> stringList = new BindingList<string>();

            foreach (Point p in points)
            {
                string coordinate = p.firstPoint;
                stringList.Add(coordinate);
            }

            return stringList;
        }
        
        private void submitButton_Click(object sender, EventArgs e)
        {                        
            try            
            {
                //Get the two selected points
                Point firstSelectedPoint = pointsInScene[firstPointListBox.SelectedIndex];
                Point secondSelectedPoint = pointsInScene[secondPointListBox.SelectedIndex];

                //If the two points are the same, display an error label and don't submit the points
                if (firstSelectedPoint.rawPoint == secondSelectedPoint.rawPoint)
                {
                    errorLabel.Visible = true;
                }
                else
                {
                    //If the points are different, submit the points to input panel and close the form
                    inputPanel.addLine(firstSelectedPoint.rawPoint.x, firstSelectedPoint.rawPoint.y, firstSelectedPoint.rawPoint.z, secondSelectedPoint.rawPoint.x, secondSelectedPoint.rawPoint.y, secondSelectedPoint.rawPoint.z);
                    this.Close();
                }
            }
            catch
            {
                //Show error label concerning one of the points not existing
                existLabel.Visible = true;
            }                        
        }       
    }
}