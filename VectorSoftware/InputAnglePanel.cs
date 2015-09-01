using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Windows.Forms;

namespace VectorSoftware
{
    public partial class InputAnglePanel : Form
    {
        private InputPanel inputPanel;
        private BindingList<Line> linesInScene;

        public InputAnglePanel(InputPanel ip)
        {
            inputPanel = ip;            
            InitializeComponent();

            linesInScene = getLines();

            //If there are no lines in the scene, don't enable the submit button
            if (linesInScene.Count <= 0)
            {
                submitButton.Enabled = false;
            }

            //Create two appropriate lists to be displayed to the user
            BindingList<string> firstDisplayList = convertLinesToStrings(linesInScene);
            BindingList<string> secondDisplayList = convertLinesToStrings(linesInScene);

            //Assign the two above lists to the list boxes
            firstLineListBox.DataSource = firstDisplayList;
            secondLineListBox.DataSource = secondDisplayList;
        }

        //Gets a list of the lines in the scene
        private BindingList<Line> getLines()
        {
            List<Line> lines = inputPanel.linesInScene;
            BindingList<Line> bindingLines = new BindingList<Line>(lines);
            return bindingLines;
        }

        //Turn the list of lines into intelligible data to be displayed to the user
        private BindingList<string> convertLinesToStrings(BindingList<Line> lines)
        {
            BindingList<string> stringList = new BindingList<string>();

            foreach (Line l in lines)
            {
                string coordinate = "( " + l.firstPoint + " )   ( " + l.secondPoint + " )";
                stringList.Add(coordinate);
            }

            return stringList;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                Line firstSelectedLine = linesInScene[firstLineListBox.SelectedIndex];
                Line secondSelectedLine = linesInScene[secondLineListBox.SelectedIndex];

                //If the two selected lines are the same, display an error label
                if (firstSelectedLine.line == secondSelectedLine.line)
                {
                    errorLabel.Visible = true;
                }
                else
                {
                    //If the two selected lines are different, submit the angle and close the panel
                    inputPanel.addAngle(
                        firstSelectedLine.rawFirstPoint.x, firstSelectedLine.rawFirstPoint.y, firstSelectedLine.rawFirstPoint.z,
                        firstSelectedLine.rawSecondPoint.x, firstSelectedLine.rawSecondPoint.y, firstSelectedLine.rawSecondPoint.z,
                        secondSelectedLine.rawFirstPoint.x, secondSelectedLine.rawFirstPoint.y, secondSelectedLine.rawFirstPoint.z,
                        secondSelectedLine.rawSecondPoint.x, secondSelectedLine.rawSecondPoint.y, secondSelectedLine.rawSecondPoint.z);

                    this.Close();
                }
            }
            catch
            {
                existLabel.Visible = true;
            }
        }  
    }
}
