using System.Collections.ObjectModel;
using GurpsCharacterEditor.Models;
using GurpsCharacterEditor.Views;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace GurpsCharacterEditor.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public Character Character { get; set; }

        public DelegateCommand AboutCommand { get; private set; }
        public DelegateCommand EditPrimaryStatsCommand { get; private set; }
        public DelegateCommand EditSecondaryStatsCommand { get; private set; }
        public DelegateCommand AddItemCommand { get; private set; }
        public DelegateCommand AddAdvantageCommand { get; private set; }
        public DelegateCommand AddSkillCommand { get; private set; }
        public DelegateCommand OpenCommand { get; private set; }
        public DelegateCommand SaveAsCommand { get; private set; }

        public MainViewModel()
            : this(new Character())
        {
        }

        public MainViewModel(Character character)
        {
            Character = character;

            // Create commands
            AboutCommand = new DelegateCommand(ShowAboutWindow);
            EditPrimaryStatsCommand = new DelegateCommand(EditPrimaryStats);
            EditSecondaryStatsCommand = new DelegateCommand(EditSecondaryStats);
            AddItemCommand = new DelegateCommand(AddItem);
            AddAdvantageCommand = new DelegateCommand(AddAdvantage);
            AddSkillCommand = new DelegateCommand(AddSkill);
            OpenCommand = new DelegateCommand(Open);
            SaveAsCommand = new DelegateCommand(SaveAs);

            // Setup property dependencies
            PropertyDependencyMap.Add("Strength", new[] { "MaxHP", "BasicLift" });
            PropertyDependencyMap.Add("StrengthPoints", new[] { "Strength", "CharacterPoints" });
            PropertyDependencyMap.Add("Dexterity", new[] { "BasicSpeed" });
            PropertyDependencyMap.Add("DexterityPoints", new[] { "Dexterity", "CharacterPoints" });
            PropertyDependencyMap.Add("Intelligence", new[] { "Willpower", "Perception" });
            PropertyDependencyMap.Add("IntelligencePoints", new[] { "Intelligence", "CharacterPoints" });
            PropertyDependencyMap.Add("Health", new[] { "MaxFP", "BasicSpeed" });
            PropertyDependencyMap.Add("HealthPoints", new[] { "Health", "CharacterPoints" });
            PropertyDependencyMap.Add("MaxHPPoints", new[] { "MaxHP", "CharacterPoints" });
            PropertyDependencyMap.Add("MaxFPPoints", new[] { "MaxFP", "CharacterPoints" });
            PropertyDependencyMap.Add("WillpowerPoints", new[] { "Willpower", "CharacterPoints" });
            PropertyDependencyMap.Add("PerceptionPoints", new[] { "Perception", "CharacterPoints" });
            PropertyDependencyMap.Add("BasicSpeed", new[] { "BasicMove" });
            PropertyDependencyMap.Add("BasicSpeedPoints", new[] { "BasicSpeed", "CharacterPoints" });
            PropertyDependencyMap.Add("BasicMovePoints", new[] { "BasicMove", "CharacterPoints" });
            PropertyDependencyMap.Add("Advantages", new[] { "CharacterPoints" });
            PropertyDependencyMap.Add("Skills", new[] { "CharacterPoints" });
        }

        public string Name
        {
            get
            {
                string name = Character.Name;
                if (string.IsNullOrEmpty(name))
                    name = Properties.Resources.UnnamedCharacter;
                return name;
            }
        }
        public int Strength
        {
            get
            {
                return Character.Strength;
            }
        }
        public int Dexterity
        {
            get
            {
                return Character.Dexterity;
            }
        }
        public int Intelligence
        {
            get
            {
                return Character.Intelligence;
            }
        }
        public int Health
        {
            get
            {
                return Character.Health;
            }
        }
        public int MaxHP
        {
            get
            {
                return Character.MaxHP;
            }
        }
        public int MaxFP
        {
            get
            {
                return Character.MaxFP;
            }
        }
        public int Willpower
        {
            get
            {
                return Character.Willpower;
            }
        }
        public int Perception
        {
            get
            {
                return Character.Perception;
            }
        }
        public float BasicLift
        {
            get
            {
                return Character.BasicLift;
            }
        }
        public float BasicSpeed
        {
            get
            {
                return Character.BasicSpeed;
            }
        }
        public int BasicMove
        {
            get
            {
                return Character.BasicMove;
            }
        }

        public ObservableCollection<Item> Inventory
        {
            get
            {
                return Character.Inventory;
            }
        }
        public int TotalWeight
        {
            get
            {
                return Character.TotalWeight;
            }
        }

        public ObservableCollection<Advantage> Advantages
        {
            get
            {
                return Character.Advantages;
            }
        }

        public ObservableCollection<Skill> Skills
        {
            get
            {
                return Character.Skills;
            }
        }

        // Returns the window title
        public string Title
        {
            get
            {
                return "GURPS Character Editor - " + Name;
            }
        }

        public int CharacterPoints
        {
            get
            {
                return Character.CharacterPoints;
            }
        }

        public void ShowAboutWindow(object parameter)
        {
            AboutWindow window = new AboutWindow();
            window.ShowDialog();
        }

        public void AddItem(object parameter)
        {
            EditItemWindow window = new EditItemWindow();
            window.DataContext = new Item();

            if ((bool)window.ShowDialog())
            {
                Character.Inventory.Add((Item)window.DataContext);

                NotifyPropertyChanged("Inventory");
            }
        }

        public void AddAdvantage(object parameter)
        {
            EditAdvantageWindow window = new EditAdvantageWindow();
            window.DataContext = new Advantage();

            if ((bool)window.ShowDialog())
            {
                Character.Advantages.Add((Advantage)window.DataContext);

                NotifyPropertyChanged("Advantages");
            }
        }

        public void AddSkill(object parameter)
        {
            EditSkillWindow window = new EditSkillWindow();
            window.DataContext = new Skill();

            if ((bool)window.ShowDialog())
            {
                Character.Skills.Add((Skill)window.DataContext);

                NotifyPropertyChanged("Skills");
            }
        }

        public void EditPrimaryStats(object parameter)
        {
            EditPrimaryStatsWindow window = new EditPrimaryStatsWindow();
            window.DataContext = new EditPrimaryStatsViewModel(Character);

            window.ShowDialog();

            NotifyPropertyChanged("StrengthPoints");
            NotifyPropertyChanged("DexterityPoints");
            NotifyPropertyChanged("IntelligencePoints");
            NotifyPropertyChanged("HealthPoints");
        }

        public void EditSecondaryStats(object parameter)
        {
            EditSecondaryStatsWindow window = new EditSecondaryStatsWindow();
            window.DataContext = new EditSecondaryStatsViewModel(Character);

            window.ShowDialog();

            NotifyPropertyChanged("MaxHPPoints");
            NotifyPropertyChanged("MaxFPPoints");
            NotifyPropertyChanged("WillpowerPoints");
            NotifyPropertyChanged("PerceptionPoints");
            NotifyPropertyChanged("BasicSpeedPoints");
            NotifyPropertyChanged("BasicMovePoints");
        }

        public void Open(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".gurps";
            dialog.CheckFileExists = true;
            dialog.Filter = "GURPS files|*.gurps";
            if (dialog.ShowDialog() == true)
            {
                FileStream stream = File.OpenRead(dialog.FileName);
                stream.Close();
            }
        }

        public void SaveAs(object parameter)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".gurps";
            dialog.OverwritePrompt = true;
            dialog.CheckPathExists = true;
            dialog.Filter = "GURPS files|*.gurps";
            if (dialog.ShowDialog() == true) {
                FileStream stream = File.OpenWrite(dialog.FileName);
                stream.Close();
            }
        }
    }
}
