using MD.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.Data.Configuration
{
    class LinkConfig : EntityTypeConfiguration<Link>
    {
        public LinkConfig()
        {
            HasIndex(p => p.NativeId);
            HasIndex(p => p.NodeId);
            HasIndex(p => p.ContractorId);

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //.HasColumnAnnotation("defaultValueSql", "NEWID()");
            //defaultValueSql: "GETDATE()"
            Property(p => p.Date)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                //.HasColumnAnnotation("defaultValueSql", "GETDATE()");

            Property(p => p.ContractorId)
                .IsRequired();

            Property(p => p.NodeId)
                .IsRequired();

            Property(p => p.NativeId)
                .IsRequired()
                .HasMaxLength(36);

            HasRequired(p => p.Node).WithMany(p => p.Links).WillCascadeOnDelete(false);
            HasRequired(p => p.Contractor).WithMany(p => p.Links).WillCascadeOnDelete(false);
        }
    }
}
