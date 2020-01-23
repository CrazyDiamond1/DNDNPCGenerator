using DnDNPCGenerator.Models;
using DnDNPCGenerator.UserControls;
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

namespace DnDNPCGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Character> Characters { get; private set; }
        public Character SelectedCharacter { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = SelectedCharacter;
            Characters = new List<Character>();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            Character character = new Character();
            CharName.Content = character.Name;
            CharRace.Content = character.Race;
            CharAlignment.Content = character.Alignment;
            CharClass.Content = character.DnDClass;
            CharStr.Content = character.Strength;
            CharDex.Content = character.Dexterity;
            CharCon.Content = character.Constitution;
            CharInt.Content = character.Intelligence;
            CharWis.Content = character.Wisdom;
            CharChr.Content = character.Charisma;
            Characters.Add(character);
            SelectedCharacter = character;
            AddCharacterItemBoxToCharacterListBox(character);
        }

        private void AddCharacterItemBoxToCharacterListBox(Character c)
        {
            ListViewControl newListView = new ListViewControl(c);
            CharacterBox.Items.Add(newListView);
        }

        private void CharacterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewControl selected = (ListViewControl)CharacterBox.Items.GetItemAt(CharacterBox.SelectedIndex);
            SelectedCharacter = selected.SetCharacter;
            CharName.Content = selected.SetCharacter.Name;
            CharRace.Content = selected.SetCharacter.Race;
            CharAlignment.Content = selected.SetCharacter.Alignment;
            CharClass.Content = selected.SetCharacter.DnDClass;
            CharStr.Content = selected.SetCharacter.Strength;
            CharDex.Content = selected.SetCharacter.Dexterity;
            CharCon.Content = selected.SetCharacter.Constitution;
            CharInt.Content = selected.SetCharacter.Intelligence;
            CharWis.Content = selected.SetCharacter.Wisdom;
            CharChr.Content = selected.SetCharacter.Charisma;
        }
    }
}
