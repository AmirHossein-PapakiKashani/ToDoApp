namespace ToDoDemo.Models
{
    /// <summary>
    /// Represents a category for grouping tasks.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public string CategoryId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; } = string.Empty;

    }
}
