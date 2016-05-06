using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class PrimaryNumberCommand : ICommand
    {
        PrimeNumberDetector primaryNumber;
        public PrimaryNumberCommand(PrimeNumberDetector primaryNumber)
        {
            this.primaryNumber = primaryNumber;
        }
        public void Execute()
        {
            primaryNumber.IsPrimary();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
