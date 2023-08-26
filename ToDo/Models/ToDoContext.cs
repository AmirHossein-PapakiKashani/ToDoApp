using Microsoft.EntityFrameworkCore;

namespace ToDoDemo.Models
{
    /// <summary>
    /// Represents the database context for managing ToDo application data.
    /// </summary>
    public class ToDoContext : DbContext
    {
        // <summary>
        /// Initializes a new instance of the <see cref="ToDoContext"/> class.
        /// </summary>
        /// <param name="options">The database context options.</param>
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the DbSet representing ToDo items in the database.
        /// </summary>
        public DbSet<ToDo> ToDos { get; set; } = null!;
        /// <summary>
        /// Gets or sets the DbSet representing categories in the database.
        /// </summary>
        public DbSet<Category> Categories { get; set; } = null!;
        /// <summary>
        /// Gets or sets the DbSet representing task statuses in the database.
        /// </summary>
        public DbSet<Status> Statues { get; set; } = null!;

        // seed data 
        /// <summary>
        /// Configures initial seed data for categories and statuses.
        /// </summary>
        /// <param name="modelBuilder">The model builder for configuring the database.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
                (
                    new Category {  CategoryId = "work", Name = "Work"},
                    new Category { CategoryId = "home", Name = "Home" },
                    new Category { CategoryId = "ex", Name = "Exercise" },
                    new Category { CategoryId = "shop", Name = "Shopping" },
                    new Category { CategoryId = "call", Name = "Contact" }
                );
            modelBuilder.Entity<Status>().HasData
                (
                    new Status { StatusId = "open", Name = "Open" },
                    new Status { StatusId = "closed", Name = "Completed" }
                );
        }
         

    }
}
