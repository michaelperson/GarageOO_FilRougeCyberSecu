using GarageOO.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL.Config
{
    public class VoitureEntityConfig : IEntityTypeConfiguration<VoitureEntity>
    {
        public void Configure(EntityTypeBuilder<VoitureEntity> builder)
        {
            //Mettre un nom pour la table
            builder.ToTable("Car");
            //PK
            builder.HasKey(m => m.Id).HasName("Pk_Voiture");
            //Non NUll + lenght
            builder.Property(p=>p.Plaque)
                   .IsRequired()
                   .HasMaxLength(9);
            builder.Property(p=>p.Marque)
                   .IsRequired()
                   .HasMaxLength(250);
            builder.Property(p=>p.NbRoues)
                   .IsRequired()
                   .HasDefaultValue(4);

            builder.Property(p=>p.NbSiege)
                   .IsRequired();

            builder.Property(p=>p.NbPortes)
                   .HasDefaultValue(5);

           

            //Contraintes
            //roues
            builder.HasCheckConstraint("Chk_NbRoues", "NbRoues>=2 AND NbRoues<=4")
                   .HasComment("Nous considérons qu'une voiture ne peut pas avoir plus de 4 roues");
            //Portes
            builder.HasCheckConstraint("Chk_Portes", "NbPortes>=3 AND NbPortes<=5");
            //Sièges
            builder.HasCheckConstraint("Chk_Siege", "NbSiege>=2 AND NbSiege<=8");

            //Pas de CD
            builder.HasCheckConstraint("Chk_PlaqueCD", "UPPER(Plaque) not like 'CD%'");

            //Pattern de la Plaque
            builder.HasCheckConstraint("Chk_PlaqueFormat", "Plaque like '_-___-___'");

            //Plaque Unique
            builder.HasIndex(p=>p.Plaque).HasDatabaseName("UK_Plaque").IsUnique();
        }
    }
}
