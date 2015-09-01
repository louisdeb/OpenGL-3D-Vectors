using System;
using System.Collections.Generic; //needed for lists
using System.Windows.Input;
using System.Windows.Forms;

using System.ComponentModel; //needed for binding list

using Tao.FreeGlut;
using OpenGL;

namespace VectorSoftware
{
    public class Scene
    {                       
        private InputPanel inputPanel;

        private int width = 1000, height = 500;
        private ShaderProgram program;                

        public List<Point> points = new List<Point>();
        public List<Line> lines = new List<Line>();
        public List<Angle> angles = new List<Angle>();   

        private Vector3[] colors = new Vector3[10];
        private List<Vector3> unusedColors = new List<Vector3>();

        private System.Diagnostics.Stopwatch watch;
        private float angleX = 0, angleY = 0, angleZ = 0;
        private float cameraX = 0, cameraY = 0, cameraZ = 0;

        private bool anaglyphToggled = false;        
        private Vector3 anaglyphCyan = new Vector3(0, 0.5, 0.5);
        private Vector3 anaglyphRed = new Vector3(1, 0, 0);                       

        public Scene(InputPanel ip)
        {       
            //Stops GLUT trying to re-initialise if it has already been initialised.
            int glutTime = Glut.glutGet(Glut.GLUT_ELAPSED_TIME);
            if (glutTime <= 0)
            {
                Glut.glutInit();
            }                                     

            //Initialises GLUT
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(width, height);                
            Glut.glutCreateWindow("Scene");

            Glut.glutSetOption(Glut.GLUT_ACTION_ON_WINDOW_CLOSE, 1);
            Glut.glutCloseFunc(closeFunc);

            Glut.glutIdleFunc(OnRenderFrame);

            Gl.Enable(EnableCap.Blend);
            
            //Creates the rendering ShaderProgram
            program = new ShaderProgram(VertexShader, FragmentShader);
            
            program.Use();
            program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
            resetCamera();                                        

            //Initialises colors            
            colors[0] = new Vector3(1, 0.5f, 0);
            colors[1] = new Vector3(1, 1, 0);
            colors[2] = new Vector3(0.5f, 1, 0);
            colors[3] = new Vector3(0, 1, 0);
            colors[4] = new Vector3(0, 1, 0.5f);            
            colors[5] = new Vector3(0, 0.5f, 1);
            colors[6] = new Vector3(0, 0, 1);
            colors[7] = new Vector3(0.5f, 0, 1);
            colors[8] = new Vector3(1, 0, 1);
            colors[9] = new Vector3(1, 0, 0.5f);           

            //Starts the Stopwatch
            watch = System.Diagnostics.Stopwatch.StartNew();

            inputPanel = ip;
            
            //Enters the main loop
            Glut.glutMainLoop();
        }        

        //The main loop
        private void OnRenderFrame()
        {            
            //Gets the change in time between the previous frame and the current frame
            watch.Stop();
            float deltaTime = (float)watch.ElapsedTicks / System.Diagnostics.Stopwatch.Frequency;
            watch.Restart();                                 

            //Checks for rotation key presses
            if (Keyboard.IsKeyDown(Key.NumPad8))
            {
                angleX += deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.NumPad2))
            {
                angleX -= deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.NumPad4))
            {
                angleY += deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.NumPad6))
            {
                angleY -= deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.NumPad7))
            {
                angleZ += deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.NumPad9))
            {
                angleZ -= deltaTime;
            }

            //Checks for translation key presses
            if (Keyboard.IsKeyDown(Key.Right))
            {
                cameraX += deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                cameraX -= deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                cameraY += deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
                cameraY -= deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.PageUp))
            {
                cameraZ += deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.PageDown))
            {
                cameraZ -= deltaTime;
            }

            //Checks for the reset key press
            if (Keyboard.IsKeyDown(Key.Home))
            {
                resetCamera();
            }                                   

            //Assigns the field of view to the size of the window (required for functionality with window resizing)
            Gl.Viewport(0, 0, Glut.glutGet(Glut.GLUT_WINDOW_WIDTH), Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT));
            
            //Clears the previous render frame's buffer
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            //Blends overlapping lines to aid anaglyph functionality
            Gl.BlendFunc(BlendingFactorSrc.OneMinusDstColor, BlendingFactorDest.DstColor);                                    

            //Inputs raw objects from inputPanel
            List<Vector3> inputtedPointsRaw = inputPanel.getPoints();                        
            foreach (Vector3 v in inputtedPointsRaw)
            {                
                Point p = new Point(v.x, v.y, v.z, getColor());
                points.Add(p);
            }

            List<Vector3[]> inputtedLinesRaw = inputPanel.getLines();
            foreach (Vector3[] v in inputtedLinesRaw)
            {                
                Line l = new Line(v[0].x, v[0].y, v[0].z, v[1].x, v[1].y, v[1].z, getColor());
                lines.Add(l);
            }

            List<Vector3[]> inputtedAnglesRaw = inputPanel.getAngles();
            foreach (Vector3[] v in inputtedAnglesRaw)
            {                
                //Make the colour any color in array of colors as they won't actually be rendered
                Line line1 = new Line(v[0].x, v[0].y, v[0].z, v[1].x, v[1].y, v[1].z, colors[0]);
                Line line2 = new Line(v[2].x, v[2].y, v[2].z, v[3].x, v[3].y, v[3].z, colors[0]);

                Angle a = new Angle(line1, line2, getColor());
                angles.Add(a);
            }

            //Inputs coloured objects from inputPanel
            List<Vector3[]> inputtedPoints = inputPanel.getPointsWithColor();
            foreach (Vector3[] v in inputtedPoints)
            {                                
                Point p = new Point(v[0].x, v[0].y, v[0].z, v[1]);
                points.Add(p);
            }

            List<Vector3[]> inputtedLines = inputPanel.getLinesWithColor();
            foreach (Vector3[] v in inputtedLines)
            {                
                Line l = new Line(v[0].x, v[0].y, v[0].z, v[1].x, v[1].y, v[1].z, v[2]);
                lines.Add(l);
            }

            List<Vector3[]> inputtedAngles = inputPanel.getAnglesWithColor();
            foreach (Vector3[] v in inputtedAngles)
            {   
                //Make the colour any color in array of colors as they won't actually be rendered
                Line line1 = new Line(v[0].x, v[0].y, v[0].z, v[1].x, v[1].y, v[1].z, colors[0]);
                Line line2 = new Line(v[2].x, v[2].y, v[2].z, v[3].x, v[3].y, v[3].z, colors[0]);

                Angle a = new Angle(line1, line2, v[4]);
                angles.Add(a);
            }

            //Checks for objects to be deleted
            if (inputPanel.pointToBeDeleted != null)
            {
                Point pointToBeDeleted = inputPanel.pointToBeDeleted;
                if(points.Contains(pointToBeDeleted))
                {
                    //Delete point
                    points.Remove(pointToBeDeleted);                    
                }
                inputPanel.pointToBeDeleted = null;
            }

            if (inputPanel.lineToBeDeleted != null)
            {
                Line lineToBeDeleted = inputPanel.lineToBeDeleted;
                if (lines.Contains(lineToBeDeleted))
                {
                    //Delete line
                    lines.Remove(lineToBeDeleted);
                }
                inputPanel.lineToBeDeleted = null;
            }

            if (inputPanel.angleToBeDeleted != null)
            {
                Angle angleToBeDeleted = inputPanel.angleToBeDeleted;
                if (angles.Contains(angleToBeDeleted))
                {
                    //Delete angle
                    angles.Remove(angleToBeDeleted);
                }
                inputPanel.angleToBeDeleted = null;
            }

            //Checks for object with a colour change request from the user
            object colorChangeObject = inputPanel.getColorChangeObject();
            if (colorChangeObject != null)
            {
                //Gets the new colour
                Vector3 newColor = inputPanel.getNewColor();

                if (colorChangeObject is Point)
                {
                    Point p = (Point)colorChangeObject;
                    if (points.Contains(p))
                    {
                        points.Remove(p);
                        p = new Point(p.rawPoint.x, p.rawPoint.y, p.rawPoint.z, newColor);
                        points.Add(p);
                    }                                        
                }
                else if (colorChangeObject is Line)
                {
                    Line l = (Line)colorChangeObject;
                    if (lines.Contains(l))
                    {
                        lines.Remove(l);
                        l = new Line(l.rawFirstPoint.x, l.rawFirstPoint.y, l.rawFirstPoint.z, l.rawSecondPoint.x, l.rawSecondPoint.y, l.rawSecondPoint.z, newColor);
                        lines.Add(l);
                    }
                }
                else if (colorChangeObject is Angle)
                {
                    Angle a = (Angle)colorChangeObject;
                    if (angles.Contains(a))
                    {
                        angles.Remove(a);
                        a = new Angle(a.Line1, a.Line2, newColor);
                        angles.Add(a);
                    }
                }
            }                               
            
            //Pass current objects in scene to the inputPanel
            inputPanel.setPointsInScene(points);
            inputPanel.setLinesInScene(lines);
            inputPanel.setAnglesInScene(angles);            
                      
            //Gets whether the anaglyph should be rendered or not
            anaglyphToggled = inputPanel.getAnaglyphToggled();
            if (anaglyphToggled)
            {                
                //Renders anaglyph

                //Calculates camera coordinates based upon position and angle
                Vector3 cameraPos = new Vector3(cameraX - (Math.Sin(angleY) * (10 - cameraZ )), cameraY + (Math.Sin(angleX) * (10 - cameraZ)), (10 - cameraZ));                

                //Calculates the interocularDistance
                double convergenceDepth = 10;                
                double interocularDistance = ((convergenceDepth / 2) + (double)inputPanel.getAnaglyphAdjust()) / 30;                

                //Calculates positions of each eye
                Vector3 leftEye = new Vector3(cameraPos.x - interocularDistance, cameraPos.y, cameraPos.z);
                Vector3 rightEye = new Vector3(cameraPos.x + interocularDistance, cameraPos.y, cameraPos.z);

                Vector3 leftPoint;
                Vector3 rightPoint;                               

                //Calculates and renders every object in the anaglyph
                foreach (Point p in points)
                {
                    leftPoint = calculateAnaglyphPoint(p.rawPoint, leftEye);
                    rightPoint = calculateAnaglyphPoint(p.rawPoint, rightEye);          
                                        
                    drawPoint(new Point(leftPoint.x, leftPoint.y, leftPoint.z, anaglyphCyan));
                    drawPoint(new Point(rightPoint.x, rightPoint.y, rightPoint.z, anaglyphRed));
                }

                foreach (Line l in lines)
                {
                    leftPoint = calculateAnaglyphPoint(l.rawFirstPoint, leftEye);
                    rightPoint = calculateAnaglyphPoint(l.rawSecondPoint, leftEye);

                    Line leftLine = new Line(leftPoint.x, leftPoint.y, leftPoint.z, rightPoint.x, rightPoint.y, rightPoint.z, anaglyphCyan);

                    leftPoint = calculateAnaglyphPoint(l.rawFirstPoint, rightEye);
                    rightPoint = calculateAnaglyphPoint(l.rawSecondPoint, rightEye);

                    Line rightLine = new Line(leftPoint.x, leftPoint.y, leftPoint.z, rightPoint.x, rightPoint.y, rightPoint.z, anaglyphRed);

                    drawLine(leftLine);
                    drawLine(rightLine);
                }
                foreach (Angle a in angles)
                {
                    leftPoint = calculateAnaglyphPoint(a.point1, leftEye);
                    rightPoint = calculateAnaglyphPoint(a.point2, leftEye);

                    Line leftLine = new Line(leftPoint.x, leftPoint.y, leftPoint.z, rightPoint.x, rightPoint.y, rightPoint.z, anaglyphCyan);

                    leftPoint = calculateAnaglyphPoint(a.point1, rightEye);
                    rightPoint = calculateAnaglyphPoint(a.point2, rightEye);

                    Line rightLine = new Line(leftPoint.x, leftPoint.y, leftPoint.z, rightPoint.x, rightPoint.y, rightPoint.z, anaglyphRed);

                    drawLine(leftLine);
                    drawLine(rightLine);
                }
            }                        

            //Makes sure every colour is rendered
            Gl.ColorMask(true, true, true, true);

            //Draws every object is the anaglyph is not being rendered
            if (!anaglyphToggled)
            {
                foreach (Point p in points)
                {
                    drawPoint(p);
                }

                foreach (Line l in lines)
                {
                    drawLine(l);
                }

                foreach (Angle a in angles)
                {
                    drawAngle(a);
                }
            }                               
        
            //Adjusts camera position based on inputs this frame
            program["view_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0, 0, cameraZ)) * Matrix4.CreateRotationX(angleX) * Matrix4.CreateRotationY(angleY) * Matrix4.CreateRotationZ(angleZ) * Matrix4.LookAt(new Vector3(0, 0, 10), new Vector3(cameraX, cameraY, 0), Vector3.Up));           

            //Swaps the render buffer to the other, pre-prepared one.
            Glut.glutSwapBuffers();                                  
        }

        private void closeFunc()
        {
            //Tells inputPanel that GLUT and the scene are closing
            inputPanel.closeScene();
            Glut.glutLeaveMainLoop();
        }                
        
        private string VertexShader = @"
in vec3 vertexPosition;
in vec3 vertexColor;

out vec3 color;

uniform mat4 projection_matrix;
uniform mat4 view_matrix;
uniform mat4 model_matrix;

void main(void)
{
    color = vertexColor;
    gl_Position = projection_matrix * view_matrix * model_matrix * vec4(vertexPosition, 1);
}
";

        private string FragmentShader = @"
in vec3 color;

out vec4 fragment;

void main(void)
{
    fragment = vec4(color, 1);
}
";        

        private void resetCamera()
        {
            //Resets the camera to its original position
            program["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(0, 0, 10), Vector3.Zero, Vector3.Up));
            angleX = 0;
            angleY = 0;
            angleZ = 0;
            cameraX = 0;
            cameraY = 0;
            cameraZ = 0;
        }        

        private Vector3 getColor()
        {            
            setUpUnusedColors();            
            
            //If there are unused colours, chose a random one and return it
            if (unusedColors.Count > 0)
            {
                Random r = new Random();
                int randInt = r.Next(0, unusedColors.Count - 1);
                return unusedColors[randInt];
            }
            //If there are no unused colours, chose a random colour from the original list and return it
            else
            {
                Random r = new Random();
                int randInt = r.Next(0, colors.Length - 1);
                return colors[randInt];
            }
        }       

        private void setUpUnusedColors()
        {            
            //Add every colour to unusedColors
            foreach (Vector3 c in colors)
            {
                if (!unusedColors.Contains(c))
                {
                    unusedColors.Add(c);
                }
            }

            //For each object, remove the object's colour from unusedColors
            foreach (Point p in points)
            {
                if (unusedColors.Contains(p.rawColor))
                {
                    unusedColors.Remove(p.rawColor);
                }
            }

            foreach (Line l in lines)
            {
                if (unusedColors.Contains(l.rawColor))
                {
                    unusedColors.Remove(l.rawColor);
                }                
            }

            foreach (Angle a in angles)
            {
                if (unusedColors.Contains(a.rawColor))
                {
                    unusedColors.Remove(a.rawColor);
                }
            }
        }                       
        
        //Uses similar triangles to calculate the point's anaglyph position
        private Vector3 calculateAnaglyphPoint(Vector3 point, Vector3 eye)
        {            
            //Find the distance between the point and the eye
            double vertexDepth = Math.Sqrt(
                Math.Pow(eye.x - point.x, 2) +
                Math.Pow(eye.y - point.y, 2) +
                Math.Pow(eye.z - point.z, 2));

            //Calculates the ratio between the point's distance to the origin, and the distance between the point and the eye
            double ratio = Math.Sqrt(
                Math.Pow(point.x, 2) + 
                Math.Pow(point.y, 2) + 
                Math.Pow(point.z, 2)) / vertexDepth;
            
            //Find the x coordinate of the anaglyph point
            double offsetX = point.x - eye.x;
            double parallaxX = ratio * offsetX;
            double actualX = eye.x + offsetX - parallaxX;

            //Find the y coordinate of the anaglyph point
            double offsetY = point.y - eye.y;
            double parallaxY = ratio * offsetY;
            double actualY = eye.y + offsetY - parallaxY;

            //Find the z coordinate of the anaglyph point
            double offsetZ = point.z - eye.z;
            double parallaxZ = ratio * offsetZ;
            double actualZ = eye.z + offsetZ - parallaxZ;                      

            return new Vector3(actualX, actualY, actualZ);
        }                

        //Resets the model matrix
        private void resetModelMatrix()
        {
            program["model_matrix"].SetValue(Matrix4.CreateTranslation(Vector3.Zero));
        }

        private void drawPoint(Point point)
        {            
            resetModelMatrix();

            //Assign the necessary buffers to information about the point
            Gl.BindBufferToShaderAttribute(point.point, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(point.color, program, "vertexColor");
            Gl.BindBuffer(point.elements);

            //Draw the point
            Gl.DrawElements(BeginMode.Points, point.elements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }        

        private void drawLine(Line line)
        {
            resetModelMatrix();

            //Assign the necessary buffers to information about the line
            Gl.BindBufferToShaderAttribute(line.line, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(line.color, program, "vertexColor");
            Gl.BindBuffer(line.elements);

            //Draw the line
            Gl.DrawElements(BeginMode.Lines, line.elements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        private void drawAngle(Angle angle)
        {
            resetModelMatrix();

            //Assign the necessary buffers to information about the angle
            Gl.BindBufferToShaderAttribute(angle.line, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(angle.color, program, "vertexColor");
            Gl.BindBuffer(angle.elements);

            //Draw the line
            Gl.DrawElements(BeginMode.Lines, angle.elements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }        
    }    
}