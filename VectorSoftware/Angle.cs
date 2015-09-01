using System;
using Tao.FreeGlut;
using OpenGL;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VectorSoftware
{
    public class Angle : ColoredObject
    {
        public Line Line1;
        public Line Line2;

        public Vector3 point1;
        public Vector3 point2;
        public VBO<Vector3> line;                

        public string firstLine;
        public string secondLine;

        public string colorString;

        public Angle(Line l1, Line l2, Vector3 c)
        {
            //Initialises elements for the angle
            elements = new VBO<int>(new int[] { 0, 1 }, BufferTarget.ElementArrayBuffer);

            Line1 = l1; //Line1 is bottom line            
            Line2 = l2; //Line2 is top line
            
            rawColor = c;

            color = new VBO<Vector3>(new Vector3[] { c, c });
          
            //Calculate normalised direction
            Vector3 direction = NormalizedDirection(Line1);            

            //Calculate the amount the line needs to be travelled down to find the first point of the line
            Vector3 step = new Vector3(direction.x * 0.2, direction.y * 0.2, direction.z * 0.2);

            //Calculate the point 'step' distance down the line
            point1 = Line1.rawFirstPoint + step;
            
            //Repeat the above process for the second line
            direction = NormalizedDirection(Line2);
            step = new Vector3(direction.x * 0.2, direction.y * 0.2, direction.z * 0.2);
            point2 = Line2.rawFirstPoint + step;

            line = new VBO<Vector3>(new Vector3[] { point1, point2 });

            firstLine = "( " + Line1.firstPoint + " ) , ( " + Line1.secondPoint + " )";
            secondLine = "( " + Line2.firstPoint + " ) , ( " + Line2.secondPoint + " )";
                        
            int index = colors.IndexOf(rawColor);
            if (index > -1)
            {
                colorString = colorStrings[index];
            }            
        }        

        private Vector3 NormalizedDirection(Line l)
        {
            //Find the direction vector of the line
            Vector3 direction = l.rawSecondPoint - l.rawFirstPoint;            

            //Find the modulus of the line
            double mod = Mod(direction);

            //Calculate the unit vector
            float x = direction.x / (float)mod;
            float y = direction.y / (float)mod;
            float z = direction.z / (float)mod;

            return new Vector3(x, y, z);
        }       
        
        private double Mod(Vector3 dVector)
        {
            //Calculate the modulus of the line
            double mod = Math.Sqrt(Math.Pow(dVector.x, 2) + Math.Pow(dVector.y, 2) + Math.Pow(dVector.z, 2));
            return mod;
        }
    }
}
