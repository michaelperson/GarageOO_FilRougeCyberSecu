using GarageOO.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL.Config
{
    public class MecanicienVoituresEntityConfig : IEntityTypeConfiguration<MecanoVoitureEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MecanoVoitureEntity> builder)
        {
            builder.ToTable("MecanoVoitures");

            builder.Property(m => m.DebutPriseEnCharge).IsRequired();
            builder.Property(m => m.FinPriseEnCharge).IsRequired();
        }
    }
}
