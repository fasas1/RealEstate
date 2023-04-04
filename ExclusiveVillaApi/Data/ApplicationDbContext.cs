using ExclusiveVillaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExclusiveVillaApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Ville> Villes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ville>().HasData(
                new Ville
                {
                    Id = 1,
                    Name = "Quest Villa",
                    Details = "it catering to the demands of users, technology and whatsoever it maybe. Version control systems keep these revisions straight",
                    ImageUrl = "https://www.pexels.com/photo/white-concrete-2-storey-house-206172/",
                    Occupancy = 31,
                    Rate = 230,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Ville
                {
                    Id = 2,
                    Name = "Skully Villa",
                    Details = "it catering to the demands of users, technology and whatsoever it maybe. Version control systems keep these revisions straight",
                    ImageUrl = "https://www.pexels.com/photo/palm-trees-at-night-258154/",
                    Occupancy = 41,
                    Rate = 350,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Ville
                {
                    Id = 3,
                    Name = "Moment Villa",
                    Details = "it catering to the demands of users, technology and whatsoever it maybe. Version control systems keep these revisions straight",
                    ImageUrl = "https://www.pexels.com/photo/construction-house-architecture-luxury-53610/",
                    Occupancy = 21,
                    Rate = 80,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Ville
                {
                    Id = 4,
                    Name = "Qassy Villa",
                    Details = "it catering to the demands of users, technology and whatsoever it maybe. Version control systems keep these revisions straight",
                    ImageUrl = "https://www.pexels.com/photo/architecture-beach-blue-chairs-261101/",
                    Occupancy = 21,
                    Rate = 130,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Ville
                {
                    Id = 5,
                    Name = "Bazooy Villa",
                    Details = "it catering to the demands of users, technology and whatsoever it maybe. Version control systems keep these revisions straight",
                    ImageUrl = "https://www.pexels.com/photo/architecture-beach-blue-chairs-261101/",
                    Occupancy = 11,
                    Rate = 190,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                }
             );
        }
    }
}
