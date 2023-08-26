namespace ToDoDemo.Models
{
    /// <summary>
    /// Represents a filter configuration based on a filter string.
    /// </summary>
    public class Filters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Filters"/> class.
        /// </summary>
        /// <param name="filterstring">The filter string in the format "CategoryId-Due-StatusId".</param>
        public Filters(string filterstring) 
        {
            FilterString = filterstring ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            CategoryId = filters[0];
            Due = filters[1];
            StatusId = filters[2];
        }
        /// <summary>
        /// Gets the original filter string used for initialization.
        /// </summary>
        public string FilterString { get; }

        /// <summary>
        /// Gets the selected CategoryId from the filter.
        /// </summary>
        public string CategoryId { get; }


        /// <summary>
        /// Gets the selected Due filter value from the filter.
        /// </summary>
        public string Due { get; }

        /// <summary>
        /// Gets the selected StatusId from the filter.
        /// </summary>
        public string StatusId { get; }

        /// <summary>
        /// Gets a value indicating whether a specific category is selected.
        /// </summary>
        public bool HasCategory => CategoryId.ToLower() != "all";

        /// <summary>
        /// Gets a value indicating whether a specific due filter is selected.
        /// </summary>
        public bool HasDue => Due.ToLower() != "all";

        /// <summary>
        /// Gets a value indicating whether a specific status is selected.
        /// </summary>
        public bool HasStatus => StatusId.ToLower() != "all";


        /// <summary>
        /// Gets a dictionary of available due filter values and their display names.
        /// </summary>
        public static Dictionary<string, string> DueFilterValues =>
            new Dictionary<string, string> {
                {
                    "future","Future"
                },
                {
                    "past","Past"
                },
                {
                    "today", "Today"
                }

            };


        /// <summary>
        /// Gets a value indicating whether the selected due filter is for past tasks.
        /// </summary>
        public bool IsPast => Due.ToLower() == "past";



        /// <summary>
        /// Gets a value indicating whether the selected due filter is for future tasks.
        /// </summary>
        public bool IsFuture => Due.ToLower() == "future";

        /// <summary>
        /// Gets a value indicating whether the selected due filter is for tasks due today.
        /// </summary>
        public bool IstToday => Due.ToLower() == "today";
    }
}
