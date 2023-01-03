using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Delegates.ProblemExamples
{
    internal class Problem
    {
        /// <summary>
        /// This is the original function Foo that has a common routine and a custom calculation routine
        /// </summary>
        /// <param name="size"></param>
        /// <param name="removeEveryOther"></param>
        /// <returns></returns>
        public static double Calculate(int size, int removeEveryOther)
        {
            // ** Begin Common Routine **
            int count = 0;
            IList<int> finalDataset = new List<int>();

            var repoDataset = Repository.GetData(size);
            foreach(int x in repoDataset)
            {
                count++;
                if (count % removeEveryOther != 0)
                    finalDataset.Add(x);
            }
            // ** End Common Routine **

            // Custom Calculation
            return finalDataset.Sum(x => x);
        }


        /// <summary>
        /// This is Method 1 of using some type of parameter and branching to add in custom code
        /// </summary>
        /// <param name="size"></param>
        /// <param name="removeEveryOther"></param>
        /// <returns></returns>
        public static double CalculateUsingBranching(int size, int removeEveryOther, string calcMethod = "SUM")
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

            double ret = 0.0;

            // Custom Calculation
            if (calcMethod == "SUM")
                ret = finalDataset.Sum(x => x);
            if (calcMethod == "AVG")
                ret = finalDataset.Average();

            return ret;
        }


        /// <summary>
        /// This is Method 2 by copying the original function that has a common routine but altering with the custom code (AVG)
        /// </summary>
        /// <param name="size"></param>
        /// <param name="removeEveryOther"></param>
        /// <returns></returns>
        public static double CalculateUsingCopying(int size, int removeEveryOther)
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
            return finalDataset.Average();
        }
    }
}
