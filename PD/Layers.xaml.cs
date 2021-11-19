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
    public partial class WindowLayers : Window
    {
        TextBox[] HL;
        TextBox[] KL;
        TextBox[] Phi;
        TextBox[] SOil;
        public WindowLayers(int nl)
        {

            InitializeComponent();

            HL = new TextBox[nl];
            KL = new TextBox[nl];
            Phi = new TextBox[nl];
            SOil = new TextBox[nl];

            for (int i = 0; i < nl; i++)
            {
                RowDefinition rowInfo = new RowDefinition();
                LayersInfo.RowDefinitions.Add(rowInfo);

                TextBlock numL = new TextBlock();
                numL.Text += i + 1;
                Grid.SetRow(numL, i + 1);
                Grid.SetColumn(numL, 0);
                LayersInfo.Children.Add(numL);

                HL[i] = new TextBox();
                Grid.SetRow(HL[i], i + 1);
                Grid.SetColumn(HL[i], 1);
                LayersInfo.Children.Add(HL[i]);

                KL[i] = new TextBox();
                Grid.SetRow(KL[i], i + 1);
                Grid.SetColumn(KL[i], 2);
                LayersInfo.Children.Add(KL[i]);

                Phi[i] = new TextBox();
                Grid.SetRow(Phi[i], i + 1);
                Grid.SetColumn(Phi[i], 3);
                LayersInfo.Children.Add(Phi[i]);

                SOil[i] = new TextBox();
                Grid.SetRow(SOil[i], i + 1);
                Grid.SetColumn(SOil[i], 4);
                LayersInfo.Children.Add(SOil[i]);
            }
            
           // SaveLayers.Click += SaveLayersClick;
            ExitLayers.Click += ExitLayersClick;
        }

        private void ExitLayersClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        //private void SaveLayersClick(object sender, RoutedEventArgs e)
        //{
        //    StreamWriter LayersFile = new StreamWriter("domain_rz.txt");
           
        //    LayersFile.WriteLine(MainWindow.rw);
        //    LayersFile.WriteLine(MainWindow.rb);
        //    LayersFile.WriteLine(MainWindow.nl);
        //    for (int i = 0; i < MainWindow.nl; i++)
        //    {
        //        LayersFile.WriteLine(HL[i].Text + "\t" + KL[i].Text + "\t" + Phi[i].Text + "\t" + SOil[i].Text);
        //    }
        //    LayersFile.Close();
        //}
    }
}
