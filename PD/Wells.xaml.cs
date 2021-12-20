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
using System.Windows.Shapes;

namespace PD
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class WindowWells : Window
    {
        public TextBox[] wx;
        public TextBox[] wy;
        public TextBox[] tetta;
        public WindowWells(int nw)
        {
            InitializeComponent();
            wx = new TextBox[nw];
            wy = new TextBox[nw];
            tetta = new TextBox[nw]; //artyom ne pidor

            for (int i = 0; i < nw; i++)
            {
                RowDefinition rowInfo = new RowDefinition();
                WellsInfo.RowDefinitions.Add(rowInfo);

                TextBlock numL = new TextBlock();
                numL.Text += i + 1;
                Grid.SetRow(numL, i + 1);
                Grid.SetColumn(numL, 0);
                WellsInfo.Children.Add(numL);

                wx[i] = new TextBox();
                Grid.SetRow(wx[i], i + 1);
                Grid.SetColumn(wx[i], 1);
                WellsInfo.Children.Add(wx[i]);

                wy[i] = new TextBox();
                Grid.SetRow(wy[i], i + 1);
                Grid.SetColumn(wy[i], 2);
                WellsInfo.Children.Add(wy[i]);

                tetta[i] = new TextBox();
                Grid.SetRow(tetta[i], i + 1);
                Grid.SetColumn(tetta[i], 3);
                WellsInfo.Children.Add(tetta[i]);
            }

            ExitWells.Click += ExitWellsClick;
        }
        private void ExitWellsClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

