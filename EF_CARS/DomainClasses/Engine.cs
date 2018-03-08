using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Engine
    {
        public Engine()
            {
            Cylinders = 0;
            Power = 0;
            Liters = 0;
            }
        public Engine(int cylinders, int power, float liters)
        {
            Cylinders = cylinders;
            Power = power;
            Liters = liters;
        }
        public int Id { get; set; }
        public int Cylinders { get; set; }
        public int Power { get; set; }
        public float Liters { get; set; }

    }
}
