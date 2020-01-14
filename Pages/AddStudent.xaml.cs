using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Student.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddStudent : Page
    {
        public AddStudent()
        {
            this.InitializeComponent();
        }

        private void Add_Student(object sender, RoutedEventArgs e)
        {

            SQLiteConnection ccon = new SQLiteConnection("databaseStudent.db");

            var sqlCommandString = "insert into Students (RollNumber,Name, Status) values (?,?,?)";


            using (var stament = ccon.Prepare(sqlCommandString))
            {
                stament.Bind(1, RollNumber.Text);
                stament.Bind(2, Name.Text);
                stament.Bind(3, Convert.ToInt32(Status.Text));
                stament.Step();
            }
        }

        private void GotoMenu(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
