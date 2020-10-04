using Rovers.Entity;
using Rovers.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers.WebService
{
    public static class RoversProcess
    {
        public static RoversModel GetRoverResult(RoversModel data)
        {
            RoversModel re = new RoversModel(data.X, data.Y, data.WAY,null);
            string roverDirectory = data.ROVER_DIRECTIVE;
            for (int i = 0; i < roverDirectory.Length; i++)
                Process(roverDirectory[i].ToString(),ref re);
            
            return re;
        }
        private static void Process(string roverDirectoryChar,ref RoversModel roversModel)
        {
            if (roverDirectoryChar =="L")
            {
                if (roversModel.WAY == "N")
                    roversModel.WAY = "W";
                else if(roversModel.WAY == "E")
                    roversModel.WAY = "N";
                else if (roversModel.WAY == "S")
                    roversModel.WAY = "E";
                else//(roversModel.WAY == "W")
                    roversModel.WAY = "S";
            }
            else if (roverDirectoryChar == "R")
            {
                if (roversModel.WAY == "N")
                    roversModel.WAY = "E";
                else if (roversModel.WAY == "E")
                    roversModel.WAY = "S";
                else if (roversModel.WAY == "S")
                    roversModel.WAY = "W";
                else//(WAY == "W")
                    roversModel.WAY = "N";
            }
            else if (roverDirectoryChar == "M")
            {
                if (roversModel.WAY == "N")
                    roversModel.Y = roversModel.Y + 1;
                else if (roversModel.WAY == "E")
                    roversModel.X = roversModel.X + 1;
                else if (roversModel.WAY == "S")
                    roversModel.Y = roversModel.Y - 1;
                else//(roversModel.WAY == "W")
                    roversModel.X = roversModel.X - 1;
            }
        }
        public static RoversEntity GetRoversEntity(RoversModel roversModel)
        {
            RoversEntity roversEntity = new RoversEntity();
            roversEntity.X = roversModel.X;
            roversEntity.Y = roversModel.Y;
            roversEntity.WAY = roversModel.WAY;
            roversEntity.ROVER_DIRECTIVE = roversModel.ROVER_DIRECTIVE;
            roversEntity.CREATE_DATE = DateTime.Now;
            roversEntity.IS_ACTIVE = true;
            return roversEntity;
        }
    }
    
}
