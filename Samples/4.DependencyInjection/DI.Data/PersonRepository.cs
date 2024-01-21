namespace DI.Data;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;

    using DTO;
    using DTO.Interfaces;

    // This class is responsible for interacting with the database for Person related operations.
    public class PersonRepository
    {
        // Connection string to the database.
        private readonly string _connectionString="";

        // Constructor that takes IConfiguration object to get the connection string from configuration.
        public PersonRepository(IConfiguration  configuration )
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Constructor that takes a connection string directly.
        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Method to get all persons from the database.
        public IEnumerable<IPerson> GetAll()
        {
            var people = new List<Person>();

            // Using SqlConnection to connect to the database.
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Using SqlCommand to execute SQL query.
                using (var command = new SqlCommand("SELECT * FROM People", connection))
                {
                    // Using SqlDataReader to read the result of SQL query.
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var person = new Person
                            {
                                Id = (int)reader["Id"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Age = (int)reader["Age"]
                            };

                            people.Add(person);
                        }
                    }
                }
            }

            return people;
        }

        // Method to save a person to the database.
        public void Save(IPerson person)
        {
            // Using SqlConnection to connect to the database.
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // If the person's Id is 0, it means it's a new person, so insert it into the database.
                if (person.Id == 0)
                {
                    // Using SqlCommand to execute SQL query.
                    using (var command = new SqlCommand("INSERT INTO People (FirstName, LastName,Age) VALUES (@firstName,@lastName, @age)", connection))
                    {
                        command.Parameters.AddWithValue("@firstName", person.FirstName);
                        command.Parameters.AddWithValue("@lastName", person.LastName);
                        command.Parameters.AddWithValue("@age", person.Age);

                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    // If the person's Id is not 0, it means it's an existing person, so update it in the database.
                    using (var command = new SqlCommand("UPDATE People SET FirstName = @firstName,LastName=@lastName, Age = @age WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", person.Id);
                        command.Parameters.AddWithValue("@firstName", person.FirstName);
                        command.Parameters.AddWithValue("@lastName", person.LastName);
                        command.Parameters.AddWithValue("@age", person.Age);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        // Overriding ToString method to return the name of the class and the connection string.
        public override string ToString() => $"{nameof(PersonRepository)} with SQL Connection \\n {_connectionString}";
    }
