//Создать проект Cars.DomainClasses, содержащий классы предметной области Car и Engine
//(https://github.com/vasilymarchenko/ADO.Net/tree/master/Homework2)
//Создать проект модели данных Cars.DataModel.
//Подключить Entity Framework к проекту Cars.DataModel
//Используя Entity Framework, сформировать модели данных 
//(т.е.класс CarsContext, унаследованный от DbContext и DbSet-ы для классов Car и Engine)
//Настроить и настроить и выполнить миграцию модели данных в SQL Server.
//Используя Entity Framework, написать метод(ы), заполняющие тестовыми данными базу данных

using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CARS
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Cars car_1 = new Cars();
            // // car_1.Insert_Car("BMW", "X6", 280, "SUV", new Engine(8, 547, 4.4f));
            //  Cars car_2 = new Cars();
            //  //car_2.Insert_Car("Porsche", "Macan", 254, "SUV", new Engine(6, 340, 3.0f));
            //  Cars car_3 = new Cars();
            //  //car_3.Insert_Car("Ferrary", "458 Italia", 325, "Coupe", new Engine(8, 570, 4.8f));
            //  Cars car_4 = new Cars();
            // // car_4.Insert_Car("Nissan", "370Z", 300, "Coupe", new Engine(6, 336, 3.6f));
            //  Cars car_5 = new Cars();
            // // car_5.Insert_Car("Mitsubishi ", "Lancer Evolution", 240, "Sedan", new Engine(4, 276, 2.0f));
            //  Cars car_6 = new Cars();
            ////  car_6.Insert_Car("Subaru ", "WRX STI", 250, "Sedan", new Engine(4, 268, 2.0f));
 //============================================================================================================
            CarList list = new CarList();
            list.Show();
            Console.WriteLine("===============================================================");
            list.Linq_OrderByDescending();
            Console.WriteLine("===============================================================");
            list.Linq_select_Cylinders();
            Console.WriteLine("===============================================================");
            list.Linq_Sort_Liters_Model();
            Console.WriteLine("===============================================================");
            list.Linq_Sort_Power_Liters();
 //============================================================================================================
            Console.Read();
        }
    }
}
