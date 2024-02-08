namespace DiceRoller.Model
{
    public class DicePool
    {
        int diceType;
        int diceQnt;
        string modType;
        int modValue;

        public RollResult Results { get; }

        public int DiceType { get; set; }
        public int DiceQnt { get; set; }

        public DicePool(int diceType, int diceQnt, string modType, int modValue)
        {
            this.diceType = diceType;
            this.diceQnt = diceQnt;

            Results = new RollResult();
            this.modType = modType;
            this.modValue = modValue;
        }

        public RollResult RollPool()
        {
            for (int i = 0; i < diceQnt; i++)
            {
                Roll roll = new(this.diceType, i + 1);
                Results.addRoll(roll);
            }

            Results.GenerateResult(modType, modValue);


            return Results;
        }
    }
}
