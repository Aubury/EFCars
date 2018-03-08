using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Car
    {
        public Car()
            {
            Producer = null;
            Model = null;
            HighSpeed = 0;
            BodyType = null;
            CarEngine = null;
            }
        public Car(string producer, string model, int highSpeed, string bodyType, Engine engine)
        {
            Producer = producer;
            Model = model;
            HighSpeed = highSpeed;
            BodyType = bodyType;
            CarEngine = engine;
        }
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int HighSpeed { get; set; }
        public string BodyType { get; set; }

        public Engine CarEngine { get; set; }
    }
}
