using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Delegates.ProblemExamples
{
    internal class ProblemBase
    {
        /// <summary>
        /// This is the original function Foo that has a common routine and a custom calculation routine
        /// </summary>
        /// <param name="size"></param>
        /// <param name="removeEveryOther"></param>
        /// <returns></returns>
        public virtual double Calculate(int size, int removeEveryOther)
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
    }
}
