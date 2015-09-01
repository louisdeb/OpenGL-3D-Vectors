using System;
using System.Collections.Generic;
using Tao.FreeGlut;
using OpenGL;

namespace VectorSoftware
{
    public abstract class ColoredObject
    {
        public VBO<Vector3> color;
        public Vector3 rawColor;

        public VBO<int> elements;

        //The list of colours a ColoredObject can take
        protected List<Vector3> colors = new List<Vector3> 
        {             
            new Vector3(1, 0.5f, 0),
            new Vector3(1, 1, 0),
            new Vector3(0.5f, 1, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 1, 0.5f),            
            new Vector3(0, 0.5f, 1),
            new Vector3(0, 0, 1),
            new Vector3(0.5f, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(1, 0, 0.5f)        
        };

        //The names of each colour, in the same order as the list, colors
        protected List<string> colorStrings = new List<string>
        {            
            "Orange",
            "Yellow",
            "Lime",
            "Green",
            "Turquoise",            
            "Light Blue",
            "Blue",
            "Purple",
            "Pink",
            "Magenta"                        
        };
    }
}
