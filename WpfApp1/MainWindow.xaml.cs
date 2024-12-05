using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;

        public MainWindow()
        {
            InitializeComponent();

            // Load configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();

            // Set up DbContext with connection string from appsettings.json
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            _context = new AppDbContext(optionsBuilder.Options);
            LoadQuestions();
        }

        // Load questions from the database
        private void LoadQuestions()
        {
            lstQuestions.Items.Clear();
            var questions = _context.Questions.Where(q => !q.IsAnswered).ToList(); // Get unanswered questions
            foreach (var question in questions)
            {
                lstQuestions.Items.Add(question);
            }
        }

        // Other event handlers and methods...

        // Submit answer to the selected question
        private void btnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (lstQuestions.SelectedItem != null)
            {
                var selectedQuestion = (Question)lstQuestions.SelectedItem;
                selectedQuestion.Answer = txtAnswer.Text; // Update answer
                selectedQuestion.IsAnswered = true; // Mark as answered

                _context.SaveChanges(); // Save changes
                LoadQuestions(); // Reload questions
                txtAnswer.Clear(); // Clear the answer text box
            }
            else
            {
                MessageBox.Show("Please select a question to answer.");
            }
        }
    }
}
