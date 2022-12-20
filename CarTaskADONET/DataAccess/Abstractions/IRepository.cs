﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTaskADONET.DataAccess.Abstractions
{
    public interface IRepository<T>
    {

        IEnumerable<T> GetAll();
        void AddData(T data);
        void DeleteData(int id);
        T Get(int id);
        void Update(T data);


    }
}
