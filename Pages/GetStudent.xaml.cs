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
    public sealed partial class GetStudent : Page
    {
        public GetStudent()
        {
            this.InitializeComponent();
        }

        public int key;
        private void Get_List(object sender, RoutedEventArgs e)
        {
            SQLiteConnection ccon = new SQLiteConnection("databaseStudent.db");

            var sqlCommandString = "SELECT * FROM Students WHERE Status = '" + key + "'";

            var stament = ccon.Prepare(sqlCommandString);

            while (SQLiteResult.ROW == stament.Step())
            {
                ListStudent.Items.Clear();
                ListStudent.Items.Add(stament[2]);
            }
        }

        private void GotoMenu(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string colorName = e.AddedItems[0].ToString();
            switch (colorName)
            {
                case "Active":
                    key = 1;
                    break;
                case "Deactive":
                    key = 0;
                    break;
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
