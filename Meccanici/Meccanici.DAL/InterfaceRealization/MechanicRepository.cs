using Meccanici.DAL.Interface;
using Meccanici.Model;
using System.Collections.Generic;
using System.Linq;

namespace Meccanici.DAL.InterfaceRealization
{
    /// <summary>
    /// Хранилище Механиков
    /// </summary>
    public class MechanicRepository : IMechanicRepository
    {
        /// <summary>
        /// Список механиков
        /// </summary>
        private List<Person> mechanics;

        public void DeleteMechanic(Person mechanic)
        {
            DBConnection.instance.Delete(TABLE_NAME, $"PersonID = {mechanic.ID}");
            mechanics.Remove(mechanic);
        }
        public void UpdateMechanic(Person mechanic)
        {
            Person mechanicToUpdate = mechanics.Where(x => x.ID == mechanic.ID).FirstOrDefault();
            mechanicToUpdate = mechanic;
        }

        public void NewEmployee(Person customer)
        {
            string values = "'" + customer.Name + "','" + customer.Surname + "','" + customer.Email + "','" + customer.Phone + "',1";
            DBConnection.instance.InsertInto(TABLE_NAME, "Name,Surname,Email,Phone,IsMechanic", values);
            mechanics.Add(customer);
        }

        public List<Person> GetAllMechanics()
        {
            if (mechanics == null)
                LoadMechanics();
            return mechanics.Where(x=>x.IsDelete==false).ToList();
        }

        public Person GetMechanicDetail(int mechanicID)
        {
            if (mechanics == null)
                LoadMechanics();
            return mechanics.Where(x => x.ID == mechanicID && x.IsDelete==false).FirstOrDefault();
        }


        /// <summary>
        /// Имя таблицы с данными
        /// </summary>
        private const string TABLE_NAME = "dbo.Person";
        /// <summary>
        /// Загрузить механиков из таблицы
        /// </summary>
        private void LoadMechanics()
        {
            //mechanics = new List<Person>()
            //{
            //    new Person() { ID=1, Name = "Horacio", Surname = "Pagani" },
            //    new Person() { ID = 2, Name = "Enzo", Surname = "Ferrari" }
            //};
            mechanics = new List<Person>();
            var res = DBConnection.instance.ExecuteQuery(string.Format("SELECT * FROM {0} WHERE IsMechanic=1", TABLE_NAME));
            while (res.Read())
            {
                mechanics.Add(new Person()
                {
                    ID = (int)res["PersonID"],
                    Name = (string)res["Name"],
                    Surname = (string)res["Surname"],
                    Email = (string)res["Email"],
                    Phone = (string)res["Phone"],
                    IsDelete = (bool)res["IsDelete"]
                });
            }
            res.Close();
        }
    }
}
