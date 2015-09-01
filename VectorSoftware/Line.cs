using System;
using System.Collections.Generic;
using Tao.FreeGlut;
using OpenGL;


namespace VectorSoftware
{
    public class Line : ColoredObject
    {
        public VBO<Vector3> line;
        public Vector3 rawFirstPoint;
        public Vector3 rawSecondPoint;        
        
        public string firstPoint;
        public string secondPoint;
        public string colorString;

        public Line(float ox, float oy, float oz, float fx, float fy, float fz, Vector3 c)
        {
            //Initialises elements for the line
            elements = new VBO<int>(new int[] { 0, 1 }, BufferTarget.ElementArrayBuffer);

            line = new VBO<Vector3>(new Vector3[] { new Vector3(ox, oy, oz), new Vector3(fx, fy, fz) });              
            color = new VBO<Vector3>(new Vector3[] { c, c });

            //Stores raw data about the line
            rawColor = c;
            rawFirstPoint = new Vector3(ox, oy, oz);
            rawSecondPoint = new Vector3(fx, fy, fz);

            firstPoint = ox.ToString() + "," + oy.ToString() + "," + oz.ToString();
            secondPoint = fx.ToString() + "," + fy.ToString() + "," + fz.ToString();

            //Find the appropriate name of the lines colour
            int index = colors.IndexOf(rawColor);
            if (index > -1)
            {
                colorString = colorStrings[index];
            }
        }
    }
}
