using Rovers.Dal.Abstract;
using Rovers.Data.Concreat;
using Rovers.Entity;
using Rovers.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Dal.Concreate
{
    public class RoversDal : Repository<RoversEntity>, IRoversDal
    {
        public RoversDal(RoversContext context) : base(context)
        { }
    }
}
