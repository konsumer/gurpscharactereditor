using System.Collections.ObjectModel;
using GurpsCharacterEditor.Models;
using GurpsCharacterEditor.Views;
using System.Diagnostics;

namespace GurpsCharacterEditor.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public Character Character { get; set; }

        public DelegateCommand AboutCommand { get; private set; }
        public DelegateCommand EditPrimaryStatsCommand { get; private set; }
        public DelegateCommand EditSecondaryStatsCommand { get; private set; }

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

            // Setup property dependencies
            PropertyDependencyMap.Add("Strength", new[] { "MaxHP", "BasicLift" });
            PropertyDependencyMap.Add("StrengthPoints", new[] { "Strength" });
            PropertyDependencyMap.Add("Dexterity", new[] { "BasicSpeed" });
            PropertyDependencyMap.Add("DexterityPoints", new[] { "Dexterity" });
            PropertyDependencyMap.Add("Intelligence", new[] { "Willpower", "Perception" });
            PropertyDependencyMap.Add("IntelligencePoints", new[] { "Intelligence" });
            PropertyDependencyMap.Add("Health", new[] { "MaxFP", "BasicSpeed" });
            PropertyDependencyMap.Add("HealthPoints", new[] { "Health" });
            PropertyDependencyMap.Add("MaxHPPoints", new[] { "MaxHP" });
            PropertyDependencyMap.Add("MaxFPPoints", new[] { "MaxFP" });
            PropertyDependencyMap.Add("WillpowerPoints", new[] { "Willpower" });
            PropertyDependencyMap.Add("PerceptionPoints", new[] { "Perception" });
            PropertyDependencyMap.Add("BasicSpeed", new[] { "BasicMove" });
            PropertyDependencyMap.Add("BasicSpeedPoints", new[] { "BasicSpeed" });
            PropertyDependencyMap.Add("BasicMovePoints", new[] { "BasicMove" });
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

        // Returns the window title
        public string Title
        {
            get
            {
                return "GURPS Character Editor - " + Name;
            }
        }

        public void ShowAboutWindow(object parameter)
        {
            AboutWindow window = new AboutWindow();
            window.ShowDialog();
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
    }
}
