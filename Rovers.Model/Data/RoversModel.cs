using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Rovers.Model.Data
{
    public class RoversModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string WAY { get; set; }
        public string ROVER_DIRECTIVE { get; set; }
        public RoversModel()
        {

        }
        public RoversModel(int x,int y, string way, string roverDirective)
        {
            X = x;
            Y = y;
            WAY = way;
            ROVER_DIRECTIVE = roverDirective;
        }
    }
}
