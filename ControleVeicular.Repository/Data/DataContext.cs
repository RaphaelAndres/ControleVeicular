using ControleVeicular.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleVeicular.Repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementPhoto> AdvertisementPhotos { get; set; }
    }
}