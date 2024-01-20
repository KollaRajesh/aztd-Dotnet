namespace DI.Data;

using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using DTO;
using DTO.Interfaces;
    public class PersonRepository
    {
        private readonly string _connectionString="";

        public PersonRepository(IConfiguration  configuration )
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<IPerson> GetAll()
        {
            var people = new List<Person>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM People", connection))
                {
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

       public void Save(IPerson person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                if (person.Id == 0)
                {
                    using (var command = new SqlCommand("INSERT INTO People (FirstName, LastName,Age) VALUES (@firstName,@lastName, @Age)", connection))
                    {
                        command.Parameters.AddWithValue("@Name", person.FirstName);
                        command.Parameters.AddWithValue("@Name", person.LastName);
                        command.Parameters.AddWithValue("@Age", person.Age);

                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var command = new SqlCommand("UPDATE People SET FirstName = @firstName,LastName=@lastName, Age = @Age WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", person.Id);
                        command.Parameters.AddWithValue("@firstName", person.FirstName);
                        command.Parameters.AddWithValue("@lastName", person.LastName);
                        command.Parameters.AddWithValue("@Age", person.Age);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

    public override string ToString() => $"{nameof(PersonRepository)} with SQL Connection \\n {_connectionString}";
    }
