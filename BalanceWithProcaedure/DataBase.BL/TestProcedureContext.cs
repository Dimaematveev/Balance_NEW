namespace DataBase.BL
{
    using DataBase.BL.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TestProcedureContext : DbContext
    {
        // Your context has been configured to use a 'TestProcedure' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataBase.BL.TestProcedure' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TestProcedure' 
        // connection string in the application configuration file.
        public TestProcedureContext()
            : base("name=TestProcedure")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<TypeDevice> TypeDevices { get; set; }
    }

}