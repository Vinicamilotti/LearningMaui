namespace DiceRoller.MVVM.Model
{
    public class Roll
    {
        public int RollIndex { get; set; }
        public int RollResult { get; set; }


        public Roll(int diceType, int diceIndex)
        {
            Random random = new();
            int roll = random.Next(1, diceType + 1);

            RollIndex = diceIndex;
            RollResult = roll;
        }



    }
}
