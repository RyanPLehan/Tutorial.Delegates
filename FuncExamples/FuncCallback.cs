using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Delegates.FuncExamples
{
    internal class FuncCallback
    {
        /// <summary>
        /// This is the original function Foo that has a common routine and a custom calculation routine
        /// </summary>
        /// <param name="size"></param>
        /// <param name="removeEveryOther"></param>
        /// <param name="callbackFunction">References a function that performs the custom calcuation</param>
        /// <returns></returns>
        public static double Calculate(int size, int removeEveryOther, Func<IEnumerable<int>, double> callbackFunction)
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
            return callbackFunction(finalDataset);
        }

        /// <summary>
        /// This is the original function Foo that has a common routine and a custom calculation routine
        /// </summary>
        /// <param name="size"></param>
        /// <param name="removeEveryOther"></param>
        /// <param name="callbackFunction">References a function that performs the custom calcuation</param>
        /// <returns></returns>
        public static async Task<double> CalculateAsync(int size, int removeEveryOther, Func<IEnumerable<int>, Task<double>> callbackFunction)
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
            return await callbackFunction(finalDataset);
        }



        public static double CalculateSum(IEnumerable<int> dataset)
        {
            return dataset.Sum(x => x);
        }

        public static double CalculateAvg(IEnumerable<int> dataset)
        {
            return dataset.Average(x => x);
        }


        public static async Task<double> CalculateSumAsync(IEnumerable<int> dataset)
        {
            return await Task.FromResult<double>(dataset.Sum(x => x));
        }

        public static async Task<double> CalculateAvgAsync(IEnumerable<int> dataset)
        {
            return await Task.FromResult<double>(dataset.Average(x => x));
        }


    }
}
