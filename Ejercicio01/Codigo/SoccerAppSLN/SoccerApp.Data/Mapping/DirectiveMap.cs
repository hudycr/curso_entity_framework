using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SoccerApp.Domain;

namespace SoccerApp.Data.Mapping
{
    internal class DirectiveMap : EntityTypeConfiguration<Directive>
    {
        public DirectiveMap()
        {
            ToTable("Directivos");

            HasKey(d => d.DirectiveId)
                .Property(d => d.DirectiveId)
                .HasColumnName("DirectivoId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(d => d.ParentDirectiveId).HasColumnName("JefeId");
            //mapeo one-to-many con subordinados
            HasMany(d => d.Subordinates).WithOptional().HasForeignKey(s => s.ParentDirectiveId);
        }
    }
}
