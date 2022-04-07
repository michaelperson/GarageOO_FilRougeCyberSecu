using GarageOO.DAL.Config;
using GarageOO.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL
{
    public class TfGarage : DbContext
    {
        private readonly string _cnstr;
        //Mes DbSet (sortes de repository)
        public DbSet<VoitureEntity> Voitures { get; set; }
        public DbSet<MecanicienEntity> Mecanos { get; set; }

        /// <summary>
        /// Constructor pour la migration
        /// </summary>
        public TfGarage()
        {
            this._cnstr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TFGarage;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        /// <summary>
        /// CONSTRUCTEUR permettant de recevoir la connectionstring de l'extérieur (portabilité :-) )
        /// </summary>
        /// <param name="ConnectionString"></param>
        public TfGarage(string ConnectionString):base()
        {
            this._cnstr=ConnectionString;
        }


        //La configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connectionstring
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.UseSqlServer(_cnstr);

            base.OnConfiguring(optionsBuilder);
        }

        //La configuration des modèles lors de la création
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new VoitureEntityConfig());
            modelBuilder.ApplyConfiguration(new MecanicienEntityConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
