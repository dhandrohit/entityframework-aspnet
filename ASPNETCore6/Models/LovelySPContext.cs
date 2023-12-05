using Microsoft.EntityFrameworkCore;

namespace ASPNETCore6
{
    public class LovelySPContext : DbContext
    {
            public LovelySPContext(DbContextOptions<LovelySPContext> options) : base(options) { }
    
            public virtual DbSet<EFDeptModel> EFDepts { get; set; } = null!;
    
    }
}
