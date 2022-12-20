using CarTaskADONET.DataAccess.Abstractions;
using CarTaskADONET.DataAccess.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTaskADONET.DataAccess.Concretes
{
    public class CarRepository : ICarRepository
    {
        public string ConnectionString { get; set; }


        public CarRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        public void AddData(Car data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(int id)
        {
            throw new NotImplementedException();
        }

        public Car Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            using(var conn = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT * FROM Cars";
                var cars = conn.Query<Car>(sql).ToList();

                return cars;
            }
        }

        public void Update(Car data)
        {
            throw new NotImplementedException();
        }
    }
}
