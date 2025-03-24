using System;
using System.Windows;

namespace Sikul
{
    public partial class CreateAcademicYearWindow : Window
    {
        private DatabaseHelper _dbHelper;

        public CreateAcademicYearWindow(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string year = YearTextBox.Text;
            DateTime startDate = StartDatePicker.SelectedDate ?? DateTime.Now;
            DateTime endDate = EndDatePicker.SelectedDate ?? DateTime.Now.AddYears(1);

            if (string.IsNullOrEmpty(year))
            {
                MessageBox.Show("Please enter a year.");
                return;
            }

            if (_dbHelper.AcademicYearExists(year))
            {
                MessageBox.Show("Academic year already exists.");
                return;
            }

            try
            {
                _dbHelper.AddAcademicYearAndSetActive(year, startDate, endDate); // Use the new method
                MessageBox.Show("Academic year created and set as active.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating academic year: {ex.Message}");
            }
        }
    }
}