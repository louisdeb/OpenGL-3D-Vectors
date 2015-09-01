using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace VectorSoftware
{
    public partial class ObjectInspectorPanel : Form
    {
        private InputPanel inputPanel;

        private BindingList<object> objectsInScene = new BindingList<object>();
        private BindingList<Point> pointsInScene;
        private BindingList<Line> linesInScene;
        private BindingList<Angle> anglesInScene;        

        public ObjectInspectorPanel(InputPanel ip)
        {
            inputPanel = ip;
            InitializeComponent();
            updateListBox();           
        }

        //Input data into the list box
        public void updateListBox()
        {
            objectsInScene = new BindingList<object>();

            //Gets all objects from the input panel
            pointsInScene = getPoints();
            linesInScene = getLines();
            anglesInScene = getAngles();

            //Adds each object to one Binding List
            foreach (Point p in pointsInScene)
            {
                objectsInScene.Add(p);
            }
            foreach (Line l in linesInScene)
            {
                objectsInScene.Add(l);
            }
            foreach (Angle a in anglesInScene)
            {
                objectsInScene.Add(a);
            }

            //Converts the Binding List to appropriate strings, and puts this data in the list for the user
            objectListBox.DataSource = convertToString(objectsInScene);
        }

        private void clearListBox()
        {
            objectListBox.DataSource = null;
            objectListBox.Items.Clear();
        }

        private BindingList<Point> getPoints()
        {
            List<Point> points = inputPanel.pointsInScene;
            BindingList<Point> bindingPoints = new BindingList<Point>(points);
            return bindingPoints;
        }

        private BindingList<Line> getLines()
        {
            List<Line> lines = inputPanel.linesInScene;
            BindingList<Line> bindingLines = new BindingList<Line>(lines);
            return bindingLines;
        }

        private BindingList<Angle> getAngles()
        {
            List<Angle> angles = inputPanel.anglesInScene;
            BindingList<Angle> bindingAngles = new BindingList<Angle>(angles);
            return bindingAngles;
        }

        //Converts each object to intelligible data
        private BindingList<string> convertToString(BindingList<object> list)
        {
            BindingList<string> returnList = new BindingList<string>();

            foreach (object o in list)
            {                
                if (o is Point)
                {
                    Point p = (Point)o;
                    string message = "Point: ( " + p.firstPoint + " )      " + p.colorString;
                    returnList.Add(message);
                }

                else if (o is Line)
                {
                    Line l = (Line)o;
                    string message = "Line: ( " + l.firstPoint + " )   ( " + l.secondPoint + " )      " + l.colorString;
                    returnList.Add(message);
                }

                else if (o is Angle)
                {                    
                    Angle a = (Angle)o;
                    string message = "Angle between " + a.firstLine + " and " + a.secondLine + "       " + a.colorString;
                    returnList.Add(message);
                }
            }

            return returnList;
        }

        //If the changeColorButton is clicked
        private void changeColorButton_Click(object sender, EventArgs e)
        {
            //If there's a valid item selected
            if (objectListBox.Items.Count > 0)
            {
                //Opens the colourChangePanel, passing the data about the selected object to it
                ColorChangePanel colorChangePanel = new ColorChangePanel(inputPanel, objectsInScene[objectListBox.SelectedIndex], this);
                colorChangePanel.Show();
            }
        }

        //If the deleteObjectButton is clicked
        private void deleteObjectButton_Click(object sender, EventArgs e)
        {
            //If there's a valid item selected
            if (objectListBox.Items.Count > 0)
            {
                object objectToBeDeleted = objectsInScene[objectListBox.SelectedIndex];

                //Finds the correct type of object
                if (objectToBeDeleted is Point)
                {
                    Point p = (Point)objectToBeDeleted;
                    //Passes the deleted point to the input panel
                    inputPanel.pointToBeDeleted = p;
                    //Stops the list updating before the object has been deleted from the scene, by pausing for 10ms
                    Thread.Sleep(10);                    
                    clearListBox();
                    updateListBox();
                }
                else if (objectToBeDeleted is Line)
                {
                    Line l = (Line)objectToBeDeleted;
                    inputPanel.lineToBeDeleted = l;
                    Thread.Sleep(10);
                    clearListBox();
                    updateListBox();
                }
                else if (objectToBeDeleted is Angle)
                {
                    Angle a = (Angle)objectToBeDeleted;
                    inputPanel.angleToBeDeleted = a;
                    Thread.Sleep(10);
                    clearListBox();
                    updateListBox();
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            updateListBox();
        }        
    }
}