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
    class ContractConfig : EntityTypeConfiguration<Contract>
    {
        public ContractConfig()
        {
            //HasKey(p => p.Id);

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Number)
                .IsRequired()
                .HasMaxLength(30);

            Property(p => p.Date)
                .IsRequired();

            HasIndex(p => p.Number);

        }
    }
}
