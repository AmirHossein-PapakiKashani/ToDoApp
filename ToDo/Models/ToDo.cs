using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ToDoDemo.Models
{

    /// <summary>
    /// Represents a task to be completed.
    /// </summary>
    public class ToDo
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description of the task.
        /// </summary>
        [Required(ErrorMessage ="Please enter a description.")]
        public string Description { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the description of the task.
        /// </summary>
        [Required(ErrorMessage ="Please enter a due date.")]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the due date of the task.
        /// </summary>

        [Required(ErrorMessage = "Please select a category.")]
        public string CategoryId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category identifier of the task.
        /// </summary>
        [ValidateNever]
        public Category Category { get; set; } = null! ;



        /// <summary>
        /// Gets or sets the status identifier of the task.
        /// </summary>
        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the associated status of the task.
        /// </summary>
        [ValidateNever]
        public Status Status { get; set; } = null!;

        /// <summary>
        /// Gets a value indicating whether the task is overdue.
        /// </summary>
        public bool Overdue => StatusId == "open" && DueDate < DateTime.Today;
        

    }
}
