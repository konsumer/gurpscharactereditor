using System.Diagnostics;

namespace GurpsCharacterEditor.Models
{
    public class Dice
    {
        public int Count { get; private set; }
        public int Modifier { get; private set; }

        public Dice(int count, int modifier = 0)
        {
            Debug.Assert(count > 0);

            Count = count;
            Modifier = modifier;
        }

        public override string ToString()
        {
            if (Modifier > 0)
                return Count.ToString() + "d+" + Modifier.ToString();
            if (Modifier < 0)
                return Count.ToString() + "d-" + (-Modifier).ToString();

            Debug.Assert(Modifier == 0);
            return Count.ToString() + "d";
        }
    }
}
