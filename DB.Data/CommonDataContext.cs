using Microsoft.EntityFrameworkCore;
using Org.Tao.DB.Model;

namespace Org.Tao.DB.Data
{
    public class CommonDataContext : DbContext
    {
        public DbSet<TagInfo> TagInfos { get; set; }
        public DbSet<TagData> TagDatas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tagging.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
