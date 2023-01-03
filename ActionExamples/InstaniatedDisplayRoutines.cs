using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Delegates.ActionExamples
{
    internal class ActionDisplayRoutines
    {
        private string Name { get; init; }

        public ActionDisplayRoutines(string name)
        {
            this.Name = name;
        }


        public void DisplayName(int numberOfSpacesToIndent, string msg)
        {
            string indent = new string(' ', numberOfSpacesToIndent);
            Console.WriteLine("{0}The following message is for {1} - {2}", indent, this.Name, msg);
        }
    }
}
