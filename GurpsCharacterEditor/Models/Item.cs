namespace GurpsCharacterEditor.Models
{
    // This item represents an inventory item, which can be carried by a
    // character.
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }

        public Item()
        {
            Name = "";
            Value = 0;
            Weight = 0;
        }

        public Item(string name, int value, int weight)
        {
            Name = name;
            Value = value;
            Weight = weight;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
