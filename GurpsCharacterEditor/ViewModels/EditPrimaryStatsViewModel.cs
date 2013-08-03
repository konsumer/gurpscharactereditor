using GurpsCharacterEditor.Models;

namespace GurpsCharacterEditor.ViewModels
{
    class EditPrimaryStatsViewModel : ViewModelBase
    {
        public Character Character { get; set; }

        public EditPrimaryStatsViewModel() : this(new Character())
        {
        }

        public EditPrimaryStatsViewModel(Character character)
        {
            Character = character;
        }

        public int StrengthPoints
        {
            get
            {
                return Character.StrengthPoints;
            }
            set
            {
                Character.StrengthPoints = value;
                NotifyPropertyChanged("StrengthPoints");
            }
        }
        public int DexterityPoints
        {
            get
            {
                return Character.DexterityPoints;
            }
            set
            {
                Character.DexterityPoints = value;
                NotifyPropertyChanged("DexterityPoints");
            }
        }
        public int IntelligencePoints
        {
            get
            {
                return Character.IntelligencePoints;
            }
            set
            {
                Character.IntelligencePoints = value;
                NotifyPropertyChanged("IntelligencePoints");
            }
        }
        public int HealthPoints
        {
            get
            {
                return Character.HealthPoints;
            }
            set
            {
                Character.HealthPoints = value;
                NotifyPropertyChanged("HealthPoints");
            }
        }
    }
}
