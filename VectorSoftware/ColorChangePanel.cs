using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OpenGL;
using System.Threading;

namespace VectorSoftware
{
    public partial class ColorChangePanel : Form
    {
        private InputPanel inputPanel;
        private ObjectInspectorPanel objectInspectorPanel;
        private List<Vector3> colors = new List<Vector3>();
        private List<string> colorStrings = new List<string>();
        private Point p;
        private Line l;
        private Angle a;
        private string currentColorString;
        private Vector3 currentRawColor;            

        public ColorChangePanel(InputPanel ip, object ob, ObjectInspectorPanel oip)
        {
            inputPanel = ip;
            objectInspectorPanel = oip;
            InitializeComponent();
            initialiseColors();
            updateListBox(ob);
        }

        private void initialiseColors()
        {            
            colors.Add(new Vector3(1, 0.5f, 0));
            colors.Add(new Vector3(1, 1, 0));
            colors.Add(new Vector3(0.5f, 1, 0));
            colors.Add(new Vector3(0, 1, 0));
            colors.Add(new Vector3(0, 1, 0.5f));            
            colors.Add(new Vector3(0, 0.5f, 1));
            colors.Add(new Vector3(0, 0, 1));
            colors.Add(new Vector3(0.5f, 0, 1));
            colors.Add(new Vector3(1, 0, 1));
            colors.Add(new Vector3(1, 0, 0.5f));
            
            colorStrings.Add("Orange");
            colorStrings.Add("Yellow");
            colorStrings.Add("Lime");
            colorStrings.Add("Green");
            colorStrings.Add("Turquoise");            
            colorStrings.Add("Light Blue");
            colorStrings.Add("Blue");
            colorStrings.Add("Purple");
            colorStrings.Add("Pink");
            colorStrings.Add("Magenta");
        }

        private void updateListBox(object ob)
        {
            if (ob is Point)
            {
                p = (Point)ob;                
            }
            else if (ob is Line)
            {
                l = (Line)ob;
            }
            else if (ob is Angle)
            {
                a = (Angle)ob;
            }

            //Convert each object into information about the object, along side its colour
            if (p != null)
            {                
                int index = colors.IndexOf(p.rawColor);                
                currentRawColor = p.rawColor;
                currentColorString = colorStrings[index];

                string identity = "Point: ( " + p.firstPoint + " )";
                identityLabel.Text = identity;
            }                
            else if (l != null)
            {                
                int index = colors.IndexOf(l.rawColor);
                currentRawColor = l.rawColor;
                currentColorString = colorStrings[index];

                string identity = "Line: ( " + l.firstPoint + " )   ( " + l.secondPoint + " )";
                identityLabel.Text = identity;
            }
            else if (a != null)
            {                
                int index = colors.IndexOf(a.rawColor);
                currentRawColor = a.rawColor;
                currentColorString = colorStrings[index];

                string identity = "Angle between ( " + a.firstLine + " )   ( " + a.secondLine + " )";
                identityLabel.Text = identity;
            }           

            currentColorLabel.Text = currentColorString;

            //Show the list in the list box
            BindingList<string> displayStringList = new BindingList<string>(colorStrings);
            listBox.DataSource = displayStringList;
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            Vector3 newColor = colors[index];

            //If the object still exists, pass it and the new colour to input panel
            if (p != null)
            {
                inputPanel.setNewColor(p, newColor);
            }
            else if (l != null)
            {
                inputPanel.setNewColor(l, newColor);
            }
            else if (a != null)
            {
                inputPanel.setNewColor(a, newColor);
            }
            
            Thread.Sleep(10);
            objectInspectorPanel.updateListBox();
            this.Close();
        }
              
    }
}
