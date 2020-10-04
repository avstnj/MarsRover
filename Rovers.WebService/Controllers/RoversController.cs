using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Revors.Bus.Abstract;
using Revors.Bus.Concreate;
using Revors.Bus.UnitOfWork;
using Rovers.Dal;
using Rovers.Dal.Abstract;
using Rovers.Dal.Concreate;
using Rovers.Entity;
using Rovers.Model;
using Rovers.Model.Data;


namespace Rovers.WebService.Controllers
{
    [Route("api/[controller]")]
    public class RoversController : Controller
    {
        IUnitOfWork uow;
        public RoversController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [HttpPost]
        public RoversModel InsertRovers([FromBody]RoversModel roversModel)
        {
            RoversEntity roversEntity = RoversProcess.GetRoversEntity(roversModel);
            #region Bir Rovers cihazının işi bitmeden diğeri başlamaması için Aktiflik kontrolü koyduk. Rovers Cihazının işi bitene kadar Aktif olduğunun kaydını tutuyoruz. Bu süre zarfında başka bir cihaz geldiğinde Aktif olan başka bir cihaz olduğu için işlem yapamayacaktır. Aktif olan cihazın işlemi bittiğinde pasife çekiliyor...
            bool result = uow.RevorsBus.GetActiveRecordRovers();
            if (result)
            {
                uow.RevorsBus.InsertRovers(roversEntity);
                uow.SaveChanges();
            }
            else
            {
                RoversModel roversModelResult = null;
                return roversModelResult;
            }
            #endregion

            RoversModel re = RoversProcess.GetRoverResult(roversModel);
            uow.RevorsBus.UpdateRoversStatus();
            return re;
        }
    }
}