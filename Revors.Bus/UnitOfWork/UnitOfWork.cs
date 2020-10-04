using System;
using System.Collections.Generic;
using System.Text;
using Revors.Bus.Abstract;
using Revors.Bus.Concreate;
using Rovers.Dal.Concreate;

namespace Revors.Bus.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RoversContext context;
        public UnitOfWork(RoversContext _context)
        {
            context = _context;
        }
        private IRevorsBus roversBus;
        public IRevorsBus RevorsBus => roversBus ?? (roversBus = new RevorsBus(new RoversDal(context)));
        #region IDisposable Support

        public bool SaveChanges()
        {
            int result = context.SaveChanges();
            return result > 0 ? true : false;
        }
        #endregion
    }
}
