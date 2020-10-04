using Revors.Bus.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revors.Bus.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRevorsBus RevorsBus { get;}
        bool SaveChanges();
    }
}
