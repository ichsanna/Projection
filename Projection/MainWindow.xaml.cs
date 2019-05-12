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
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;

namespace Projection
{
    // Kelompok:
    // Dian Rahmaji (17/413896/TK/46336)
    // Raden Ichsan Nur Aldiansyah (17/413915/TK/46355)
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model3DGroup objects = new Model3DGroup();
        Model3DGroup sumbu = new Model3DGroup();
        double[,] matriks = new double[,]
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        };
        Point3D[] titik = new Point3D[14] {
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0)
        };
        public MainWindow()
        {
            InitializeComponent();
            gambarsumbu();
            koordinatrumah(0, 0, 0, 0, 0, 0);
        }
        private void koordinatrumah(double x, double y, double z, double px, double py, double pz)
        {
            titik[0] = new Point3D(x - (px / 2), y - (py / 2), z);
            titik[1] = new Point3D(x + (px / 2), y - (py / 2), z);
            titik[2] = new Point3D(x + (px / 2), y + (py / 2), z);
            titik[3] = new Point3D(x - (px / 2), y + (py / 2), z);
            titik[4] = new Point3D(x - (px / 2), y - (py / 2), z + (pz / 2));
            titik[5] = new Point3D(x + (px / 2), y - (py / 2), z + (pz / 2));
            titik[6] = new Point3D(x + (px / 2), y + (py / 2), z + (pz / 2));
            titik[7] = new Point3D(x - (px / 2), y + (py / 2), z + (pz / 2));
            titik[8] = new Point3D(x, y - (py / 2), z + pz);
            titik[9] = new Point3D(x, y + (py / 2), z + pz);
            titik[10] = new Point3D(x + (px / 6), y - (py / 2), z);
            titik[11] = new Point3D(x + (px / 6), y - (py / 2), z + (pz / 3));
            titik[12] = new Point3D(x + (px / 3), y - (py / 2), z + (pz / 3));
            titik[13] = new Point3D(x + (px / 3), y - (py / 2), z);
            gambarrumah();
        }
        private void gambarsumbu()
        {
            var sumbux = new MeshBuilder(false, false);
            var sumbuy = new MeshBuilder(false, false);
            var sumbuz = new MeshBuilder(false, false);
            sumbux.AddPipe(new Point3D(-100, 0, 0), new Point3D(100, 0, 0), 0, 0.1, 90);
            sumbuy.AddPipe(new Point3D(0, -100, 0), new Point3D(0, 100, 0), 0, 0.1, 90);
            sumbuz.AddPipe(new Point3D(0, 0, -100), new Point3D(0, 0, 100), 0, 0.1, 90);
            sumbu.Children.Add(new GeometryModel3D
            {
                Geometry = sumbux.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.DarkRed)
            });
            sumbu.Children.Add(new GeometryModel3D
            {
                Geometry = sumbuy.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.ForestGreen)
            });
            sumbu.Children.Add(new GeometryModel3D
            {
                Geometry = sumbuz.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.RoyalBlue)
            });
            placedobjects.Content = sumbu;
        }
        private void gambarrumah()
        {
            var kerangkarumah = new MeshBuilder(false, false);
            kerangkarumah.AddPipe(titik[0], titik[1], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[1], titik[2], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[2], titik[3], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[3], titik[0], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[4], titik[5], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[5], titik[6], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[6], titik[7], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[7], titik[4], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[0], titik[4], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[1], titik[5], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[2], titik[6], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[3], titik[7], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[4], titik[8], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[5], titik[8], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[6], titik[9], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[7], titik[9], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[9], titik[8], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[10], titik[11], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[11], titik[12], 0, 0.2, 90);
            kerangkarumah.AddPipe(titik[12], titik[13], 0, 0.2, 90);
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = kerangkarumah.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.DarkBlue)
            });
            placedobjects.Children.Clear();
            objects.Children.Add(sumbu);
            placedobjects.Content = objects;
        }

        private void Button_buatobjek_Click(object sender, RoutedEventArgs e)
        {
            var titiklenyap = new MeshBuilder(false, false);
            titiklenyap.AddEllipsoid(new Point3D(0, 0, Convert.ToDouble(TextBox_titiklenyapz.Text)), 0.2, 0.2, 0.2);
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = titiklenyap.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.Yellow)
            });
            koordinatrumah(Convert.ToDouble(TextBox_posisiobjekx.Text), Convert.ToDouble(TextBox_posisiobjeky.Text), Convert.ToDouble(TextBox_posisiobjekz.Text), Convert.ToDouble(TextBox_panjangrumahx.Text), Convert.ToDouble(TextBox_panjangrumahy.Text), Convert.ToDouble(TextBox_panjangrumahz.Text));
        }
    }
}
