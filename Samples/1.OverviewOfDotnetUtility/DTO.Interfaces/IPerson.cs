/// <summary>
/// Represents a person.
/// </summary>
namespace DTO.Interfaces
{
    /// <summary>
    /// Represents a person.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        string LastName { get; set; }
    }
}

