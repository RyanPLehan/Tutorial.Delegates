using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Delegates.DelegateExamples
{
    internal class DelegateCalculationRoutines
    {
        private string Name { get; init; }

        public DelegateCalculationRoutines(string name)
        {
            this.Name = name;
        }


        public double Sum(IEnumerable<int> dataset)
        {
            Console.Write("Calculated Summed for: {0}", this.Name);
            return dataset.Sum(x => x);
        }

        public double Avg(IEnumerable<int> dataset)
        {
            Console.Write("Calculated Averaged for: {0}", this.Name);
            return dataset.Average(x => x);
        }
    }
}
