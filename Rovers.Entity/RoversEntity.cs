using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Rovers.Entity
{
    public class RoversEntity : Base
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string WAY { get; set; }
        public string ROVER_DIRECTIVE { get; set; }
        [DefaultValue(false)]
        public bool IS_ACTIVE { get; set; }
    }
}
