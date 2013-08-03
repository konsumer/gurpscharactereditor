using System.Collections.ObjectModel;
using GurpsCharacterEditor.Models;
using GurpsCharacterEditor.Views;

namespace GurpsCharacterEditor.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public Character Character { get; set; }

        public MainViewModel()
            : this(new Character())
        {
        }

        public MainViewModel(Character character)
        {
            Character = character;

            // Create commands
            AboutCommand = new DelegateCommand(ShowAboutWindow);
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

        public DelegateCommand AboutCommand { get; private set; }

        // Show the about window
        public void ShowAboutWindow(object parameter)
        {
            AboutWindow window = new AboutWindow();
            window.ShowDialog();
        }
    }
}
