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
            DBConnection.instance.Delete(TABLE_NAME, $"PlateCode = {car.Targa}");
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
            Auto carToUpdate = cars.Where(x => x.Targa == car.Targa && x.IsDelete == false).FirstOrDefault();
            carToUpdate = car;
        }

        public List<Auto> GetAllCars()
        {
            if (cars == null)
                LoadCars();
            return cars.Where(x => x.IsDelete == false).ToList();
        }

        public Auto GetCarDetail(string carID)
        {
            if (cars == null)
                LoadCars();
            return cars.Where(x => x.Targa == carID && x.IsDelete == false).FirstOrDefault();
        }

        public List<Auto> GetCustomerCars(int custID)
        {
            if (cars == null)
                LoadCars();
            return cars.Where(x => x.ID_Cliente == custID && x.IsDelete == false).ToList();
        }

      
        /// <summary>
        /// Имя таблицы с данными
        /// </summary>
        private const string TABLE_NAME = "dbo.Car";

        /// <summary>
        /// Загрузить машины из таблицы
        /// </summary>
        private void LoadCars()
        {
            cars = new List<Auto>();
            var res = DBConnection.instance.ExecuteQuery("SELECT * FROM " + TABLE_NAME);
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
                    ID_Cliente = (int)res["Owner_ID"],
                    IsDelete = (bool)res["IsDelete"]
                });
            }
            res.Close();
        }
    }
}
