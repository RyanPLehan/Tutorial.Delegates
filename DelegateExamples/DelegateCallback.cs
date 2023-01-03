using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Delegates.DelegateExamples
{
    internal class DelegateCallback
    {
        // Define the type of reference function
        // Parameters and return types
        public delegate double CustomCalculationCallback(IEnumerable<int> finalDataset);

        /// <summary>
        /// This is the original function Foo that has a common routine and a custom calculation routine
        /// </summary>
        /// <param name="size"></param>
        /// <param name="removeEveryOther"></param>
        /// <param name="customCalculation">References a function that performs the custom calcuation</param>
        /// <returns></returns>
        public static double Calculate(int size, int removeEveryOther, CustomCalculationCallback customCalculationCallback)
        {
            // ** Begin Common Routine **
            int count = 0;
            IList<int> finalDataset = new List<int>();

            var repoDataset = Repository.GetData(size);
            foreach (int x in repoDataset)
            {
                count++;
                if (count % removeEveryOther != 0)
                    finalDataset.Add(x);
            }
            // ** End Common Routine **

            // Custom Calculation
            // invoke the custom callback function
            return customCalculationCallback(finalDataset);
        }

        public static double CalculateSum(IEnumerable<int> dataset)
        {
            return dataset.Sum(x => x);
        }

        public static double CalculateAvg(IEnumerable<int> dataset)
        {
            return dataset.Average(x => x);
        }

        
        /// <summary>
        /// This does not following the structure of the defined Delegate type
        /// If you try to use it it will not compile
        /// </summary>
        /// <param name="dataset"></param>
        /// <param name="avg"></param>
        /// <returns></returns>
        public static double CalculateStandardDeviation(IEnumerable<int> dataset, int avg)
        {
            return dataset.Average(x => x);
        }
    }
}
