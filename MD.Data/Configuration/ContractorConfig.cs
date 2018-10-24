using MD.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.Data.Configuration
{
    class ContractorConfig : EntityTypeConfiguration<Contractor>
    {
        public ContractorConfig()
        {

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.INN)
                .IsRequired()
                .HasMaxLength(12);

            Property(p => p.OKPO)
                .HasMaxLength(10);

            Property(p => p.VATCertificateNumber)
                .HasMaxLength(10);

            HasIndex(p => p.Name);
            HasIndex(p => p.INN);
            HasIndex(p => p.OKPO);
            HasIndex(p => p.VATCertificateNumber);

        }
    }
}
