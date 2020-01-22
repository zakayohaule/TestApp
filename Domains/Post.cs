using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Domains
{
    [Table("posts")]
    public class Post
    {
        [Key]
        public int Id { get; set; }

//        private string _name;

        public string Name { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(p => p.Name)
                .HasConversion(
                    v => v,
                    v => v + " From the DB")
                /*.HasField("_name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)*/;

            modelBuilder.Entity<Post>()
                .HasData(
                    new Post {Id = 1, Name = "Seeded 1"},
                    new Post {Id = 2, Name = "Seeded 2"},
                    new Post {Id = 3, Name = "Seeded 3"}
                );
        }
    }
}