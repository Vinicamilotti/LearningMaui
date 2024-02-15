namespace DiceRoller.MVVM.Model
{
    public class RollResult
    {
        public List<Roll> Rolls { get; }
        public int RollSum { get; set; }
        public float FinalResult { get; set; }

        public RollResult()
        {
            Rolls = [];
        }

        public void AddRoll(Roll roll)
        {
            Rolls.Add(roll);
        }

        public int SumRolls()
        {
            int sum = 0;
            foreach (Roll roll in Rolls)
            {
                sum += roll.RollResult;
            }

            RollSum = sum;

            return sum;


        }

        public void GenerateResult(string modType, int modValue)
        {
            SumRolls();


            FinalResult = RollSum;

            if (modValue <= 0)
            {
                return;
            }
            switch (modType)
            {
                case "+":
                    FinalResult += modValue;

                    break;
                case "-":
                    FinalResult -= modValue;
                    break;
                case "*":
                    FinalResult *= modValue;
                    break;
                case "%":
                    FinalResult /= modValue;
                    break;
            }
        }
    }
}
