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
    public partial class WindowPhases : Window
    {
        TextBox[] Mu;
        public WindowPhases(int nph)
        {
            InitializeComponent();

         Mu = new TextBox[nph];

         for (int i = 0; i < nph; i++)
         {
            RowDefinition rowInfo = new RowDefinition();
            PhasesInfo.RowDefinitions.Add(rowInfo);

            TextBlock numL = new TextBlock();
            numL.Text += i + 1;
            Grid.SetRow(numL, i + 1);
            Grid.SetColumn(numL, 0);
            PhasesInfo.Children.Add(numL);

            Mu[i] = new TextBox();
            Grid.SetRow(Mu[i], i + 1);
            Grid.SetColumn(Mu[i], 1);
            PhasesInfo.Children.Add(Mu[i]);
         }

         ExitPhases.Click += ExitPhasesClick;
      }

      private void ExitPhasesClick(object sender, RoutedEventArgs e)
      {
         Hide();
      }

   }
}
