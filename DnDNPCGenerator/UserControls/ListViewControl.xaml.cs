﻿using DnDNPCGenerator.Models;
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

namespace DnDNPCGenerator.UserControls
{
    /// <summary>
    /// Interaction logic for ListViewControl.xaml
    /// </summary>
    public partial class ListViewControl : UserControl
    {
        public Character SetCharacter { get; private set; }
        public ListViewControl()
        {
            InitializeComponent();
            this.DataContext = SetCharacter;
        }
        public ListViewControl(Character characterInput)
        {
            InitializeComponent();
            SetCharacter = characterInput;
            NameLabel.Content = SetCharacter.Name;
            RaceLabel.Content = Utility.Generator.EnumToString(SetCharacter.Race);
            ClassLabel.Content = Utility.Generator.EnumToString(SetCharacter.DnDClass);
            AlignmentLabel.Content = Utility.Generator.EnumToString(SetCharacter.Alignment);
            this.DataContext = SetCharacter;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
