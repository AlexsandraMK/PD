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
using System.Windows.Shapes;

namespace PD
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class WindowMesh : Window
    {
        TextBox[] PZ;

        public WindowMesh(int nl)
        {

            InitializeComponent();

            PZ = new TextBox[nl];

            for (int i = 0; i < nl; i++)
            {
                RowDefinition rowInfo = new RowDefinition();
                MeshInfo.RowDefinitions.Add(rowInfo);

                TextBlock numL = new TextBlock();
                numL.Text += i + 1;
                Grid.SetRow(numL, i + 1);
                Grid.SetColumn(numL, 0);
                MeshInfo.Children.Add(numL);

                PZ[i] = new TextBox();
                Grid.SetRow(PZ[i], i + 1);
                Grid.SetColumn(PZ[i], 1);
                MeshInfo.Children.Add(PZ[i]);
            }

            // SaveLayers.Click += SaveLayersClick;
            ExitMesh.Click += ExitMeshClick;
        }

        private void ExitMeshClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
