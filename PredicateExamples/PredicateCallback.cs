using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Delegates.PredicateExamples
{
    internal class PredicateCallback
    {
        /// <summary>
        /// This is the original function Foo that has a common routine and a custom calculation routine
        /// </summary>
        /// <param name="size"></param>
        /// <param name="removeEveryOther"></param>
        /// <param name="callbackFunction">References a function that performs the custom calcuation</param>
        /// <returns></returns>
        public static IEnumerable<int> MyWhere(IEnumerable<int> dataset, Predicate<int> callbackFunction)
        {
            IList<int> list = new List<int>();
            
            foreach(int x in dataset)
            {
                if (callbackFunction(x))
                    list.Add(x);
            }

            return list;
        }


        public static bool IsEven(int x)
        {
            return x % 2 == 0;
        }

    }
}
