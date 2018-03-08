using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DataModel;
using DomainClasses;
using System.Data.SqlClient;

namespace EF_CARS
{
    public class Cars
    {
        
        public void Insert_Car(string producer, string model, int highSpeed, string bodyType, Engine engine)
        {
            var car = new Car(producer, model, highSpeed, bodyType, engine) {};
            
           using (var context = new CarContextcs())
            {
                context.Database.Log = Console.WriteLine;
                context.Cars.Add(car);
                context.SaveChanges();

            }
          
        }
      
    }
}

