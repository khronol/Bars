using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestDBEntities db;
        TestService service;
        List<Contracts> contracts;
        public MainWindow()
        {
            InitializeComponent();
            db = new TestDBEntities();
            service = new TestService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Contracts.Load();
            contracts = db.Contracts.ToList();
            for (int i = 0; i < contracts.Count; i++)
            {
                if ((contracts[i].LastUpdate - contracts[i].CreationDate).TotalDays < 60) contracts[i].Check = true;
            }
            lvContr.ItemsSource = contracts;
            
        }

        private void btn_NewContract_Click(object sender, RoutedEventArgs e)
        {
            Contracts tmp = new Contracts();
            tmp.Id = contracts.Count + 1;
            tmp.CreationDate = DateTime.Now;
            tmp.LastUpdate = DateTime.Now;
            tmp.Check = true;
            service.NewContract(db,tmp);
            lvContr.ItemsSource = db.Contracts.Local.ToBindingList<Contracts>();
        }

        private void btn_DelContract_Click(object sender, RoutedEventArgs e)
        {
            int toDel = lvContr.SelectedIndex;
            service.DeleteContract(db, contracts[toDel]);
            lvContr.ItemsSource = db.Contracts.Local.ToBindingList<Contracts>();
        }
    }
}
