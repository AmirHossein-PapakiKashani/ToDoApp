namespace ToDoDemo.Models
{
    /// <summary>
    /// Represents a status of a task.
    /// </summary>

    public class Status
    {
        /// <summary>
        /// Gets or sets the unique identifier for the status.
        /// </summary>
        public string StatusId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the status.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
