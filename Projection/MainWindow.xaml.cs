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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model3DGroup objects = new Model3DGroup();
        public MainWindow()
        {
            InitializeComponent();
            gambarsumbu();
        }
        private void gambarsumbu()
        {
            var sumbux = new MeshBuilder(false, false);
            var sumbuy = new MeshBuilder(false, false);
            var sumbuz = new MeshBuilder(false, false);
            sumbux.AddPipe(new Point3D(-100, 0, 0), new Point3D(100, 0, 0), 0, 0.1, 90);
            sumbuy.AddPipe(new Point3D(0, -100, 0), new Point3D(0, 100, 0), 0, 0.1, 90);
            sumbuz.AddPipe(new Point3D(0, 0, -100), new Point3D(0, 0, 100), 0, 0.1, 90);
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = sumbux.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.DarkRed)
            });
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = sumbuy.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.ForestGreen)
            });
            objects.Children.Add(new GeometryModel3D
            {
                Geometry = sumbuz.ToMesh(true),
                Material = MaterialHelper.CreateMaterial(Colors.RoyalBlue)
            });
            placedobjects.Content = objects;
        }
    }
}
