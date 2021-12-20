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
using System.IO;


namespace PD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        int nl = 0, nph = 0, nzp = 0, nr = 0, nw = 0, nph_xy = 0;
        public WindowLayers layers = new WindowLayers(0);
        WindowMesh mesh = new WindowMesh(0);
        WindowPerforations perforations = new WindowPerforations(0);
        WindowPhases phases = new WindowPhases(0);
        WindowWells wellsW = new WindowWells(0);
        WindowPhasesXY phasesxy = new WindowPhasesXY(0);

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


            OurAccuracyButton.Click += OurAccuracyClick;

            XYDomainButton.Click += XYDomainClick;
            XYMeshButton.Click += XYMeshButtonClick;
            WellsButton.Click += WellsButtonClick;
            PhaseXYButton.Click += PhaseXYClick;
            DavlenieXYButton.Click += DavlenieXYClick;

            OpenWells.Click += OpenWellsClick;
            OpenPhasesXY.Click += OpenPhasesXYClick;
            // Add the TextBox to the visual tree.

            Build.Click += BuildMesh;

        }

        void BuildAxis()
        {
            Grafic1.Children.Clear();

            Line vertL = new Line();
            vertL.X1 = 20;
            vertL.Y1 = 5;
            vertL.X2 = 20;
            vertL.Y2 = 465;
            vertL.Stroke = Brushes.Black;
            Grafic1.Children.Add(vertL);
            Line horL = new Line();
            horL.X1 = 5;
            horL.Y1 = 20;
            horL.X2 = 780;
            horL.Y2 = 20;
            horL.Stroke = Brushes.Black;
            Grafic1.Children.Add(horL);

            Polyline vertArr = new Polyline();
            vertArr.Points = new PointCollection();
            vertArr.Points.Add(new Point(15, 10));
            vertArr.Points.Add(new Point(20, 5));
            vertArr.Points.Add(new Point(25, 10));
            vertArr.Stroke = Brushes.Black;
            Grafic1.Children.Add(vertArr);
            Polyline horArr = new Polyline();
            horArr.Points = new PointCollection();
            horArr.Points.Add(new Point(775, 15));
            horArr.Points.Add(new Point(780, 20));
            horArr.Points.Add(new Point(775, 25));
            horArr.Stroke = Brushes.Black;
            Grafic1.Children.Add(horArr);

            Grafic2.Children.Clear();

            Line vertL1 = new Line();
            vertL1.X1 = 20;
            vertL1.Y1 = 5;
            vertL1.X2 = 20;
            vertL1.Y2 = 465;
            vertL1.Stroke = Brushes.Black;
            Grafic2.Children.Add(vertL1);
            Line horL1 = new Line();
            horL1.X1 = 5;
            horL1.Y1 = 20;
            horL1.X2 = 780;
            horL1.Y2 = 20;
            horL1.Stroke = Brushes.Black;
            Grafic2.Children.Add(horL1);

            Polyline vertArr1 = new Polyline();
            vertArr1.Points = new PointCollection();
            vertArr1.Points.Add(new Point(15, 10));
            vertArr1.Points.Add(new Point(20, 5));
            vertArr1.Points.Add(new Point(25, 10));
            vertArr1.Stroke = Brushes.Black;
            Grafic2.Children.Add(vertArr1);
            Polyline horArr1 = new Polyline();
            horArr1.Points = new PointCollection();
            horArr1.Points.Add(new Point(775, 15));
            horArr1.Points.Add(new Point(780, 20));
            horArr1.Points.Add(new Point(775, 25));
            horArr1.Stroke = Brushes.Black;
            Grafic2.Children.Add(horArr1);
        }

        void BuildAxisXY()
        {
            Grafic2.Children.Clear();

            Line vertL1 = new Line();
            vertL1.X1 = 20;
            vertL1.Y1 = 5;
            vertL1.X2 = 20;
            vertL1.Y2 = 465;
            vertL1.Stroke = Brushes.Black;
            Grafic2.Children.Add(vertL1);
            Line horL1 = new Line();
            horL1.X1 = 5;
            horL1.Y1 = 20;
            horL1.X2 = 780;
            horL1.Y2 = 20;
            horL1.Stroke = Brushes.Black;
            Grafic2.Children.Add(horL1);

            Polyline vertArr1 = new Polyline();
            vertArr1.Points = new PointCollection();
            vertArr1.Points.Add(new Point(15, 10));
            vertArr1.Points.Add(new Point(20, 5));
            vertArr1.Points.Add(new Point(25, 10));
            vertArr1.Stroke = Brushes.Black;
            Grafic2.Children.Add(vertArr1);
            Polyline horArr1 = new Polyline();
            horArr1.Points = new PointCollection();
            horArr1.Points.Add(new Point(775, 15));
            horArr1.Points.Add(new Point(780, 20));
            horArr1.Points.Add(new Point(775, 25));
            horArr1.Stroke = Brushes.Black;
            Grafic2.Children.Add(horArr1);
        }

        private void BuildMesh(object sender, RoutedEventArgs e)
        {
            BuildAxis();
            double rw = Convert.ToDouble(Rw.Text), rb = Convert.ToDouble(Rb.Text);
            double vertNorm = 0, horNorm = 0;

            vertNorm = 740 / rb; //по сути норма для пропорционального размещения на оси

            for (int i = 0; i < nl; i++)
                horNorm += Convert.ToDouble(layers.HL[i].Text);

            horNorm = 440 / horNorm;

            Line rwL = new Line();
            rwL.X1 = 20 + rw * vertNorm; //20 + из-за оси смещенной на 20 единиц
            rwL.Y1 = 20;
            rwL.X2 = 20 + rw * vertNorm;
            rwL.Y2 = 460;
            rwL.Stroke = Brushes.Blue;
            rwL.StrokeDashCap = PenLineCap.Flat;
            rwL.StrokeDashArray = new DoubleCollection() { 2, 2 };
            Grafic1.Children.Add(rwL);

            Line rbL = new Line();
            rbL.X1 = 20 + rb * vertNorm;
            rbL.Y1 = 20;
            rbL.X2 = 20 + rb * vertNorm;
            rbL.Y2 = 460;
            rbL.Stroke = Brushes.Blue;
            rbL.StrokeDashCap = PenLineCap.Flat;
            rbL.StrokeDashArray = new DoubleCollection() { 2, 2 };
            Grafic1.Children.Add(rbL);

            double temp = 0;
            for (int i = 0; i < nl; i++)
            {
                Line L = new Line();
                L.X1 = 20;
                L.Y1 = 20 + Convert.ToDouble(layers.HL[i].Text) * horNorm + temp;
                L.X2 = 20 + rb * vertNorm;
                L.Y2 = 20 + Convert.ToDouble(layers.HL[i].Text) * horNorm + temp;
                L.Stroke = Brushes.Red;
                L.StrokeDashCap = PenLineCap.Flat;
                L.StrokeDashArray = new DoubleCollection() { 2, 2 };
                Grafic1.Children.Add(L);
                temp += Convert.ToDouble(layers.HL[i].Text) * horNorm;
            }

            //**************после считывания вершин, рисуем элементы ***************************************//***************************************//
            StreamReader nodeReader = new StreamReader("node.txt", Encoding.UTF8);
            int numNodes = Int32.Parse(nodeReader.ReadLine());
            Point[] nodes = new Point[numNodes];
            for (int i = 0; i < numNodes; i++)
            {
                string text = nodeReader.ReadLine();
                string[] bits = text.Split(' ');
                nodes[i].Offset(20 + double.Parse(bits[0].Replace('.', ',')) * vertNorm, 20 + double.Parse(bits[1].Replace('.', ',')) * horNorm);
                //nodes[i].X = 20 + nodeReader.Read();
                //nodes[i].Y = 20 + nodeReader.Read() ;
            }
            nodeReader.Close();

            StreamReader elemReader = new StreamReader("elem.txt", Encoding.UTF8);
            int numElem = Int32.Parse(elemReader.ReadLine());
            //int[,] numNodesElem = new int[numElem, 3];
            int[,] numNodesElem = new int[numElem, 4]; //для прямоугольников
            for (int i = 0; i < numElem; i++)
            {
                string text = elemReader.ReadLine();
                string[] bits = text.Split(' ');
                numNodesElem[i, 0] = Int32.Parse(bits[0]);
                numNodesElem[i, 1] = Int32.Parse(bits[1]);
                numNodesElem[i, 2] = Int32.Parse(bits[2]);
                numNodesElem[i, 3] = Int32.Parse(bits[3]);//для прямоугольников
            }
            //***************************************//***************************************//
            elemReader.Close();
            List<Polygon> elem = new List<Polygon>();
            for (int i = 0; i < numElem; i++)
            {
                /*Polygon triad = new Polygon();
                for (int k = 0; k < 3; k++)
                    triad.Points.Add(nodes[numNodesElem[i, k]]);
                triad.Stroke = Brushes.Black;
                elem.Add(triad);
                Grafic1.Children.Add(triad);*/

                Polygon rectangle = new Polygon();
                //for (int k = 0; k < 4; k++)
                //    rectangle.Points.Add(nodes[numNodesElem[i, k]]);   //проблема с узлами из-за 0 1 9 10    0    1       надо 0 1 10 9
                                                                         //потому что они расположены так =>   9    10      или иначе, но по граням
                rectangle.Points.Add(nodes[numNodesElem[i, 0]]);
                rectangle.Points.Add(nodes[numNodesElem[i, 1]]);
                rectangle.Points.Add(nodes[numNodesElem[i, 3]]);
                rectangle.Points.Add(nodes[numNodesElem[i, 2]]);
                rectangle.Stroke = Brushes.Black;
                rectangle.StrokeThickness = 0.5;
                elem.Add(rectangle);
                Grafic1.Children.Add(rectangle);
            }
        }

        private void BuildMeshXY(object sender, RoutedEventArgs e)
        {
            BuildAxisXY();
            double xmin = Convert.ToDouble(Xmin.Text), ymin = Convert.ToDouble(Ymin.Text),
                xmax = Convert.ToDouble(Xmax.Text), ymax = Convert.ToDouble(Ymax.Text);

            double vertNorm = 440 / (ymax - ymin),
            horNorm = 740 / (xmax - xmin);

            Line xmaxL = new Line();
            xmaxL.X1 = 20 + (xmax - xmin) * horNorm;
            xmaxL.Y1 = 20;
            xmaxL.X2 = 20 + (xmax - xmin) * horNorm;
            xmaxL.Y2 = 460;
            xmaxL.Stroke = Brushes.Blue;
            xmaxL.StrokeDashCap = PenLineCap.Flat;
            xmaxL.StrokeDashArray = new DoubleCollection() { 2, 2 };
            Grafic2.Children.Add(xmaxL);

            Line ymaxL = new Line();
            ymaxL.X1 = 20;
            ymaxL.Y1 = 20 + (ymax - ymin) * vertNorm;
            ymaxL.X2 = 780;
            ymaxL.Y2 = 20 + (ymax - ymin) * vertNorm;
            ymaxL.Stroke = Brushes.Blue;
            ymaxL.StrokeDashCap = PenLineCap.Flat;
            ymaxL.StrokeDashArray = new DoubleCollection() { 2, 2 };
            Grafic2.Children.Add(ymaxL);

            for (int i = 0; i < nw; i++)
            {
                Line L1 = new Line();
                L1.X1 = 20;
                L1.Y1 = 20 + (Convert.ToDouble(wellsW.wy[i].Text) - ymin) * vertNorm;
                L1.X2 = 760;
                L1.Y2 = 20 + (Convert.ToDouble(wellsW.wy[i].Text) - ymin) * vertNorm;
                L1.Stroke = Brushes.Red;
                L1.StrokeDashCap = PenLineCap.Flat;
                L1.StrokeDashArray = new DoubleCollection() { 2, 2 };
                Grafic2.Children.Add(L1);
                Line L2 = new Line();
                L2.X1 = 20 + (Convert.ToDouble(wellsW.wx[i].Text) - xmin) * horNorm;
                L2.Y1 = 20;
                L2.X2 = 20 + (Convert.ToDouble(wellsW.wx[i].Text) - xmin) * horNorm;
                L2.Y2 = 460;
                L2.Stroke = Brushes.Red;
                L2.StrokeDashCap = PenLineCap.Flat;
                L2.StrokeDashArray = new DoubleCollection() { 2, 2 };
                Grafic2.Children.Add(L2);
                System.Windows.Shapes.Path p = new System.Windows.Shapes.Path();
                GeometryGroup ellipses = new GeometryGroup();
                EllipseGeometry ellipse = new EllipseGeometry(new Point(20 + (Convert.ToDouble(wellsW.wx[i].Text) - xmin) * horNorm, 20 + (Convert.ToDouble(wellsW.wy[i].Text) - ymin) * vertNorm), 5, 5);
                ellipses.Children.Add(ellipse);
                p.Data = ellipses;
                p.Fill = Brushes.Red;
                Grafic2.Children.Add(p);
            }

            //**************после считывания вершин, рисуем элементы 
            //***************************************//***************************************//
            //StreamReader nodeReader = new StreamReader("nodes.txt");
            //numNodes = nodeReader.Read();
            //Point[] nodes = new Point[numNodes];
            //for (int i = 0; i < numNodes; i++)
            //{
            //    nodes[i].X = 20 + nodeReader.Read() * horNorm;
            //    nodes[i].Y = 20 + nodeReader.Read() * vertNorm;
            //}

            //StreamReader elemReader = new StreamReader("elem.txt");
            //numElem = elemReader.Read();
            //int[,] numNodesElem = new int[numElem, 3];
            //int[,] numNodesElem = new int[numElem, 4]; //для прямоугольников
            //for (int i = 0; i < numElem; i++)
            //{
            //    numNodesElem[i, 0] = elemReader.Read();
            //    numNodesElem[i, 1] = elemReader.Read();
            //    numNodesElem[i, 2] = elemReader.Read();
            //    //numNodesElem[i, 3] = elemReader.Read();//для прямоугольников
            //}
            //***************************************//***************************************//

            //List<Polygon> elem = new List<Polygon>();
            //for (int i = 0; i < numElem; i++)
            //{
            //    Polygon triad = new Polygon();
            //    for (int k = 0; k < 3; k++)
            //         triad.Points.Add(nodes[numNodesElem[i, k]]);
            //    triad.Stroke = Brushes.Black;
            //    elem.Add(triad);
            //    Grafic2.Children.Add(triad);

            //    Polygon rectangle = new Polygon();
            //    for (int k = 0; k < 4; k++)
            //         rectangle.Points.Add(nodes[numNodesElem[i, k]]);
            //    rectangle.Stroke = Brushes.Black;
            //    elem.Add(rectangle);
            //    Grafic2.Children.Add(rectangle);
            //}
        }

        private void PhaseXYClick(object sender, RoutedEventArgs e)
        {
            PhaseXY.Visibility = (PhaseXY.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void DavlenieXYClick(object sender, RoutedEventArgs e)
        {
            DavlenieXY.Visibility = (DavlenieXY.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void OpenPhasesXYClick(object sender, RoutedEventArgs e)
        {
            phasesxy.ShowDialog();
        }
        private void OpenWellsClick(object sender, RoutedEventArgs e)
        {
            wellsW.ShowDialog();
        }
        private void WellsButtonClick(object sender, RoutedEventArgs e)
        {
            Wells.Visibility = (Wells.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void XYMeshButtonClick(object sender, RoutedEventArgs e)
        {
            XYMesh.Visibility = (XYMesh.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void OurAccuracyClick(object sender, RoutedEventArgs e)
        {
            XY_Axis.Visibility = (XY_Axis.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void XYDomainClick(object sender, RoutedEventArgs e)
        {
            XYDomain.Visibility = (XYDomain.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
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

        private void AxisButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NwInput(object sender, TextChangedEventArgs args)
        {

            if (Nw.Text != "")
            {
                nw = int.Parse(Nw.Text);
                wellsW = new WindowWells(nw);
            }

        }

        private void NphXYInput(object sender, TextChangedEventArgs args)
        {

            if (NphXY.Text != "")
            {
                nph_xy = int.Parse(NphXY.Text);
                phasesxy = new WindowPhasesXY(nph_xy);
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

        private void StartClick(object sender, RoutedEventArgs e)
        {
            StreamWriter domain = new StreamWriter("domain.txt");
            domain.WriteLine(Rw.Text);
            domain.WriteLine(Rb.Text);
            domain.WriteLine(nl);
            for (int i = 0; i < nl; i++)
                domain.WriteLine(layers.HL[i].Text + "\t" + layers.KL[i].Text + "\t" + layers.Phi[i].Text + "\t" + layers.SOil[i].Text);
            domain.Close();

            StreamWriter mesh_rz = new StreamWriter("mesh_rz.txt");
            mesh_rz.WriteLine(Nr.Text);
            mesh_rz.WriteLine(Kr.Text);
            for (int i = 0; i < nl; i++)
                mesh_rz.WriteLine(mesh.NZ[i].Text);
            mesh_rz.Close();

            StreamWriter zone_perf_rz = new StreamWriter("zone_perf_rz.txt");
            zone_perf_rz.WriteLine(nzp);
            for (int i = 0; i < nzp; i++)
                mesh_rz.WriteLine(perforations.pu[i].Text + "\t"+ perforations.pd[i].Text + "\t" + perforations.theta[i].Text);
            zone_perf_rz.Close();

            StreamWriter phaseprop = new StreamWriter("phaseprop.txt");
            phaseprop.WriteLine(nph);
            for (int i = 0; i < nph; i++)
                phaseprop.WriteLine(phases.Mu[i].Text);

            StreamWriter plast = new StreamWriter("plast.txt");
            plast.WriteLine(P.Text);

            StreamWriter domain_xy = new StreamWriter("domain_xy.txt");
            domain_xy.WriteLine(Xmin.Text);
            domain_xy.WriteLine(Xmax.Text);
            domain_xy.WriteLine(Ymin.Text);
            domain_xy.WriteLine(Ymax.Text);
            domain_xy.WriteLine(K_xy.Text);
            domain_xy.WriteLine(Phi_xy.Text);
            domain_xy.WriteLine(SOil_xy.Text);

            StreamWriter mesh_xy = new StreamWriter("mesh_xy.txt");
            mesh_xy.WriteLine(Nx.Text);
            mesh_xy.WriteLine(Ny.Text);
            mesh_xy.WriteLine(kw.Text);

            StreamWriter wells = new StreamWriter("wells.txt");
            wells.WriteLine(nw);
            for (int i = 0; i < nw; i++)
                phaseprop.WriteLine(wellsW.wx[i].Text + "\t" + wellsW.wy[i].Text + "\t" + wellsW.tetta[i].Text);

            StreamWriter phaseprop_xy = new StreamWriter("phaseprop_xy.txt");
            phaseprop_xy.WriteLine(nph_xy);
            for (int i = 0; i < nph_xy; i++)
                phaseprop_xy.WriteLine(phasesxy.MuXY[i].Text);

            StreamWriter plast_xy = new StreamWriter("plast_xy.txt");
            plast_xy.WriteLine(PXY.Text);
        }
    }
}
