using CarTaskADONET.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTaskADONET.DataAccess.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICarRepository CarRepository => new CarRepository();
    }
}
