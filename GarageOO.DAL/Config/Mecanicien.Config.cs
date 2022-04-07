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
    public class MecanicienEntityConfig : IEntityTypeConfiguration<MecanicienEntity>
    {
        public void Configure(EntityTypeBuilder<MecanicienEntity> builder)
        {
            //Le nom de la table en DB
            builder.ToTable("Mecano");

            //La PK
            builder.HasKey(m => m.Id)
                   .HasName("PK_MECANO")
                   .IsClustered();

            //Champs
            builder.Property(m => m.Id)
                   .HasColumnName("IdMecano");
            builder.Property(m => m.Nom)
                   .HasMaxLength(500)
                   .IsRequired();
            builder.Property(m => m.Expertise)
                   .HasDefaultValue(2)
                   .IsRequired();
            builder.Property(m => m.Tarif)
                   .IsRequired();

            //Contraintes
            builder.HasCheckConstraint("Chk_minNomLenght", "LEN(Nom)>=2");
            builder.HasCheckConstraint("Chk_minExpertise", "Expertise>=2");

            //relations
            // 1 voitures peut être prise en charge par +sieurs Mecanos et 1 mécano
            // peut prendre en charge +sieurs voitures
            builder.HasMany<VoitureEntity>(m => m.Voitures)
                   .WithMany(v => v.Mecaniciens);
                   //.UsingEntity<MecanoVoitureEntity>() ;
                   

           


        }
    }
}
