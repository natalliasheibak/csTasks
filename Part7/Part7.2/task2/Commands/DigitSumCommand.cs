using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class DigitSumCommand:ICommand
    {
        DigitSumCalculator digitSum;
        public DigitSumCommand(DigitSumCalculator digitSum)
        {
            this.digitSum = digitSum;
        }

        public void Execute()
        {
            digitSum.Sum();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
