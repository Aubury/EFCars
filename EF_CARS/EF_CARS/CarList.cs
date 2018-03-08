using DomainClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CARS
{
   public class CarList
    {
       private readonly SqlConnection connection;
       public List<Car> CarsList { get; set; }
     
        public CarList()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDbConnectionString"].ConnectionString);
            CarsList = new List<Car>();
            string sql = @"Select   c.Id, c.Producer, c.Model, c.HighSpeed, c.BodyType, c.CarEngine_Id ,
                           e.Cylinders, e.Power, e.Liters
                           from Cars c join Engines e on c.CarEngine_Id=e.Id ";
            SqlCommand readCommand = new SqlCommand();
            readCommand.CommandText = sql;
            readCommand.Connection = connection;

            try
            {
                connection.Open();
                using (SqlDataReader rdr = readCommand.ExecuteReader())
                {

                    Car car = null;
                   
                    while (rdr.Read())
                    {

                        car = new Car()
                        {

                            Producer = rdr["Producer"].ToString(),
                            Model = rdr["Model"].ToString(),                         
                            HighSpeed = (int)rdr["HighSpeed"],
                            BodyType = rdr["BodyType"].ToString(),
                            CarEngine = new Engine()
                                {
                                  Cylinders = (int)rdr["Cylinders"],
                                  Power = (int)rdr["Power"],
                                  Liters = (float)rdr["Liters"]
                                }

                            };

                        CarsList.Add(car);
                      
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                connection.Close();
            }
           
        }
     public void Show()
       {
            foreach(var i in CarsList)
                {
                Console.WriteLine("Model: {0} \n\t\tProducer: {1} ,\n\t\tHighSpeed: {2} ,\n\t\tCarEngine: (cylinders:{3} ; power: {4}; liters: {5}f) ,\n\t\tBodyType: {6}\n", i.Model, i.Producer, i.HighSpeed, i.CarEngine.Cylinders, i.CarEngine.Power, i.CarEngine.Liters, i.BodyType);
                }
        }
        public void Linq_select_Cylinders()
            {
            //var select_list = new List<Car>();
            //foreach (var s in CarsList)
            //{
            //    if (s.CarEngine.Cylinders == 6)
            //        select_list.Add(s);

            //}
            //-------------------------------------------------------------------------------------------
            //var select_list = from  s in CarsList
            //                  where s.CarEngine.Cylinders == 6
            //                  orderby s.HighSpeed
            //                  select s;
            //---------------------------------------------------------------------------------------------

            var select_list = CarsList.Where(s => s.CarEngine.Cylinders == 6).OrderBy(s => s.HighSpeed).Select(s => s);

            foreach(var s in select_list)
                {
                Console.WriteLine("Model: {0} \n\t\tProducer: {1} ,\n\t\tHighSpeed: {2} ,\n\t\tCarEngine: (cylinders:{3} ; power: {4}; liters: {5}f) ,\n\t\tBodyType: {6}\n", s.Model, s.Producer, s.HighSpeed, s.CarEngine.Cylinders, s.CarEngine.Power, s.CarEngine.Liters, s.BodyType);
                }
            }
        public void Linq_Sort_Liters_Model()
            {
            //var select_list = from s in CarsList
            //                  orderby s.CarEngine.Liters
            //                  select s;
            //---------------------------------------------------------------------------------------------------------------------
            var select_list = CarsList.OrderBy(s => s.CarEngine.Liters).ThenBy(s => s.Model).Select(s => s);

            foreach(var s in select_list)
                {
                Console.WriteLine("Model: {0} , CarEngine: (cylinders:{1} ; power: {2}; liters: {3}f) \n", s.Model, s.CarEngine.Cylinders, s.CarEngine.Power, s.CarEngine.Liters);

                }
            }
        public void Linq_Sort_Power_Liters()
            {
            //var select_list = from s in CarsList
            //                  orderby s.CarEngine.Power / s.CarEngine.Liters
            //                  select s;
            //---------------------------------------------------------------------------------------------------------------
            var select_list = CarsList.OrderBy(s => s.CarEngine.Power / s.CarEngine.Liters).Select(s => s);
            foreach(var s in select_list)
                {
                Console.WriteLine("Model: {0} , CarEngine: (power: {2} / liters: {3}f = {4}) \n", s.Model, s.CarEngine.Cylinders, s.CarEngine.Power, s.CarEngine.Liters, s.CarEngine.Power / s.CarEngine.Liters);

                }
            }
        public void Linq_OrderByDescending()
            {
            //var select_list = from s in CarsList
            //                  orderby s.Model descending
            //                  select s;
            //--------------------------------------------------------------------------------------------------------------
            var select_list = CarsList.OrderByDescending(s => s.Model).Select(s => s);

            foreach(var s in select_list)
                {
                Console.WriteLine("Model: {0}", s.Model);
                }

            }


        }
    }

