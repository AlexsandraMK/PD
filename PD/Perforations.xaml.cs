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
    /// Логика взаимодействия для Perforations.xaml
    /// </summary>
    public partial class WindowPerforations : Window
    {
        TextBox[] pu;
        TextBox[] pd;
        TextBox[] theta;
        public WindowPerforations(int nzp)
        {

            InitializeComponent();
            pu = new TextBox[nzp];
            pd = new TextBox[nzp];
            theta = new TextBox[nzp]; //artyom ne pidor

            for (int i = 0; i < nzp; i++)
            {
                RowDefinition rowInfo = new RowDefinition();
                PerforationsInfo.RowDefinitions.Add(rowInfo);

                TextBlock numL = new TextBlock();
                numL.Text += i + 1;
                Grid.SetRow(numL, i + 1);
                Grid.SetColumn(numL, 0);
                PerforationsInfo.Children.Add(numL);

                pu[i] = new TextBox();
                Grid.SetRow(pu[i], i + 1);
                Grid.SetColumn(pu[i], 1);
                PerforationsInfo.Children.Add(pu[i]);

                pd[i] = new TextBox();
                Grid.SetRow(pd[i], i + 1);
                Grid.SetColumn(pd[i], 2);
                PerforationsInfo.Children.Add(pd[i]);

                theta[i] = new TextBox();
                Grid.SetRow(theta[i], i + 1);
                Grid.SetColumn(theta[i], 3);
                PerforationsInfo.Children.Add(theta[i]);
            }

            ExitPerforations.Click += ExitPerforationsClick;
        }
        private void ExitPerforationsClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
