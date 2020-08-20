using Meccanici.DAL.Interface;
using Meccanici.Model;
using System.Collections.Generic;
using System.Linq;

namespace Meccanici.DAL.InterfaceRealization
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Список Клиентов
        /// </summary>
        private static List<Person> customers;

        public void DeleteCustomer(Person customer)
        {
            customers.Remove(customer);
        }
        public void NewCustomer(Person customer)
        {
            string values = "'" + customer.Name + "','" + customer.Surname + "','" + customer.Email + "','" + customer.Phone + "'";
            DBConnection.instance.InsertInto(TABLE_NAME, "Name,Surname,Email,Phone", values);
            customers.Add(customer);
        }

        public void UpdateCustomer(Person customer)
        {
            Person customerToUpdate = customers.Where(x => x.ID == customer.ID).FirstOrDefault();
            customerToUpdate = customer;
        }


        public List<Person> GetAllCustomers()
        {
            if (customers == null)
                LoadCustomers();
            return customers;
        }

        public Person GetCustomerDetail(int customerID)
        {
            if (customers == null)
                LoadCustomers();
            return customers.Where(x => x.ID == customerID).FirstOrDefault();
        }

    

        /// <summary>
        /// Имя таблицы с данными
        /// </summary>
        private const string TABLE_NAME = "person";

        /// <summary>
        /// Загрузить данные клиентов
        /// </summary>
        private void LoadCustomers()
        {
            customers = new List<Person>();
            var res = DBConnection.instance.ExecuteQuery(string.Format("SELECT * FROM {0} WHERE IsMechanic=0", TABLE_NAME)).Result;
            while (res.Read())
            {
                customers.Add(new Person()
                {
                    ID = (int)res["PersonID"],
                    Name = (string)res["Name"],
                    Surname = (string)res["Surname"],
                    Email = (string)res["Email"],
                    Phone = (string)res["Phone"]
                });
            }
            res.Close();
            //{
            //    new Person() { ID = 1, Name = "Gino", Surname = "Fantozzi" },
            //    new Person() { ID = 2, Name = "Elio", Surname = "Teso" },
            //    new Person() { ID = 3, Name = "Giovanni", Surname = "Murica" },
            //    new Person() { ID = 4, Name = "Walter", Surname = "White" },
            //    new Person() { ID = 5, Name = "Heisenberg", Surname = "Chef" }
            //};
        }
    }
}
