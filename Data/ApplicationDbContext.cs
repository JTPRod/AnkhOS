using KemeticReference.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace KemeticReference.Data;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Deitydb> Deities => Set<Deitydb>();
    public DbSet<UserFavorite> UserFavorites => Set<UserFavorite>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserFavorite>(entity =>
        {
            entity.HasKey(favorite => new { favorite.UserId, favorite.DeityId });

            entity.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(favorite => favorite.UserId);

            entity.HasOne(favorite => favorite.Deity)
                .WithMany(deity => deity.Favorites)
                .HasForeignKey(favorite => favorite.DeityId);
        });
    }
}
