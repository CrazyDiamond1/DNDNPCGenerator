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

namespace DnDNPCGenerator.Pages
{
    /// <summary>
    /// Interaction logic for ViewCharacters.xaml
    /// </summary>
    public partial class ViewCharacters : Page
    {
        public List<Character> Characters { get; private set; }
        public Character SelectedCharacter { get; private set; }

        public ViewCharacters()
        {
            InitializeComponent();
            this.DataContext = SelectedCharacter;
            Characters = new List<Character>();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCharacter = new Character();
            DisplayCharacterStats();
            Characters.Add(SelectedCharacter);
            AddCharacterItemBoxToCharacterListBox(SelectedCharacter);
        }

        private void AddCharacterItemBoxToCharacterListBox(Character c)
        {
            ListViewControl newListView = new ListViewControl(c);
            CharacterBox.Items.Add(newListView);
        }

        private void CharacterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewControl selectedCharacterItem = (ListViewControl)CharacterBox.Items.GetItemAt(CharacterBox.SelectedIndex);
            SelectedCharacter = selectedCharacterItem.SetCharacter;
            DisplayCharacterStats();
        }

        private void DisplayCharacterStats()
        {
            CharName.Content = SelectedCharacter.Name;
            CharRace.Content = SelectedCharacter.Race;
            CharGender.Content = SelectedCharacter.Gender;
            CharAlignment.Content = SelectedCharacter.Alignment;
            CharClass.Content = SelectedCharacter.DnDClass;
            CharStr.Content = SelectedCharacter.Strength;
            CharDex.Content = SelectedCharacter.Dexterity;
            CharCon.Content = SelectedCharacter.Constitution;
            CharInt.Content = SelectedCharacter.Intelligence;
            CharWis.Content = SelectedCharacter.Wisdom;
            CharChr.Content = SelectedCharacter.Charisma;
        }
    }
}
