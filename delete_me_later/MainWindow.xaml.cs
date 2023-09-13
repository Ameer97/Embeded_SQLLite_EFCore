using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using System.Xml.Linq;

namespace delete_me_later
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        AppDBContext Context = new AppDBContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.Database.EnsureCreated();
            Context.Users.Select(u => u.Name).ToList().ForEach(x => list.Items.Add(x));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User { Name = textbox.Text };
            Context.Users.Add(user);
            Context.SaveChanges();
            list.Items.Add(user.Name);

        }
    }



    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=app.db");
            base.OnConfiguring(options);
        }

    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }    
    }
}


