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

        public Item(Item item)
        {
            Name = item.Name;
            Value = item.Value;
            Weight = item.Weight;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Item))
                return false;

            Item item = (Item)obj;

            return (item.Name.Equals(Name)) && (item.Value.Equals(Value)) && (item.Weight.Equals(Weight));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
