using DTO.Interfaces;
/// <summary>
/// Represents a person.
/// </summary>
namespace DTO
{
    /// <summary>
    /// Represents a person.
    /// </summary>
    public class Person:IPerson
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="firstName">The first name of the person.</param>
        /// <param name="lastName">The last name of the person.</param>
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public string LastName { get; set; }
    }
}

