using System;
using Tutorial.Delegates.ActionExamples;
using Tutorial.Delegates.DelegateExamples;
using Tutorial.Delegates.FuncExamples;
using Tutorial.Delegates.ProblemExamples;

namespace Tutorial.Delegates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ExecuteProblemExamples();
            // ExecuteDelegateExamples();
            // ExecuteActionExamples();
            // ExecuteFuncExamples();
            // ExecuteFuncAsyncExamples().GetAwaiter().GetResult();
        }

        public static void ExecuteProblemExamples()
        {
            Console.WriteLine("Problem Examples");

            Console.WriteLine("Calculate (Sum) : {0}", Problem.Calculate(100, 5));
            Console.WriteLine("Calculate (Sum) : {0}", Problem.CalculateUsingBranching(100, 5, "SUM"));
            Console.WriteLine("Calculate (Avg) : {0}", Problem.CalculateUsingBranching(100, 5, "AVG"));
            Console.WriteLine("Calculate (Avg) : {0}", Problem.CalculateUsingCopying(100, 5));

            ProblemBase problem = new ProblemBase();
            Console.WriteLine("Calculate (Sum) : {0}", problem.Calculate(100, 5));

            problem = new ProblemDerived();
            Console.WriteLine("Calculate (Avg) : {0}", problem.Calculate(100, 5));

            Console.WriteLine();
        }


        public static void ExecuteDelegateExamples()
        {
            Console.WriteLine("Delegate Examples");

            Console.WriteLine("Calculate (Sum) : {0}", DelegateCallback.Calculate(100, 5, DelegateCallback.CalculateSum));
            Console.WriteLine("Calculate (Avg) : {0}", DelegateCallback.Calculate(100, 5, DelegateCallback.CalculateAvg));

            // Since CalculateStandardDeviation does not follow the defined Delegate type, it will get a compile error
            //Console.WriteLine("Calculate (Avg) : {0}", DelegateCallback.Calculate(100, 5, DelegateCallback.CalculateStandardDeviation));

            // Delegates can use instaniated objects
            DelegateCalculationRoutines dcr = new DelegateCalculationRoutines("Ryan");
            Console.WriteLine(" : {0}", DelegateCallback.Calculate(100, 5, dcr.Sum));
            Console.WriteLine(" : {0}", DelegateCallback.Calculate(100, 5, dcr.Avg));


            Console.WriteLine("Anonymous Calculate (Sum) : {0}", DelegateCallback.Calculate(100, 5, delegate (IEnumerable<int> dataset)
            {
                return dataset.Sum(x => x);
            }));

            Console.WriteLine("Anonymous Calculate (Avg) : {0}", DelegateCallback.Calculate(100, 5, delegate (IEnumerable<int> dataset)
            {
                return dataset.Average(x => x);
            }));


            Console.WriteLine("Lambda Calculate (Sum) : {0}", DelegateCallback.Calculate(100, 5, dataset => dataset.Sum(x => x)));
            Console.WriteLine("Lambda Calculate (Sum) : {0}", DelegateCallback.Calculate(100, 5, dataset => { return dataset.Sum(x => x); }));


            Console.WriteLine("Lambda Calculate (Avg) : {0}", DelegateCallback.Calculate(100, 5, dataset => dataset.Average(x => x)));
            Console.WriteLine("Lambda Calculate (Avg) : {0}", DelegateCallback.Calculate(100, 5, dataset => { return dataset.Average(x => x); }));

            Console.WriteLine();
        }


        public static void ExecuteActionExamples()
        {
            Console.WriteLine("Action Examples");

            Console.WriteLine("Using a callback function");
            ActionCallback.DisplayMessage(5, 1, "Hello there", ActionCallback.AppendPuncuationMarks);
            ActionCallback.DisplayMessage(3, 2, "WTF", ActionCallback.AppendPuncuationMarks);
            Console.WriteLine();

            // Using instaniated objects
            Console.WriteLine("Using a callback function from within an instaniated object");
            ActionDisplayRoutines acr = new ActionDisplayRoutines("Steve");
            ActionCallback.DisplayMessage(3, 10, "Hello there", acr.DisplayName);
            ActionCallback.DisplayMessage(1, 12, "WTF", acr.DisplayName);
            Console.WriteLine();

            // Using the delegate keyword
            Console.WriteLine("Using the delegate keyword as an Anonymous function");
            ActionCallback.DisplayMessage(2, 0, "Hello there", delegate(int numberOfSpacesToIndent, string msg) 
            {
                string indent = new string(' ', numberOfSpacesToIndent);
                Console.WriteLine("{0}{1}, from anonymous delegate", indent, msg); 
            });
            Console.WriteLine();

            // Using the delegate keyword
            Console.WriteLine("Using the Lambda expression");
            ActionCallback.DisplayMessage(4, 5, "Hello there", (numberOfSpacesToIndent, msg) => 
            {
                string indent = new string(' ', numberOfSpacesToIndent);
                Console.WriteLine("{0}{1}, from lambda expression", indent, msg); 
            });
            Console.WriteLine();
        }


        public static void ExecuteFuncExamples()
        {
            Console.WriteLine("Func Examples");

            Console.WriteLine("Calculate (Sum) : {0}", FuncCallback.Calculate(100, 5, FuncCallback.CalculateSum));
            Console.WriteLine("Calculate (Avg) : {0}", FuncCallback.Calculate(100, 5, FuncCallback.CalculateAvg));

            // Func can use instaniated objects
            FuncCalculationRoutines fcr = new FuncCalculationRoutines("Ryan");
            Console.WriteLine(" : {0}", FuncCallback.Calculate(100, 5, fcr.Sum));
            Console.WriteLine(" : {0}", FuncCallback.Calculate(100, 5, fcr.Avg));

            Console.WriteLine("Anonymous Calculate (Sum) : {0}", FuncCallback.Calculate(100, 5, delegate (IEnumerable<int> dataset)
            {
                return dataset.Sum(x => x);
            }));

            Console.WriteLine("Anonymous Calculate (Avg) : {0}", FuncCallback.Calculate(100, 5, delegate (IEnumerable<int> dataset)
            {
                return dataset.Average(x => x);
            }));

            Console.WriteLine("Lambda Calculate (Sum) : {0}", FuncCallback.Calculate(100, 5, dataset => dataset.Sum(x => x)));
            Console.WriteLine("Lambda Calculate (Avg) : {0}", FuncCallback.Calculate(100, 5, dataset => dataset.Average(x => x)));

            Console.WriteLine();
        }


        public static async Task ExecuteFuncAsyncExamples()
        {
            Console.WriteLine("Func Async Examples");

            Console.WriteLine("Calculate Async (Sum) : {0}", await FuncCallback.CalculateAsync(100, 5, FuncCallback.CalculateSumAsync));
            Console.WriteLine("Calculate Async (Avg) : {0}", await FuncCallback.CalculateAsync(100, 5, FuncCallback.CalculateAvgAsync));

            // Func can use instaniated objects
            FuncCalculationRoutines fcr = new FuncCalculationRoutines("Ryan");
            Console.WriteLine(" : {0}", await FuncCallback.CalculateAsync(100, 5, fcr.SumAsync));
            Console.WriteLine(" : {0}", await FuncCallback.CalculateAsync(100, 5, fcr.AvgAsync));

            Console.WriteLine("Anonymous Calculate Async (Sum) : {0}", await FuncCallback.CalculateAsync(100, 5, async delegate (IEnumerable<int> dataset)
            {
                return await Task.FromResult<double>(dataset.Sum(x => x));
            }));

            Console.WriteLine("Anonymous Calculate Async (Avg) : {0}", await FuncCallback.CalculateAsync(100, 5, async delegate (IEnumerable<int> dataset)
            {
                return await Task.FromResult<double>(dataset.Average(x => x));
            }));



            Console.WriteLine("Lambda Calculate Async (Sum) : {0}", await FuncCallback.CalculateAsync(100, 5, async dataset =>
            {
                return await Task.FromResult<double>(dataset.Sum(x => x));
            }));

            Console.WriteLine("Lambda Calculate Async (Avg) : {0}", await FuncCallback.CalculateAsync(100, 5, async dataset =>
            {
                return await Task.FromResult<double>(dataset.Average(x => x));
            }));

            Console.WriteLine();
        }
    }
}
