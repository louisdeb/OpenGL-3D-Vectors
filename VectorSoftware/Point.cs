using System;
using System.Collections.Generic;
using Tao.FreeGlut;
using OpenGL;

namespace VectorSoftware
{    
    public class Point : ColoredObject
    {
        public VBO<Vector3> point;                
        public Vector3 rawPoint;
        
        public string firstPoint;
        public string colorString;

        public Point(float x, float y, float z, Vector3 c)
        {
            //Initialise elements for the point
            elements = new VBO<int>(new int[] { 0 }, BufferTarget.ElementArrayBuffer);  
       
            point = new VBO<Vector3>(new Vector3[] { new Vector3(x, y, z) });
            color = new VBO<Vector3>(new Vector3[] { c });

            //Store raw data about the point
            rawColor = c;
            rawPoint = new Vector3(x, y, z);            

            firstPoint = x.ToString() + "," + y.ToString() + "," + z.ToString();           
                
            //Find the appropriate name of the points colour
            int index = colors.IndexOf(rawColor);
            if (index > -1)
            {
                colorString = colorStrings[index];
            }
        }        
    }
}
