namespace GurpsCharacterEditor.Models
{
    // This item represents an inventory item, which can be carried by a
    // character.
    //
    // This class is mutable - do not use as key in dictionaries.
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }

        public Item()
        {
            Name = "";
            Description = "";
            Value = 0;
            Weight = 0;
        }

        public Item(string name, int value, int weight)
        {
            Name = name;
            Description = "";
            Value = value;
            Weight = weight;
        }

        public Item(Item item)
        {
            Name = item.Name;
            Description = item.Description;
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

            return (item.Name.Equals(Name)) && (item.Description.Equals(Description)) && (item.Value.Equals(Value)) && (item.Weight.Equals(Weight));
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + Description.GetHashCode();
            hash = hash * 23 + Value.GetHashCode();
            hash = hash * 23 + Weight.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
