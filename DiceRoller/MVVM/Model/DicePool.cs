namespace DiceRoller.MVVM.Model
{
    public class DicePool()
    {

        public RollResult Results { get; } = new RollResult();

        public int DiceType { get; set; }
        public int DiceQnt { get; set; }

        public string ModType { get; set; }

        public int ModValue { get; set; }

        public RollResult RollPool()
        {
            for (int i = 0; i < DiceQnt; i++)
            {
                Roll roll = new(DiceType, i + 1);
                Results.AddRoll(roll);
            }

            Results.GenerateResult(ModType, ModValue);


            return Results;
        }
    }
}
