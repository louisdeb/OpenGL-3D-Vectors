using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using System.ComponentModel; //objectInspector

using System.IO; //file handling
using System.Text;

using Tao.FreeGlut;
using OpenGL;

namespace VectorSoftware
{
    public partial class InputPanel : Form
    {        
        private Scene scene;
        public Thread sceneThread;               
        
        private List<Vector3> pointsToBeRendered = new List<Vector3>();           
        private List<Vector3[]> linesToBeRendered = new List<Vector3[]>();
        private List<Vector3[]> anglesToBeRendered = new List<Vector3[]>();
        
        private List<Vector3[]> pointsToBeRenderedWithColor = new List<Vector3[]>();
        private List<Vector3[]> linesToBeRenderedWithColor = new List<Vector3[]>();
        private List<Vector3[]> anglesToBeRenderedWithColor = new List<Vector3[]>();

        public Point pointToBeDeleted;        
        public Line lineToBeDeleted;
        public Angle angleToBeDeleted;

        private object objectWithColorChange;
        private Vector3 newColor;

        public List<Point> pointsInScene = new List<Point>();
        public List<Line> linesInScene = new List<Line>();
        public List<Angle> anglesInScene = new List<Angle>();

        private bool anaglyphToggle = false;
        private int anaglyphAdjust;      

        public InputPanel()
        {                      
            InitializeComponent();            
        }        

        public void createNewScene()
        {           
            //Initialise the thread
            sceneThread = new Thread(new ParameterizedThreadStart(initScene));
            sceneThread.SetApartmentState(ApartmentState.STA);

            //Start the thread, passing it a reference to input panel (to allow object fetches)
            sceneThread.Start(this);
            
            enableComponents();
        }

        public void closeScene()
        {
            //If the attempt at calling this function was flagged as invalid due to a cross-thread call, allow the call
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(closeScene));
            }

            scene = null;

            disableComponents(); 

            //Try to close the sceneThread
            try
            {                
                sceneThread.Abort();               
            }
            catch 
            {
                //If the sceneThread can't be closed, it already is closed
            }              
        }        

        private void enableComponents()
        {          
            //Enable input buttons
            newPointButton.Enabled = true;
            newLineButton.Enabled = true;
            newAngleButton.Enabled = true;            

            //Enable objectInspector button
            objectInspectorButton.Enabled = true;                        

            //Disable create scene control buttons
            createNewSceneButton.Enabled = false;
            openSceneButton.Enabled = false;

            //Enable current scene control buttons
            saveSceneButton.Enabled = true;
            closeSceneButton.Enabled = true;

            //Enable anaglyph check box
            anaglyphCheckBox.Enabled = true;           
        }

        private void disableComponents()
        {
            //Disable input buttons
            newPointButton.Enabled = false;
            newLineButton.Enabled = false;
            newAngleButton.Enabled = false;

            //Disable objectInspector button
            objectInspectorButton.Enabled = false;
                        
            //Enable create scene control buttons
            createNewSceneButton.Enabled = true;
            openSceneButton.Enabled = true;

            //Disbable current scene control buttons
            saveSceneButton.Enabled = false;
            closeSceneButton.Enabled = false;

            //Set anaglyph render to false, and disable the check box
            anaglyphCheckBox.Checked = false;
            anaglyphCheckBox.Enabled = false;            
        }

        private void initScene(object obj)
        {
            InputPanel ip = (InputPanel)obj;
            scene = new Scene(ip);
        }                                  

        private readonly object pointLock = new object();
        private readonly object lineLock = new object();
        private readonly object angleLock = new object();
        private readonly object colorLock = new object();
        private readonly object colorPointLock = new object();
        private readonly object colorLineLock = new object();
        private readonly object colorAngleLock = new object();
        private readonly object anaglyphLock = new object();
        private readonly object anaglyphAdjustLock = new object();

        public void addPoint(float x, float y, float z)
        {
            lock (pointLock)
            {                
                pointsToBeRendered.Add(new Vector3(x, y, z));
            }
        }
       
        public void addLine(float x, float y, float z, float a, float b, float c)
        {
            lock (lineLock)
            {
                linesToBeRendered.Add(new Vector3[] { new Vector3(x, y, z), new Vector3(a, b, c) });
            }
        }

        public void addAngle(float l1x, float l1y, float l1z, float l1a, float l1b, float l1c, float l2x, float l2y, float l2z, float l2a, float l2b, float l2c)
        {
            lock (angleLock)
            {
                Vector3 line1FirstPoint = new Vector3(l1x, l1y, l1z);
                Vector3 line1SecondPoint = new Vector3(l1a, l1b, l1c);
                Vector3 line2FirstPoint = new Vector3(l2x, l2y, l2z);
                Vector3 line2SecondPoint = new Vector3(l2a, l2b, l2c);

                anglesToBeRendered.Add(new Vector3[] { line1FirstPoint, line1SecondPoint, line2FirstPoint, line2SecondPoint });
            }
        }

        public List<Vector3> getPoints()
        {
            lock (pointLock)
            {
                List<Vector3> temp = pointsToBeRendered;
                pointsToBeRendered = new List<Vector3>();
                return temp;
            }
        }

        public List<Vector3[]> getLines()
        {
            lock (lineLock)
            {
                List<Vector3[]> temp = linesToBeRendered;
                linesToBeRendered = new List<Vector3[]>();
                return temp;
            }
        }
       
        public List<Vector3[]> getAngles()
        {
            lock (angleLock)
            {
                List<Vector3[]> temp = anglesToBeRendered;
                anglesToBeRendered = new List<Vector3[]>();
                return temp;
            }
        }

        public List<Vector3[]> getPointsWithColor()
        {
            lock (colorPointLock)
            {
                List<Vector3[]> temp = pointsToBeRenderedWithColor;
                pointsToBeRenderedWithColor = new List<Vector3[]>();
                return temp;
            }
        }

        public List<Vector3[]> getLinesWithColor()
        {
            lock (colorLineLock)
            {
                List<Vector3[]> temp = linesToBeRenderedWithColor;
                linesToBeRenderedWithColor = new List<Vector3[]>();
                return temp;
            }
        }

        public List<Vector3[]> getAnglesWithColor()
        {
            lock (colorAngleLock)
            {
                List<Vector3[]> temp = anglesToBeRenderedWithColor;
                anglesToBeRenderedWithColor = new List<Vector3[]>();
                return temp;
            }
        }

        public void setPointsInScene(List<Point> p)
        {
            pointsInScene = p;            
        }

        public void setLinesInScene(List<Line> l)
        {
            linesInScene = l;
        }

        public void setAnglesInScene(List<Angle> a)
        {
            anglesInScene = a;
        }

        public void setNewColor(object o, Vector3 color)
        {
            lock (colorLock)
            {
                objectWithColorChange = o;
                newColor = color;
            }
        }

        public object getColorChangeObject()
        {
            lock (colorLock)
            {
                object temp = objectWithColorChange;
                objectWithColorChange = null;
                return temp;                              
            }
        }

        public Vector3 getNewColor()
        {
            lock (colorLock)
            {
                return newColor;
            }
        }

        private void setAnaglyphToggled(bool value)
        {
            lock (anaglyphLock)
            {
                anaglyphToggle = value;
            }   
        }

        public bool getAnaglyphToggled()
        {
            lock (anaglyphLock)
            {
                return anaglyphToggle;
            }
        }

        private void setAnaglyphAdjust(int value)
        {
            lock (anaglyphAdjustLock)
            {
                anaglyphAdjust = value;
            }
        }

        public int getAnaglyphAdjust()
        {
            lock (anaglyphAdjustLock)
            {
                return anaglyphAdjust;
            }
        }                

        private void newPointButton_Click(object sender, EventArgs e)
        {
            InputPointPanel inputPointPanel = new InputPointPanel(this);
            inputPointPanel.Show();
        }

        private void newLineButton_Click(object sender, EventArgs e)
        {
            InputLinePanel inputLinePanel = new InputLinePanel(this);
            inputLinePanel.Show();
        }

        private void newAngleButton_Click(object sender, EventArgs e)
        {
            InputAnglePanel inputAnglePanel = new InputAnglePanel(this);
            inputAnglePanel.Show();
        }

        private void objectInspectorButton_Click(object sender, EventArgs e)
        {
            ObjectInspectorPanel objectInspectorPanel = new ObjectInspectorPanel(this);
            objectInspectorPanel.Show();
        }

        private void createNewSceneButton_Click(object sender, EventArgs e)
        {
            createNewScene();
        }

        private void closeSceneButton_Click(object sender, EventArgs e)
        {           
            closeScene();
        }

        private void openSceneButton_Click(object sender, EventArgs e)
        {
            openScene();   
        }

        private void saveSceneButton_Click(object sender, EventArgs e)
        {
            saveScene();
        }

        private void anaglyphCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Set the value of the check box to the global variable, anaglyphToggled
            setAnaglyphToggled(anaglyphCheckBox.Checked);
            if (anaglyphCheckBox.Checked)
            {
                anaglyphLabel.Enabled = true;
                trackBarAnaglyph.Enabled = true;                
                setAnaglyphAdjust(trackBarAnaglyph.Value);                
            }
            else
            {
                anaglyphLabel.Enabled = false;
                trackBarAnaglyph.Enabled = false;
            }
        }

        private void trackBarAnaglyph_ValueChanged(object sender, EventArgs e)
        {
            setAnaglyphAdjust(trackBarAnaglyph.Value);
        }                              

        private void saveScene()
        {
            //Open the windows save file window
            saveFileDialog.ShowDialog();
            string filePath = saveFileDialog.FileName;
            
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            //Remove all previous data from file
            File.WriteAllText(filePath, string.Empty);

            string delimiter = ",";

            List<string[]> outputList = new List<string[]>();

            //Take each object and convert it into a line which is ready to be written into the file
            foreach (Point p in pointsInScene)
            {
                string x = p.rawPoint.x.ToString();
                string y = p.rawPoint.y.ToString();
                string z = p.rawPoint.z.ToString();
                string colorX = p.rawColor.x.ToString();
                string colorY = p.rawColor.y.ToString();
                string colorZ = p.rawColor.z.ToString();

                string[] line = {"point", x, y, z, colorX, colorY, colorZ };
                outputList.Add(line);
            }
            outputList.Add(new string[] { "" });
            foreach (Line l in linesInScene)
            {                
                string fx = l.rawFirstPoint.x.ToString();
                string fy = l.rawFirstPoint.y.ToString();
                string fz = l.rawFirstPoint.z.ToString();
                string sx = l.rawSecondPoint.x.ToString();
                string sy = l.rawSecondPoint.y.ToString();
                string sz = l.rawSecondPoint.z.ToString();
                string colorX = l.rawColor.x.ToString();
                string colorY = l.rawColor.y.ToString();
                string colorZ = l.rawColor.z.ToString();

                string[] line = {"line", fx, fy, fz, sx, sy, sz, colorX, colorY, colorZ };
                outputList.Add(line);
            }
            outputList.Add(new string[] { "" });
            foreach( Angle a in anglesInScene)
			{
				string f1x = a.Line1.rawFirstPoint.x.ToString();
				string f1y = a.Line1.rawFirstPoint.y.ToString();
				string f1z = a.Line1.rawFirstPoint.z.ToString();
				string s1x = a.Line1.rawSecondPoint.x.ToString();
				string s1y = a.Line1.rawSecondPoint.y.ToString();
				string s1z = a.Line1.rawSecondPoint.z.ToString();
				
				string f2x = a.Line2.rawFirstPoint.x.ToString();
				string f2y = a.Line2.rawFirstPoint.y.ToString();
				string f2z = a.Line2.rawFirstPoint.z.ToString();
				string s2x = a.Line2.rawSecondPoint.x.ToString();
				string s2y = a.Line2.rawSecondPoint.y.ToString();
				string s2z = a.Line2.rawSecondPoint.z.ToString();
				
				string colorX = a.rawColor.x.ToString();
				string colorY = a.rawColor.y.ToString();
				string colorZ = a.rawColor.z.ToString();
				
				string[] line = {"angle", f1x, f1y, f1z, s1x, s1y, s1z, f2x, f2y, f2z, s2x, s2y, s2z, colorX, colorY, colorZ };
				outputList.Add(line);
			}

            //Convert the lines into a table of all lines
            string[][] output = outputList.ToArray();

            //Get the max number of elements in a row
            int length = output.GetLength(0);
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < length; index++)
            {
                //Join every element with a comma (required for the csv file)
                sb.AppendLine(string.Join(delimiter, output[index]));
            }
            
            //Write all data from the StringBuilder to the file
            File.AppendAllText(filePath, sb.ToString());
        }

        public void openScene()
        {            
            //Show the windows open file window
            openFileDialog.ShowDialog();                                                 
        }

        //Called when the user has selected a valid file in the open file window
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //Get the file selected by the user in the open file window
            string filename = openFileDialog.FileName;

            string[] lines = new string[] { };

            try
            {
                //Attempt to read in all data from the file
                var reader = new StreamReader(File.OpenRead(filename));
                lines = File.ReadAllLines(filename);       
         
                //If all data is successfully read, create a new scene
                createNewScene();
            }
            catch
            {
                //If there is a problem in reading the file, show an error message
                MessageBox.Show("Invalid File");
            }


            foreach (string s in lines)
            {
                //Create an array of values by separating values where a comma exists
                string[] data = s.Split(',');

                if (data[0] == "point")
                {
                    //Attempt to read in point data
                    try
                    {
                        float x = float.Parse(data[1]);
                        float y = float.Parse(data[2]);
                        float z = float.Parse(data[3]);
                        float cx = float.Parse(data[4]);
                        float cy = float.Parse(data[5]);
                        float cz = float.Parse(data[6]);

                        Vector3 point = new Vector3(x, y, z);
                        Vector3 color = new Vector3(cx, cy, cz);
                        Vector3[] passedData = new Vector3[] { point, color };

                        //Pass the data to a global variable within input panel, which will be fetched by the scene
                        pointsToBeRenderedWithColor.Add(passedData);
                    }
                    catch
                    {
                        //If some data is invalid, don't read in that line of the file, but carry on with other lines
                        MessageBox.Show("Data could not be read from the file");
                    }
                }
                else if (data[0] == "line")
                {
                    //Attempt to read in line data
                    try
                    {
                        float fx = float.Parse(data[1]);
                        float fy = float.Parse(data[2]);
                        float fz = float.Parse(data[3]);
                        float sx = float.Parse(data[4]);
                        float sy = float.Parse(data[5]);
                        float sz = float.Parse(data[6]);
                        float cx = float.Parse(data[7]);
                        float cy = float.Parse(data[8]);
                        float cz = float.Parse(data[9]);

                        Vector3 firstPoint = new Vector3(fx, fy, fz);
                        Vector3 secondPoint = new Vector3(sx, sy, sz);
                        Vector3 color = new Vector3(cx, cy, cz);
                        Vector3[] passedData = new Vector3[] { firstPoint, secondPoint, color };
						
                        //If the first point on the line is the same as the second point on the line, show an error message and don't pass the data to the scene
						if(firstPoint == secondPoint)
						{
							MessageBox.Show("Invalid line found and could not be imported");
						}
						else
						{
							linesToBeRenderedWithColor.Add(passedData);
						}
                    }
                    catch
                    {
                        //If some data is invalid, don't read in that line of the file, but carry on with other lines
                        MessageBox.Show("Data could not be read from the file");
                    }
                }
				else if (data[0] == "angle")
				{
                    //Attempt to read in angle data
					try
					{					
						float f1x = float.Parse(data[1]);
						float f1y = float.Parse(data[2]);
						float f1z = float.Parse(data[3]);
						float s1x = float.Parse(data[4]);
						float s1y = float.Parse(data[5]);
						float s1z = float.Parse(data[6]);
						float f2x = float.Parse(data[7]);
						float f2y = float.Parse(data[8]);
						float f2z = float.Parse(data[9]);
						float s2x = float.Parse(data[10]);
						float s2y = float.Parse(data[11]);
						float s2z = float.Parse(data[12]);
						float cx = float.Parse(data[13]);
						float cy = float.Parse(data[14]);
						float cz = float.Parse(data[15]);
						
						Vector3 f1 = new Vector3(f1x, f1y, f1z);
						Vector3 s1 = new Vector3(s1x, s1y, s1z);
						Vector3 f2 = new Vector3(f2x, f2y, f2z);
						Vector3 s2 = new Vector3(s2x, s2y, s2z);
						Vector3 c = new Vector3(cx, cy, cz);
                        
                        //Make sure the two lines aren't the same, and make sure the two lines are both valid (the first and second point on each line are not the same)
                        if (((f1 == f2) && (s1 == s2)) || ((s1 == f2) && (s2 == f1)) || (f1 == s1) || (f2 == s2))
                        {
                            MessageBox.Show("Invalid angle found and could not be imported");
                        }
                        else
                        {
                            //Pass the data to the input panel, where it will be fetched by the scene
                            anglesToBeRenderedWithColor.Add(new Vector3[] { f1, s1, f2, s2, c });
                        }
					}
					catch
					{
                        //If some data is invalid, don't read in that line of the file, but carry on with other lines
						MessageBox.Show("Data could not be read from the file");
					}				
				}
            }
        }                                           
                
        private void InputPanel_Closing(object sender, EventArgs e)
        {            
            //Close the sceneThread, if it is running
            try
            {
                sceneThread.Abort();
            }
            catch { }
            //Make sure the whole application closes
            Application.Exit();
        }

        
    }
}
