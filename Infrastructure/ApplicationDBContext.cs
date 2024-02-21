using BlazorApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Infrastructure;

public class ApplicationDBContext: DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Car> Cars { get; set; }
}