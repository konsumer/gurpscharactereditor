namespace GurpsCharacterEditor.Models
{
    public class Advantage
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }

        public Advantage()
        {
            Name = "";
            Description = "";
            Points = 0;
        }

        public Advantage(string name, string description, int points) {
            Name = name;
            Description = description;
            Points = points;
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
