using System;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace Sikul
{
    public partial class MainWindow : Window
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();
        public static string? ActiveAcademicYear { get; private set; }

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                InitializeDatabase();
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                CheckAndFetchAcademicYear();
                UpdateAcademicYearDisplay();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MainWindow: {ex.Message}");
                MessageBox.Show($"Error in MainWindow: {ex.Message}");
            }
        }

        private void InitializeDatabase()
        {
            string databaseFileName = "sikul.db";
            string databaseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, databaseFileName);

            if (!File.Exists(databaseFilePath))
            {
                try
                {
                    SQLiteConnection.CreateFile(databaseFilePath);

                    using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databaseFilePath};Version=3;"))
                    {
                        connection.Open();

                        string schema = ReadSchemaFromFile();
                        if (!string.IsNullOrEmpty(schema))
                        {
                            SQLiteCommand command = new SQLiteCommand(schema, connection);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Error reading schema from file.");
                            return;
                        }
                    }
                    MessageBox.Show("Database created successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating database: {ex.Message}");
                }
            }
        }

        private string ReadSchemaFromFile()
        {
            try
            {
                string schemaFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "schema.sql");
                Console.WriteLine("Schema File Path: " + schemaFilePath); // Add this line

                if (File.Exists(schemaFilePath))
                {
                    Console.WriteLine("Schema File Exists."); //add this line
                    string schema = File.ReadAllText(schemaFilePath);
                    Console.WriteLine("Schema File Read."); // add this line
                    return schema;
                }
                else
                {
                    Console.WriteLine("Schema File Does Not Exist."); //add this line
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading schema file: {ex.Message}"); // add this line.
                MessageBox.Show($"Error reading schema file: {ex.Message}");
                return "";
            }
        }

        private void CheckAndFetchAcademicYear()
        {
            try
            {
                ActiveAcademicYear = _dbHelper.GetActiveAcademicYear();
                if (string.IsNullOrEmpty(ActiveAcademicYear))
                {
                    MessageBox.Show("No active academic year found. Please create one.");
                    CreateAcademicYearWindow setupWindow = new CreateAcademicYearWindow(_dbHelper);
                    setupWindow.ShowDialog();
                    ActiveAcademicYear = _dbHelper.GetActiveAcademicYear();
                }
                if (string.IsNullOrEmpty(ActiveAcademicYear))
                {
                    MessageBox.Show("Active Academic year could not be set. Please set one.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking academic year: {ex.Message}");
            }
        }

        private void UpdateAcademicYearDisplay()
        {
            if (!string.IsNullOrEmpty(ActiveAcademicYear))
            {
                AcademicYearTextBlock.Text = $"Academic Year: {ActiveAcademicYear}";
            }
            else
            {
                AcademicYearTextBlock.Text = "Academic Year: Not Set";
            }
        }

        private void CreateAcademicYear_Click(object sender, RoutedEventArgs e)
        {
            CreateAcademicYearWindow setupWindow = new CreateAcademicYearWindow(_dbHelper);
            setupWindow.ShowDialog();
            CheckAndFetchAcademicYear();
            UpdateAcademicYearDisplay();
        }

        private void ManageSettings_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Manage Settings functionality to be implemented.");
        }

        private void StudentEntryButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Student Entry functionality to be implemented.");
        }

        private void ResultGenerationButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Result Generation functionality to be implemented.");
        }

        private void ReportCardGeneration_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Report Card Generation functionality to be implemented.");
        }

        private void ManagementButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Management functionality to be implemented.");
        }

        private void ViewPreviousReportsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("View Previous Reports functionality to be implemented.");
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}