﻿using System;
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
        public TextBox[] NZ;

        public WindowMesh(int nl)
        {

            InitializeComponent();

            NZ = new TextBox[nl];

            for (int i = 0; i < nl; i++)
            {
                RowDefinition rowInfo = new RowDefinition();
                MeshInfo.RowDefinitions.Add(rowInfo);

                TextBlock numL = new TextBlock();
                numL.Text += i + 1;
                Grid.SetRow(numL, i + 1);
                Grid.SetColumn(numL, 0);
                MeshInfo.Children.Add(numL);

                NZ[i] = new TextBox();
                Grid.SetRow(NZ[i], i + 1);
                Grid.SetColumn(NZ[i], 1);
                MeshInfo.Children.Add(NZ[i]);
            }

            // SaveLayers.Click += SaveLayersClick;
            ExitMesh.Click += ExitMeshClick;
        }

        private void ExitMeshClick(object sender, RoutedEventArgs e)
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
