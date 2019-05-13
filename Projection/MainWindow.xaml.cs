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
            objects.Children.Clear();
            var kerangkarumah = new MeshBuilder(false, false);
            var tembokrumah = new MeshBuilder(false, false);
            var ataprumah = new MeshBuilder(false, false);
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
            tembokrumah.AddBox(new Point3D((titik[0].X + titik[2].X) / 2, (titik[0].Y + titik[2].Y) / 2, (titik[0].Z + titik[2].Z) / 2), (titik[2].X - titik[0].X), (titik[2].Y - titik[0].Y), (titik[2].Z - titik[0].Z));
            tembokrumah.AddBox(new Point3D((titik[0].X + titik[5].X) / 2, (titik[0].Y + titik[5].Y) / 2, (titik[0].Z + titik[5].Z) / 2), (titik[5].X - titik[0].X), (titik[5].Y - titik[0].Y), (titik[5].Z - titik[0].Z));
            tembokrumah.AddBox(new Point3D((titik[1].X + titik[6].X) / 2, (titik[1].Y + titik[6].Y) / 2, (titik[1].Z + titik[6].Z) / 2), (titik[6].X - titik[1].X), (titik[6].Y - titik[1].Y), (titik[6].Z - titik[1].Z));
            tembokrumah.AddBox(new Point3D((titik[2].X + titik[7].X) / 2, (titik[2].Y + titik[7].Y) / 2, (titik[2].Z + titik[7].Z) / 2), (titik[2].X - titik[7].X), (titik[7].Y - titik[2].Y), (titik[7].Z - titik[2].Z));
            tembokrumah.AddBox(new Point3D((titik[3].X + titik[4].X) / 2, (titik[3].Y + titik[4].Y) / 2, (titik[3].Z + titik[4].Z) / 2), (titik[4].X - titik[3].X), (titik[4].Y - titik[3].Y), (titik[4].Z - titik[3].Z));
            ataprumah.AddTriangle(titik[4], titik[5], titik[8]);
            ataprumah.AddTriangle(titik[6], titik[7], titik[9]);
            ataprumah.AddTriangle(titik[5], titik[6], titik[8]);
            ataprumah.AddTriangle(titik[7], titik[4], titik[8]);
            ataprumah.AddTriangle(titik[9], titik[8], titik[6]);
            ataprumah.AddTriangle(titik[8], titik[9], titik[7]);
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = kerangkarumah.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.DarkBlue)
            });
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = tembokrumah.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.LightBlue)
            });
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = ataprumah.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.SaddleBrown)
            });
            var titiklenyap = new MeshBuilder(false, false);
            titiklenyap.AddEllipsoid(new Point3D(0, 0, Convert.ToDouble(TextBox_titiklenyapz.Text)), 0.2, 0.2, 0.2);
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = titiklenyap.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.Yellow)
            });
            placedobjects.Children.Clear();
            objects.Children.Add(sumbu);
            placedobjects.Content = objects;
        }
        private void resetmatrikstransform()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matriks[i, j] = 0;
                }
            }
        }
        private void perkalianmatriks()
        {
            double tempx, tempy, tempz, temp4;
            for (int h = 0; h < 14; h++)
            {
                double[,] matriks2 = new double[,]
                {
                    {titik[h].X},{titik[h].Y},{titik[h].Z},{1}
                };
                tempx = 0;
                tempy = 0;
                tempz = 0;
                temp4 = 0;
                for (int i = 0; i < 4; i++)
                {
                    tempx += (matriks[0, i] * matriks2[i, 0]);
                    tempy += (matriks[1, i] * matriks2[i, 0]);
                    tempz += (matriks[2, i] * matriks2[i, 0]);
                    temp4 += (matriks[3, i] * matriks2[i, 0]);
                }
                titik[h].X = Math.Round(tempx, 4) / temp4;
                titik[h].Y = Math.Round(tempy, 4) / temp4;
                titik[h].Z = Math.Round(tempz, 4) / temp4;
            }
            resetmatrikstransform();
            gambarrumah();
            updateposisi();
        }
        private void updateposisi()
        {
            TextBox_titik1.Text = titik[0].ToString();
            TextBox_titik2.Text = titik[1].ToString();
            TextBox_titik3.Text = titik[2].ToString();
            TextBox_titik4.Text = titik[3].ToString();
            TextBox_titik5.Text = titik[4].ToString();
            TextBox_titik6.Text = titik[5].ToString();
            TextBox_titik7.Text = titik[6].ToString();
            TextBox_titik8.Text = titik[7].ToString();
            TextBox_titik9.Text = titik[8].ToString();
            TextBox_titik10.Text = titik[9].ToString();
            TextBox_titik11.Text = titik[10].ToString();
            TextBox_titik12.Text = titik[11].ToString();
            TextBox_titik13.Text = titik[12].ToString();
            TextBox_titik14.Text = titik[13].ToString();
        }
        private void Button_buatobjek_Click(object sender, RoutedEventArgs e)
        {
            koordinatrumah(Convert.ToDouble(TextBox_posisiobjekx.Text), Convert.ToDouble(TextBox_posisiobjeky.Text), Convert.ToDouble(TextBox_posisiobjekz.Text), Convert.ToDouble(TextBox_panjangrumahx.Text), Convert.ToDouble(TextBox_panjangrumahy.Text), Convert.ToDouble(TextBox_panjangrumahz.Text));
            TextBox_posisilantai.Text = TextBox_posisiobjekz.Text;
        }

        private void Button_ubahposisi_Click(object sender, RoutedEventArgs e)
        {
            resetmatrikstransform();
            matriks[0, 0] = 1;
            matriks[1, 1] = 1;
            matriks[3, 3] = 1;
            matriks[3, 2] = 1 / (Convert.ToDouble(TextBox_titiklenyapz.Text) * -1);
            perkalianmatriks();
        }
    }
}
