using Rovers.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revors.Bus.Abstract
{
    public interface IRevorsBus
    {
        bool InsertRovers(RoversEntity data);
        bool GetActiveRecordRovers();
        bool UpdateRoversStatus();
    }
}
