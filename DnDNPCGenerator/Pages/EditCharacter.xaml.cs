using DnDNPCGenerator.Enums;
using DnDNPCGenerator.Models;
using DnDNPCGenerator.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Character> Characters { get; private set; }
        public Character SelectedCharacter { get; private set; }
        private bool NewCharacter { get; set; }

        public EditCharacter()
        {
            InitializeComponent();
            this.DataContext = SelectedCharacter;
            Characters = new ObservableCollection<Character>();
        }

        public EditCharacter(ObservableCollection<Character> characters, Character selected)
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
            NotesContent.Text = SelectedCharacter.Notes;
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
            Regex regex = new Regex(@"[^-0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UpdateCharacterPortrait()
        {
            string headString = @"/DnDNPCGenerator;component/Images/CharacterPortraits/" + SelectedRace + "_" + SelectedGender + "_HEAD.png";
            string handsString = @"/DnDNPCGenerator;component/Images/CharacterPortraits/" + SelectedRace + "_HANDS.png";
            string torsoString = @"/DnDNPCGenerator;component/Images/CharacterPortraits/" + SelectedDnDClass + "_" + SelectedGender + "_TORSO.png";
            string feetString = @"/DnDNPCGenerator;component/Images/CharacterPortraits/" + "CHARACTER" + "_BOOTS.png";
            string tailString = @"/DnDNPCGenerator;component/Images/CharacterPortraits/" + SelectedRace + "_TAIL.png";
            HeadImage.Source = new BitmapImage(new Uri(headString, UriKind.Relative));
            HandsImage.Source = new BitmapImage(new Uri(handsString, UriKind.Relative));
            TorsoImage.Source = new BitmapImage(new Uri(torsoString, UriKind.Relative));
            FeetImage.Source = new BitmapImage(new Uri(feetString, UriKind.Relative));
            TailImage.Source = new BitmapImage(new Uri(tailString, UriKind.Relative));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool saveNew = !Characters.Contains(SelectedCharacter);

            SelectedCharacter.Name = CharName.Text;
            int tempInt = 10;
            SelectedCharacter.Alignment = SelectedAlignment;
            SelectedCharacter.DnDClass = SelectedDnDClass;
            SelectedCharacter.Gender = SelectedGender;
            SelectedCharacter.Race = SelectedRace;
            Int32.TryParse(CharStr.Text, out tempInt);
            SelectedCharacter.Strength = tempInt;
            Int32.TryParse(CharInt.Text, out tempInt);
            SelectedCharacter.Intelligence = tempInt;
            Int32.TryParse(CharDex.Text, out tempInt);
            SelectedCharacter.Dexterity = tempInt;
            Int32.TryParse(CharWis.Text, out tempInt);
            SelectedCharacter.Wisdom = tempInt;
            Int32.TryParse(CharCon.Text, out tempInt);
            SelectedCharacter.Constitution = tempInt;
            Int32.TryParse(CharChr.Text, out tempInt);
            SelectedCharacter.Charisma = tempInt;
            SelectedCharacter.Notes = NotesContent.Text;

            if (saveNew)
            {
                Characters.Add(SelectedCharacter);
                AddCharacterItemBoxToCharacterListBox(SelectedCharacter);
            }

            Utility.Seralizer.SerializeCharacters(Characters);
            ViewCharacters viewCharPage = new ViewCharacters(Characters, SelectedCharacter);
            NavigationService.Navigate(viewCharPage);
        }

        private void CharGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedGender = (Gender)CharGender.SelectedValue;
            UpdateCharacterPortrait();
        }

        private void CharRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedRace = (Race)CharRace.SelectedValue;
            UpdateCharacterPortrait();
        }

        private void CharClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDnDClass = (DNDClass)CharClass.SelectedValue;
            UpdateCharacterPortrait();
        }

        private void CharAlignment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedAlignment = (Alignment)CharAlignment.SelectedValue;
        }
    }
}
