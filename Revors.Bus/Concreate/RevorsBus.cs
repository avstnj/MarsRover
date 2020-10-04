using Revors.Bus.Abstract;
using Rovers.Dal.Abstract;
using Rovers.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Revors.Bus.Concreate
{
    public class RevorsBus : IRevorsBus
    {
        IRoversDal roversDal;
        public RevorsBus(IRoversDal _roversDal)
        {
            roversDal = _roversDal;
        }
        public bool InsertRovers(RoversEntity data)
        {
            bool result = roversDal.Add(data);
            return result;
        }
        public bool GetActiveRecordRovers()
        {
            RoversEntity result = (RoversEntity)roversDal.Get(x=>x.IS_ACTIVE==true).Result;
            if(result != null)
                return false; 
            else 
               return true;
        }

        public bool UpdateRoversStatus()
        {
            RoversEntity result = (RoversEntity)roversDal.Get(x => x.IS_ACTIVE == true).Result;
            result.IS_ACTIVE = false;
            return roversDal.Update(result);
        }
    }
}
