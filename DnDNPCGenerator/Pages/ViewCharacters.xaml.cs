using DnDNPCGenerator.Enums;
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

        public ViewCharacters(List<Character> characters, Character selected)
        {
            InitializeComponent();
            SelectedCharacter = selected;
            DisplayCharacterStats();
            Characters = characters;
            LoadCharacterListBox();
            if (characters.Count > 0)
            {
                EditButton.Visibility = Visibility.Visible;
            }
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCharacter = new Character();
            DisplayCharacterStats();
            Characters.Add(SelectedCharacter);
            AddCharacterItemBoxToCharacterListBox(SelectedCharacter);
            if(EditButton.Visibility != Visibility.Visible)
            {
                EditButton.Visibility = Visibility.Visible;
            }
        }

        private void LoadCharacterListBox()
        {
            foreach(Character c in Characters)
            {
                AddCharacterItemBoxToCharacterListBox(c);
            }
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
            CharRace.Content = Utility.Utility.EnumToString(SelectedCharacter.Race);
            CharGender.Content = Utility.Utility.EnumToString(SelectedCharacter.Gender);
            CharAlignment.Content = Utility.Utility.EnumToString(SelectedCharacter.Alignment);
            CharClass.Content = Utility.Utility.EnumToString(SelectedCharacter.DnDClass);
            CharStr.Content = SelectedCharacter.Strength;
            CharDex.Content = SelectedCharacter.Dexterity;
            CharCon.Content = SelectedCharacter.Constitution;
            CharInt.Content = SelectedCharacter.Intelligence;
            CharWis.Content = SelectedCharacter.Wisdom;
            CharChr.Content = SelectedCharacter.Charisma;
        }

        private void GenerateOptions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditCharacter editCharPage = new EditCharacter(Characters, SelectedCharacter);
            NavigationService.Navigate(editCharPage);
        }
    }
}
