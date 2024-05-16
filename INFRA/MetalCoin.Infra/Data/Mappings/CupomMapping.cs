﻿using Metalcoin.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCoin.Infra.Data.Mappings
{
    internal class CupomMapping: IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> builder)
        {
            builder.ToTable("Categorias");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.statusCupom)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(p => p.DataValidade)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.TipoDescontoCupon)
                .HasColumnType("string")
                .IsRequired();

        }
    }
}
