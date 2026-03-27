using Microsoft.EntityFrameworkCore;
using Assetmanagement.Models;

namespace Assetmanagement.Data {
    public class AssetmanagementContext : DbContext { 
    public AssetmanagementContext (DbContextOptions<AssetmanagementContext> options) : base(options) { } 
        public  DbSet<Machine> Machines { get; set; }

    }
}
