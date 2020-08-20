using Meccanici.DAL.Interface;
using Meccanici.Model;
using System.Collections.Generic;
using System.Linq;

namespace Meccanici.DAL.InterfaceRealization
{
    /// <summary>
    /// Хранилище машин
    /// </summary>
    public class CarRepository : ICarRepository
    {
        /// <summary>
        /// Список машин
        /// </summary>
        private List<Auto> cars;

        public void DeleteCar(Auto car)
        {
            cars.Remove(car);
        }
        public void NewCar(Auto car)
        {
            if (car != null && cars != null)
            {
                string values = "'" + car.Marca + "','" + car.Modello + "'," + car.Anno + ",'" + car.Targa + "'," + car.ID_Cliente;
                DBConnection.instance.InsertInto(TABLE_NAME, "Marca,Modello,Anno,PlateCode,Owner_ID", values);
                cars.Add(car);
            }
        }

        public void UpdateCar(Auto car)
        {
            Auto carToUpdate = cars.Where(x => x.Targa == car.Targa).FirstOrDefault();
            carToUpdate = car;
        }

        public List<Auto> GetAllCars()
        {
            if (cars == null)
                LoadCars();
            return cars;
        }

        public Auto GetCarDetail(string carID)
        {
            if (cars == null)
                LoadCars();
            return cars.Where(x => x.Targa == carID).FirstOrDefault();
        }

        public List<Auto> GetCustomerCars(int custID)
        {
            if (cars == null)
                LoadCars();
            return cars.Where(x => x.ID_Cliente == custID).ToList();
        }

      
        /// <summary>
        /// Имя таблицы с данными
        /// </summary>
        private const string TABLE_NAME = "Car";

        /// <summary>
        /// Загрузить машины из таблицы
        /// </summary>
        private void LoadCars()
        {
            cars = new List<Auto>();
            var res = DBConnection.instance.ExecuteQuery("SELECT * FROM " + TABLE_NAME).Result;
            while (res.Read())
            {
                cars.Add(new Auto()
                {
                    Marca = (string)res["Marca"],
                    Modello = (string)res["Modello"],
                    Anno = (int)res["Anno"],
                    //номерной знак Plate code
                    Targa = (string)res["PlateCode"],
                    //id Владелеца
                    ID_Cliente = (int)res["Owner_ID"]
                });
            }
            res.Close();
        }
    }
}
