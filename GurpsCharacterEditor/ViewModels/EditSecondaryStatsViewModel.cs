using GurpsCharacterEditor.Models;

namespace GurpsCharacterEditor.ViewModels
{
    class EditSecondaryStatsViewModel : ViewModelBase
    {
        public Character Character { get; set; }

        public EditSecondaryStatsViewModel() : this(new Character())
        {
        }

        public EditSecondaryStatsViewModel(Character character)
        {
            Character = character;
        }

        public int MaxHPPoints
        {
            get
            {
                return Character.MaxHPPoints;
            }
            set
            {
                Character.MaxHPPoints = value;
                NotifyPropertyChanged("MaxHPPoints");
            }
        }
        public int MaxFPPoints
        {
            get
            {
                return Character.MaxFPPoints;
            }
            set
            {
                Character.MaxFPPoints = value;
                NotifyPropertyChanged("MaxFPPoints");
            }
        }
        public int WillpowerPoints
        {
            get
            {
                return Character.WillpowerPoints;
            }
            set
            {
                Character.WillpowerPoints = value;
                NotifyPropertyChanged("WillpowerPoints");
            }
        }
        public int PerceptionPoints
        {
            get
            {
                return Character.PerceptionPoints;
            }
            set
            {
                Character.PerceptionPoints = value;
                NotifyPropertyChanged("PerceptionPoints");
            }
        }
        public float BasicSpeedPoints
        {
            get
            {
                return Character.BasicSpeedPoints;
            }
            set
            {
                Character.BasicSpeedPoints = value;
                NotifyPropertyChanged("BasicSpeedPoints");
            }
        }
        public int BasicMovePoints
        {
            get
            {
                return Character.BasicMovePoints;
            }
            set
            {
                Character.BasicMovePoints = value;
                NotifyPropertyChanged("BasicMovePoints");
            }
        }

    }
}
