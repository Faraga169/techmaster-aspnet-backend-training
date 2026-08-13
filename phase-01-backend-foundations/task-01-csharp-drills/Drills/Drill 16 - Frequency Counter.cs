namespace task_01_csharp_drills.Drills
{
    public static class Drill_16___Frequency_Counter
    {
        public static void FrequencyCounter(List<int> numbers) {

            Dictionary<int, int> frequenctDict = new Dictionary<int, int>();
            if (numbers is not null) {

                for (int i = 0; i < numbers.Count; i++)
                {

                    if (frequenctDict.ContainsKey(numbers[i]))
                    {

                        frequenctDict[numbers[i]] = frequenctDict[numbers[i]] + 1;
                    }
                    else
                    {

                        frequenctDict[numbers[i]] = 1;
                    }
                }

               
            }

            foreach (int i in frequenctDict.Keys)
            {
                Console.Write($"{i} => {frequenctDict[i]} , ");
            }

        }
    }
}
