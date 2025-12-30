using easywallet_api.Models;
using Microsoft.EntityFrameworkCore;

namespace easywallet_api.Data;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}