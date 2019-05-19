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
        Point3D[] titik = new Point3D[18] {
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
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0),
                new Point3D(0,0,0)
        };
        Point3D[] titik2 = new Point3D[10] {
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
            TextBox_panjangrumahx.TextChanged += TextBox_panjangrumahx_TextChanged;
            TextBox_panjangrumahy.TextChanged += TextBox_panjangrumahy_TextChanged;
            TextBox_panjangrumahz.TextChanged += TextBox_panjangrumahz_TextChanged;
            TextBox_posisiobjekx.TextChanged += TextBox_posisiobjekx_TextChanged;
            TextBox_posisiobjeky.TextChanged += TextBox_posisiobjeky_TextChanged;
            TextBox_posisiobjekz.TextChanged += TextBox_posisiobjekz_TextChanged;
            TextBox_titiklenyapz.TextChanged += TextBox_titiklenyapz_TextChanged;
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
            titik[14] = new Point3D(x - (px / 3), y - (py / 2), z + (pz / 6));
            titik[15] = new Point3D(x - (px / 3), y - (py / 2), z + (pz / 3));
            titik[16] = new Point3D(x, y - (py / 2), z + (pz / 3));
            titik[17] = new Point3D(x, y - (py / 2), z + (pz / 6));
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
            kerangkarumah.AddPipe(titik[0], titik[1], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[1], titik[2], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[2], titik[3], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[3], titik[0], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[4], titik[5], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[5], titik[6], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[6], titik[7], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[7], titik[4], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[0], titik[4], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[1], titik[5], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[2], titik[6], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[3], titik[7], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[4], titik[8], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[5], titik[8], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[6], titik[9], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[7], titik[9], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[9], titik[8], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[10], titik[11], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[11], titik[12], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[12], titik[13], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[14], titik[15], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[15], titik[16], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[16], titik[17], 0, 0.1, 90);
            kerangkarumah.AddPipe(titik[17], titik[14], 0, 0.1, 90);
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
        private void gambarproyeksi()
        {
            var tembokrumah = new MeshBuilder(false, false);
            var ataprumah = new MeshBuilder(false, false);
            var garisproyeksi = new MeshBuilder(false, false);
            tembokrumah.AddBox(new Point3D((titik2[0].X + titik2[2].X) / 2, (titik2[0].Y + titik2[2].Y) / 2, (titik2[0].Z + titik2[2].Z) / 2), (titik2[2].X - titik2[0].X), (titik2[2].Y - titik2[0].Y), (titik2[2].Z - titik2[0].Z));
            tembokrumah.AddBox(new Point3D((titik2[0].X + titik2[5].X) / 2, (titik2[0].Y + titik2[5].Y) / 2, (titik2[0].Z + titik2[5].Z) / 2), (titik2[5].X - titik2[0].X), (titik2[5].Y - titik2[0].Y), (titik2[5].Z - titik2[0].Z));
            tembokrumah.AddBox(new Point3D((titik2[1].X + titik2[6].X) / 2, (titik2[1].Y + titik2[6].Y) / 2, (titik2[1].Z + titik2[6].Z) / 2), (titik2[6].X - titik2[1].X), (titik2[6].Y - titik2[1].Y), (titik2[6].Z - titik2[1].Z));
            tembokrumah.AddBox(new Point3D((titik2[2].X + titik2[7].X) / 2, (titik2[2].Y + titik2[7].Y) / 2, (titik2[2].Z + titik2[7].Z) / 2), (titik2[7].X - titik2[2].X), (titik2[7].Y - titik2[2].Y), (titik2[7].Z - titik2[2].Z));
            tembokrumah.AddBox(new Point3D((titik2[3].X + titik2[4].X) / 2, (titik2[3].Y + titik2[4].Y) / 2, (titik2[3].Z + titik2[4].Z) / 2), (titik2[4].X - titik2[3].X), (titik2[4].Y - titik2[3].Y), (titik2[4].Z - titik2[3].Z));
            ataprumah.AddTriangle(titik2[4], titik2[5], titik2[8]);
            ataprumah.AddTriangle(titik2[6], titik2[7], titik2[9]);
            ataprumah.AddTriangle(titik2[5], titik2[6], titik2[8]);
            ataprumah.AddTriangle(titik2[7], titik2[4], titik2[8]);
            ataprumah.AddTriangle(titik2[9], titik2[8], titik2[6]);
            ataprumah.AddTriangle(titik2[8], titik2[9], titik2[7]);
            var titikproyeksi = new Point3D(0, 0, Convert.ToDouble(TextBox_titiklenyapz.Text));
            garisproyeksi.AddPipe(titikproyeksi, titik[0], 0, 0.02, 90);
            garisproyeksi.AddPipe(titikproyeksi, titik[1], 0, 0.02, 90);
            garisproyeksi.AddPipe(titikproyeksi, titik[2], 0, 0.02, 90);
            garisproyeksi.AddPipe(titikproyeksi, titik[3], 0, 0.02, 90);
            garisproyeksi.AddPipe(titikproyeksi, titik[4], 0, 0.02, 90);
            garisproyeksi.AddPipe(titikproyeksi, titik[5], 0, 0.02, 90);
            garisproyeksi.AddPipe(titikproyeksi, titik[6], 0, 0.02, 90);
            garisproyeksi.AddPipe(titikproyeksi, titik[7], 0, 0.02, 90);
            garisproyeksi.AddPipe(titikproyeksi, titik[8], 0, 0.02, 90);
            garisproyeksi.AddPipe(titikproyeksi, titik[9], 0, 0.02, 90);
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = garisproyeksi.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.Yellow)
            });
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = tembokrumah.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.DarkGray)
            });
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = ataprumah.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.DarkGray)
            });
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
            for (int h = 0; h < 10; h++)
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
                titik2[h].X = Math.Round(tempx / temp4,4);
                titik2[h].Y = Math.Round(tempy / temp4,4);
                titik2[h].Z = Math.Round(tempz / temp4,4);
            }
            resetmatrikstransform();
            updateposisi();
            gambarproyeksi();
        }
        private void updateposisi()
        {
            Label_titik1.Content = titik2[0].ToString();
            Label_titik2.Content = titik2[1].ToString();
            Label_titik3.Content = titik2[2].ToString();
            Label_titik4.Content = titik2[3].ToString();
            Label_titik5.Content = titik2[4].ToString();
            Label_titik6.Content = titik2[5].ToString();
            Label_titik7.Content = titik2[6].ToString();
            Label_titik8.Content = titik2[7].ToString();
            Label_titik9.Content = titik2[8].ToString();
            Label_titik10.Content = titik2[9].ToString();
        }
        private void execute()
        {
            koordinatrumah(Convert.ToDouble(TextBox_posisiobjekx.Text), Convert.ToDouble(TextBox_posisiobjeky.Text), Convert.ToDouble(TextBox_posisiobjekz.Text), Convert.ToDouble(TextBox_panjangrumahx.Text), Convert.ToDouble(TextBox_panjangrumahy.Text), Convert.ToDouble(TextBox_panjangrumahz.Text));
            proyeksi();
        }
        private void proyeksi()
        {
            resetmatrikstransform();
            matriks[0, 0] = 1;
            matriks[1, 1] = 1;
            matriks[3, 3] = 1;
            matriks[3, 2] = 1 / (Convert.ToDouble(TextBox_titiklenyapz.Text) * -1);
            perkalianmatriks();
        }
        private void Button_buatobjek_Click(object sender, RoutedEventArgs e)
        {
            execute();
        }
        private void TextBox_titiklenyapz_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TextBox_titiklenyapz.Text, out int n))
            {
                execute();
            }
        }

        private void TextBox_posisiobjekx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TextBox_posisiobjekx.Text, out int n))
            {
                execute();
            }
        }

        private void TextBox_posisiobjeky_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TextBox_posisiobjeky.Text, out int n))
            {
                execute();
            }
        }

        private void TextBox_posisiobjekz_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TextBox_posisiobjekz.Text, out int n))
            {
                execute();
            }
        }

        private void TextBox_panjangrumahx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TextBox_panjangrumahx.Text, out int n))
            {
                if (n > 0) execute();
            }
        }

        private void TextBox_panjangrumahy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TextBox_panjangrumahy.Text, out int n))
            {
                if (n>0) execute();
            }
        }

        private void TextBox_panjangrumahz_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TextBox_panjangrumahz.Text, out int n))
            {
                if (n > 0) execute();
            }
        }
    }
}
