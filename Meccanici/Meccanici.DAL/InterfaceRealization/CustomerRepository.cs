using Meccanici.DAL.Interface;
using Meccanici.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meccanici.DAL.InterfaceRealization
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Список Клиентов
        /// </summary>
        private List<Person> customers;

        public void DeleteCustomer(Person customer)
        {
            DBConnection.instance.Delete(TABLE_NAME, $"PersonID = {customer.ID}");
            customers.Remove(customer);
        }
        public void NewCustomer(Person customer)
        {
            string values = "'" + customer.Name + "','" + customer.Surname + "','" + customer.Email + "','" + customer.Phone + "',0";
            DBConnection.instance.InsertInto(TABLE_NAME, "Name,Surname,Email,Phone,IsMechanic", values);
            customers.Add(customer);
        }

        public void UpdateCustomer(Person customer)
        {
            Person customerToUpdate = customers.Where(x => x.ID == customer.ID && x.IsDelete==false).FirstOrDefault();
            customerToUpdate = customer;
        }


        public List<Person> GetAllCustomers()
        {
            if (customers == null)
                LoadCustomers();
            return customers.Where(x => x.IsDelete == false).ToList();
        }

        public Person GetCustomerDetail(int customerID)
        {
            if (customers == null)
                LoadCustomers();
            return customers.Where(x => x.ID == customerID && x.IsDelete == false).FirstOrDefault();
        }

    

        /// <summary>
        /// Имя таблицы с данными
        /// </summary>
        private const string TABLE_NAME = "dbo.Person";

        /// <summary>
        /// Загрузить данные клиентов
        /// </summary>
        private void LoadCustomers()
        {
            customers = new List<Person>();
            var res = DBConnection.instance.ExecuteQuery(string.Format("SELECT * FROM {0} WHERE IsMechanic=0", TABLE_NAME));
            while (res.Read())
            {
                customers.Add(new Person()
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
