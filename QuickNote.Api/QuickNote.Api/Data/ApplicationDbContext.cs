using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickNote.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notebook>().HasData(
                new Notebook()
                {
                    Id = 1,
                    Name = "code"    

                }
                );
            modelBuilder.Entity<Note>().HasData(

                        new Note()
                        {
                            Id = 1,
                            Title = "C#",
                            Content = "Console.Writeline(\"Hello World!\");",
                            NotebookId = 1

                        },
                        new Note()
                        {
                            Id = 2,
                            Title = "Javascript",
                            Content = "console.log('Hello World!');",
                            NotebookId = 1
                        }

                );
        }
    }
}
