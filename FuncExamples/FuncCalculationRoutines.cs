using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Delegates.FuncExamples
{
    internal class FuncCalculationRoutines
    {
        private string Name { get; init; }

        public FuncCalculationRoutines(string name)
        {
            this.Name = name;
        }


        public double Sum(IEnumerable<int> dataset)
        {
            Console.Write("Calculated Summed for: {0}", this.Name);
            return dataset.Sum(x => x);
        }

        public Task<double> SumAsync(IEnumerable<int> dataset)
        {
            Console.Write("Calculated Async Summed for: {0}", this.Name);
            return Task.FromResult<double>(dataset.Sum(x => x));
        }

        public double Avg(IEnumerable<int> dataset)
        {
            Console.Write("Calculated Averaged for: {0}", this.Name);
            return dataset.Average(x => x);
        }

        public Task<double> AvgAsync(IEnumerable<int> dataset)
        {
            Console.Write("Calculated Async Averaged for: {0}", this.Name);
            return Task.FromResult<double>(dataset.Average(x => x));
        }
    }
}
