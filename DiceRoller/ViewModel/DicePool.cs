namespace DiceRoller.ViewModel
{
    public class DicePool(int diceType, int diceQnt, string modType, int modValue)
    {
        readonly int diceType = diceType;
        readonly int diceQnt = diceQnt;
        readonly string modType = modType;
        readonly int modValue = modValue;

        public RollResult Results { get; } = new RollResult();

        public int DiceType { get; set; }
        public int DiceQnt { get; set; }

        public RollResult RollPool()
        {
            for (int i = 0; i < diceQnt; i++)
            {
                Roll roll = new(this.diceType, i + 1);
                Results.AddRoll(roll);
            }

            Results.GenerateResult(modType, modValue);


            return Results;
        }
    }
}
