using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        int nl = 0, nph = 0, nzp = 0, nr = 0;
        double rw = 0, rb = 0, kr = 0;
        WindowLayers layers = new WindowLayers(0);
        WindowMesh mesh = new WindowMesh(0);
        WindowPerforations perforations = new WindowPerforations(0);
        WindowPhases phases = new WindowPhases(0);
        List<string> Elems = new List<string>() { "Прямоугольники", "Треугольники" };
        class FinalElements : ObservableCollection<string>
        {
            public FinalElements()
            {
                Add("Прямоугольники");
                Add("Треугольники");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            //Start.Click += StartClick;
            AxisButton.Click += AxisClick;
            DomainButton.Click += DomainClick;
            MeshButton.Click += MeshClick;
            
            ZonesButton.Click += ZoneClick;
            PhaseButton.Click += PhaseClick;
            DavlenieButton.Click += DavlenieClick;

            OpenLayers.Click += OpenLayersClick;
            OpenMesh.Click += OpenMeshClick;
            OpenPhases.Click += OpenPhasesClick;
            OpenZones.Click += OpenZonesClick;
            // Add the TextBox to the visual tree.
        }

        private void OpenZonesClick(object sender, RoutedEventArgs e)
        {
            perforations.ShowDialog();
        }

        private void OpenPhasesClick(object sender, RoutedEventArgs e)
        {
            phases.ShowDialog();
        }

        private void OpenMeshClick(object sender, RoutedEventArgs e)
        {
            mesh.ShowDialog();
        }
        private void DavlenieClick(object sender, RoutedEventArgs e)
        {
            Davlenie.Visibility = (Davlenie.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void DomainClick(object sender, RoutedEventArgs e)
        {
            Domain.Visibility = (Domain.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void MeshClick(object sender, RoutedEventArgs e)
        {
            Mesh.Visibility = (Mesh.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ZoneClick(object sender, RoutedEventArgs e)
        {
            Zone.Visibility = (Zone.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void PhaseClick(object sender, RoutedEventArgs e)
        {
            Phase.Visibility = (Phase.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void NLInput(object sender, TextChangedEventArgs args)
        {

            if (NL.Text != "")
            {
                nl = int.Parse(NL.Text);
                layers = new WindowLayers(nl);
                mesh = new WindowMesh(nl);
            }
            
        }

        private void NphInput(object sender, TextChangedEventArgs args)
        {

            if (Nph.Text != "")
            {
                nph = int.Parse(Nph.Text);
                phases = new WindowPhases(nph);
            }

        }

        private void NzpInput(object sender, TextChangedEventArgs args)
        {

            if (Nzp.Text != "")
            {
                nzp = int.Parse(Nzp.Text);
                perforations = new WindowPerforations(nzp);
            }

        }

        private void OpenLayersClick(object sender, RoutedEventArgs e)
        {
            layers.ShowDialog();
        }

        private void AxisClick(object sender, RoutedEventArgs e)
        {
            Axis.Visibility = (Axis.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }

        //private void StartClick(object sender, RoutedEventArgs e)
        //{
        //    int xMin = 0, xMax = 0, yMin = 0, yMax = 0;
        //    if (valueCoords[0].Text != "")
        //    {
        //        xMin = int.Parse(valueCoords[0].Text);

        //        WriteInt(xMin);
        //    }
        //    if (valueCoords[1].Text != "")
        //    {
        //        xMax = int.Parse(valueCoords[1].Text);
        //        WriteInt(xMax);
        //    }
        //    if (valueCoords[2].Text != "")
        //    {
        //        yMin = int.Parse(valueCoords[2].Text);
        //        WriteInt(yMin);
        //    }

        //    if (valueCoords[3].Text != "")
        //    {
        //        yMax = int.Parse(valueCoords[3].Text);
        //        WriteInt(yMax);
        //    }

        //}

        private void WriteInt(int elem)
        {
            TextBlock txtBlock = new TextBlock();
            txtBlock.Text = Convert.ToString(elem);

            StackPanel1.Children.Add(txtBlock);
        }
    }
}
