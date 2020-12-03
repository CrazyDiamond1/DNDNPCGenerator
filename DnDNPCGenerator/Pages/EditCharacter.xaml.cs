using DnDNPCGenerator.Enums;
using DnDNPCGenerator.Models;
using DnDNPCGenerator.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for EditCharacter.xaml
    /// </summary>
    public partial class EditCharacter : Page
    {
        public IEnumerable<Race> Races
        {
            get
            {
                return Enum.GetValues(typeof(Race))
                    .Cast<Race>();
            }
        }
        public Race SelectedRace { get; set; }
        public IEnumerable<DNDClass> DnDClasses
        {
            get
            {
                return Enum.GetValues(typeof(DNDClass))
                    .Cast<DNDClass>();
            }
        }
        public DNDClass SelectedDnDClass { get; set; }
        public IEnumerable<Gender> Genders
        {
            get
            {
                return Enum.GetValues(typeof(Gender))
                    .Cast<Gender>();
            }
        }
        public Gender SelectedGender { get; set; }
        public IEnumerable<Alignment> Alignments
        {
            get
            {
                return Enum.GetValues(typeof(Alignment))
                    .Cast<Alignment>();
            }
        }
        public Alignment SelectedAlignment { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<Character> Characters { get; private set; }
        public Character SelectedCharacter { get; private set; }

        public EditCharacter()
        {
            InitializeComponent();
            this.DataContext = SelectedCharacter;
            Characters = new List<Character>();
        }

        public EditCharacter(List<Character> characters, Character selected)
        {
            InitializeComponent();
            SelectedCharacter = selected;
            CharGender.ItemsSource = Genders;
            CharAlignment.ItemsSource = Alignments;
            CharClass.ItemsSource = DnDClasses;
            CharRace.ItemsSource = Races;
            DisplayCharacterStats();
            Characters = characters;
            LoadCharacterListBox();
            CharGender.SelectedItem = SelectedGender;
            CharAlignment.SelectedItem = SelectedAlignment;
            CharClass.SelectedItem = SelectedDnDClass;
            CharRace.SelectedItem = SelectedRace;
        }

        private void CharacterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewControl selectedCharacterItem = (ListViewControl)CharacterBox.Items.GetItemAt(CharacterBox.SelectedIndex);
            SelectedCharacter = selectedCharacterItem.SetCharacter;
            DisplayCharacterStats();
        }

        private void DisplayCharacterStats()
        {
            CharName.Text = SelectedCharacter.Name;
            SelectedAlignment = SelectedCharacter.Alignment;
            SelectedDnDClass = SelectedCharacter.DnDClass;
            SelectedRace = SelectedCharacter.Race;
            SelectedGender = SelectedCharacter.Gender;
            CharStr.Text = SelectedCharacter.Strength.ToString();
            CharDex.Text = SelectedCharacter.Dexterity.ToString();
            CharCon.Text = SelectedCharacter.Constitution.ToString();
            CharInt.Text = SelectedCharacter.Intelligence.ToString();
            CharWis.Text = SelectedCharacter.Wisdom.ToString();
            CharChr.Text = SelectedCharacter.Charisma.ToString();
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCharacter.Name = CharName.Text;
            int tempInt = 0;
            SelectedCharacter.Alignment = SelectedAlignment;
            SelectedCharacter.DnDClass = SelectedDnDClass;
            SelectedCharacter.Gender = SelectedGender;
            SelectedCharacter.Race = SelectedRace;
            Int32.TryParse(CharStr.Text, out tempInt);
            SelectedCharacter.Strength = tempInt < 0 ? 0 : tempInt;
            Int32.TryParse(CharInt.Text, out tempInt);
            SelectedCharacter.Intelligence = tempInt < 0 ? 0 : tempInt;
            Int32.TryParse(CharDex.Text, out tempInt);
            SelectedCharacter.Dexterity = tempInt < 0 ? 0 : tempInt;
            Int32.TryParse(CharWis.Text, out tempInt);
            SelectedCharacter.Wisdom = tempInt < 0 ? 0 : tempInt;
            Int32.TryParse(CharCon.Text, out tempInt);
            SelectedCharacter.Constitution = tempInt < 0 ? 0 : tempInt;
            Int32.TryParse(CharChr.Text, out tempInt);
            SelectedCharacter.Charisma = tempInt < 0 ? 0 : tempInt;

            Utility.Seralizer.SerializeCharacters(Characters);

            ViewCharacters viewCharPage = new ViewCharacters(Characters, SelectedCharacter);
            NavigationService.Navigate(viewCharPage);
        }

        private void CharGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedGender = (Gender)CharGender.SelectedValue;
        }

        private void CharRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedRace = (Race)CharRace.SelectedValue;
        }

        private void CharClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDnDClass = (DNDClass)CharClass.SelectedValue;
        }

        private void CharAlignment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedAlignment = (Alignment)CharAlignment.SelectedValue;
        }
    }
}
