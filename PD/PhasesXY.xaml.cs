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
    /// Логика взаимодействия для Phases.xaml
    /// </summary>
    public partial class WindowPhasesXY : Window
    {
        public TextBox[] MuXY;
        public WindowPhasesXY(int nph)
        {
            InitializeComponent();

            MuXY = new TextBox[nph];

            for (int i = 0; i < nph; i++)
            {
                RowDefinition rowInfo = new RowDefinition();
                PhasesXYInfo.RowDefinitions.Add(rowInfo);

                TextBlock numL = new TextBlock();
                numL.Text += i + 1;
                Grid.SetRow(numL, i + 1);
                Grid.SetColumn(numL, 0);
                PhasesXYInfo.Children.Add(numL);

                MuXY[i] = new TextBox();
                Grid.SetRow(MuXY[i], i + 1);
                Grid.SetColumn(MuXY[i], 1);
                PhasesXYInfo.Children.Add(MuXY[i]);
            }

            ExitPhasesXY.Click += ExitPhasesXYClick;
        }

        private void ExitPhasesXYClick(object sender, RoutedEventArgs e)
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
