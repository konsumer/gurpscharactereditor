namespace GurpsCharacterEditor.Models
{
    public class Advantage
    {
        public string Name { get; set; }

        public int Points { get; set; }

        public Advantage()
        {
            Name = "";
            Points = 0;
        }

        public Advantage(string name, int points) {
            Name = name;
            Points = points;
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
