using System;
using System.Data.SQLite;
using System.IO;

namespace Sikul
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            string databaseFileName = "sikul.db";
            _connectionString = $"Data Source={databaseFileName};Version=3;";

            Console.WriteLine("Database Path: " + databaseFileName);
        }

        public void AddAcademicYearAndSetActive(string year, DateTime startDate, DateTime endDate)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Deactivate existing active year (if any)
                        string checkActiveQuery = "SELECT Id FROM AcademicYears WHERE IsActive = 1;";
                        using (var checkActiveCommand = new SQLiteCommand(checkActiveQuery, connection, transaction))
                        {
                            var activeId = checkActiveCommand.ExecuteScalar();

                            if (activeId != null)
                            {
                                string setInactiveQuery = "UPDATE AcademicYears SET IsActive = 0 WHERE Id = @activeId;";
                                using (var setInactiveCommand = new SQLiteCommand(setInactiveQuery, connection, transaction))
                                {
                                    setInactiveCommand.Parameters.AddWithValue("@activeId", activeId);
                                    setInactiveCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        // 2. Insert the new academic year and set it as active
                        string insertQuery = @"
                            INSERT INTO AcademicYears (Year, StartDate, EndDate, IsActive) 
                            VALUES (@year, @startDate, @endDate, 1);";

                        using (var insertCommand = new SQLiteCommand(insertQuery, connection, transaction))
                        {
                            insertCommand.Parameters.AddWithValue("@year", year);
                            insertCommand.Parameters.AddWithValue("@startDate", startDate);
                            insertCommand.Parameters.AddWithValue("@endDate", endDate);
                            insertCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Re-throw the exception
                    }
                }
            }
        }

        public bool AcademicYearExists(string year)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT COUNT(*) FROM AcademicYears WHERE Year = @year;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@year", year);
                    int count = (int)(long)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public string? GetActiveAcademicYear()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Year FROM AcademicYears WHERE IsActive = 1;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    var result = command.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        public int GetAcademicYearId(string year)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Id FROM AcademicYears WHERE Year = @year;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@year", year);
                    var result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        return id;
                    }
                    return -1; // Return -1 if not found or error
                }
            }
        }
    }
}