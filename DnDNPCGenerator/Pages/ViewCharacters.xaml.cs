using DnDNPCGenerator.Enums;
using DnDNPCGenerator.Models;
using DnDNPCGenerator.UserControls;
using DnDNPCGenerator.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObservableCollection<Character> Characters { get; private set; }
        public Character SelectedCharacter { get; private set; }

        public ViewCharacters()
        {
            InitializeComponent();
            this.DataContext = SelectedCharacter;
            Characters = Seralizer.DeserializeCharacters();
            LoadCharacterListBox();
            if (Characters.Count > 0)
            {
                EditButton.Visibility = Visibility.Visible;
                SelectedCharacter = Characters[0];
                DisplayCharacterStats();
            }
        }

        public ViewCharacters(ObservableCollection<Character> characters, Character selected)
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
            SelectedCharacter = new Character(false);
            DisplayCharacterStats();
            Characters.Add(SelectedCharacter);
            AddCharacterItemBoxToCharacterListBox(SelectedCharacter);
            if (EditButton.Visibility != Visibility.Visible)
            {
                EditButton.Visibility = Visibility.Visible;
            }
            Seralizer.SerializeCharacters(Characters);
        }

        private void LoadCharacterListBox()
        {
            foreach (Character c in Characters)
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
            CharRace.Content = Generator.EnumToString(SelectedCharacter.Race);
            CharGender.Content = Generator.EnumToString(SelectedCharacter.Gender);
            CharAlignment.Content = Generator.EnumToString(SelectedCharacter.Alignment);
            CharClass.Content = Generator.EnumToString(SelectedCharacter.DnDClass);
            CharStr.Content = SelectedCharacter.Strength;
            CharStrMod.Content = Generator.GetStatModifier(SelectedCharacter.Strength);
            CharDex.Content = SelectedCharacter.Dexterity;
            CharDexMod.Content = Generator.GetStatModifier(SelectedCharacter.Dexterity);
            CharCon.Content = SelectedCharacter.Constitution;
            CharConMod.Content = Generator.GetStatModifier(SelectedCharacter.Constitution);
            CharInt.Content = SelectedCharacter.Intelligence;
            CharIntMod.Content = Generator.GetStatModifier(SelectedCharacter.Intelligence);
            CharWis.Content = SelectedCharacter.Wisdom;
            CharWisMod.Content = Generator.GetStatModifier(SelectedCharacter.Wisdom);
            CharChr.Content = SelectedCharacter.Charisma;
            CharChrMod.Content = Generator.GetStatModifier(SelectedCharacter.Charisma);
            NotesContent.Content = SelectedCharacter.Notes;
            UpdateCharacterPortrait();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditCharacter editCharPage = new EditCharacter(Characters, SelectedCharacter);
            NavigationService.Navigate(editCharPage);
        }

        private void NewCharacter_Click(object sender, RoutedEventArgs e)
        {
            EditCharacter editCharPage = new EditCharacter(Characters, new Character(true));
            NavigationService.Navigate(editCharPage);
        }

        private void UpdateCharacterPortrait()
        {
            string headString = @"/DnDNPCGenerator;component/Images/CharacterPortraits/" + SelectedCharacter.Race.ToString() + "_" + SelectedCharacter.Gender.ToString() + "_HEAD.png";
            string handsString = @"/DnDNPCGenerator;component/Images/CharacterPortraits/" + SelectedCharacter.Race.ToString() + "_HANDS.png";
            string torsoString = @"/DnDNPCGenerator;component/Images/CharacterPortraits/" + SelectedCharacter.DnDClass.ToString() + "_" + SelectedCharacter.Gender.ToString() + "_TORSO.png";
            string feetString = @"/DnDNPCGenerator;component/Images/CharacterPortraits/" + "CHARACTER" + "_BOOTS.png";
            string tailString = @"/DnDNPCGenerator;component/Images/CharacterPortraits/" + SelectedCharacter.Race.ToString() + "_TAIL.png";
            HeadImage.Source = new BitmapImage(new Uri(headString, UriKind.Relative));
            HandsImage.Source = new BitmapImage(new Uri(handsString, UriKind.Relative));
            TorsoImage.Source = new BitmapImage(new Uri(torsoString, UriKind.Relative));
            FeetImage.Source = new BitmapImage(new Uri(feetString, UriKind.Relative));
            TailImage.Source = new BitmapImage(new Uri(tailString, UriKind.Relative));
        }

    }
}
