using System;
using System.Collections.Generic;
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

namespace DB_LINQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MyDBLinQDataContext db = new MyDBLinQDataContext(
        //    Properties.Settings.Default.ADO_NET_DEMOConnectionString);

        public MainWindow()
        {
            InitializeComponent();
            //if(db.DatabaseExists())
            //{
            //     var query = from c in db.NHANVIENs
            //                    where c.name == "Nguyễn Du Du"
            //                    select c.id;

            //    MessageBox.Show(query.ToString());
            //    ExampleDatagrid.ItemsSource = db.NGUOITHANs;
            //}
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBLinQDataContext db = new MyDBLinQDataContext())
            {
                NHANVIEN nv = (from c in db.NHANVIENs
                               where c.id == 1
                               select c).FirstOrDefault();
                MessageBox.Show(nv.id.ToString() + "-" + nv.name);
                nv.name = "Chung Thành Nguyễn";
                db.SubmitChanges();
            }
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBLinQDataContext db = new MyDBLinQDataContext())
            {
                NHANVIEN nv = new NHANVIEN
                {
                    id = 5,
                    name = "Lee Jun suk",
                    DOB = new DateTime(1997, 5, 15),
                    Sex = false
                };

                db.NHANVIENs.InsertOnSubmit(nv);
                db.SubmitChanges();

            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBLinQDataContext db = new MyDBLinQDataContext())
            {
                NGUOITHAN nt = (from c in db.NGUOITHANs
                                where c.MANT == 5
                                select c).FirstOrDefault();

                db.NGUOITHANs.DeleteOnSubmit(nt);
                db.SubmitChanges();
            }
        }

        private void XemButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBLinQDataContext db = new MyDBLinQDataContext())
            {

                //ExampleDatagrid.ItemsSource = db.NGUOITHANs;
                NHANVIEN nv = (from c in db.NHANVIENs
                               where c.id == 1
                               select c).FirstOrDefault();
                MessageBox.Show(nv.id.ToString() + "-" + nv.name); 

            }
        }
    }
}
