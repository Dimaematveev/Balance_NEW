namespace DataBase.BL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BalanceDB : DbContext
    {
        public BalanceDB()
            : base("name=BalanceDB")
        {
        }

        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Monitor> Monitors { get; set; }
        public virtual DbSet<Printer> Printers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Sp_Si> Sp_Si { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<View_Device> View_Device { get; set; }
        public virtual DbSet<View_Monitor> View_Monitor { get; set; }
        public virtual DbSet<View_Printer> View_Printer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>()
                .HasMany(e => e.Repairs)
                .WithRequired(e => e.Result)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Device>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Device)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Device>()
                .HasOptional(e => e.Monitor)
                .WithRequired(e => e.Device);

            modelBuilder.Entity<Device>()
                .HasOptional(e => e.Printer)
                .WithRequired(e => e.Device);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Devices)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.Devices)
                .WithRequired(e => e.Model)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sp_Si>()
                .HasMany(e => e.Devices)
                .WithRequired(e => e.Sp_Si)
                .HasForeignKey(e => e.SpID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sp_Si>()
                .HasMany(e => e.Devices1)
                .WithRequired(e => e.Sp_Si1)
                .HasForeignKey(e => e.SpID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Models)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);
        }
    }
}
