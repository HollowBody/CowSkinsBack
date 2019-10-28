using CowSkinsService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CowSkinsService.DAL
{
    public class SkinsContext : DbContext
    {
        public virtual DbSet<Adressee> Adressee { get; set; }
        public virtual DbSet<Authorization> Authorization { get; set; }
        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<Models.Configuration> Configuration { get; set; }
        public virtual DbSet<CostJournal> CostJournal { get; set; }
        public virtual DbSet<Pallet> Pallet { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<SchemeType> SchemeType { get; set; }
        public virtual DbSet<Send> Send { get; set; }
        public virtual DbSet<Skin> Skin { get; set; }
        public virtual DbSet<SkinType> SkinType { get; set; }
        public virtual DbSet<SortingScheme> SortingScheme { get; set; }
        public virtual DbSet<Sorts> Sorts { get; set; }

        public SkinsContext(DbContextOptions<SkinsContext> options): 
            base(options) {
        }
        
        public static SkinsContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SkinsContext>()
                .UseSqlServer(ConfigurationManager.ConnectionStrings["SkinsDatabase"].ConnectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            return new SkinsContext(optionsBuilder.Options);
        }
    }
}
