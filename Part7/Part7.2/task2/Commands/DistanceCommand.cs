using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class DistanceCommand : ICommand
    {
        TwoPointDistanceCalculator twoPointDistance;
        public DistanceCommand(TwoPointDistanceCalculator twoPointDistance)
        {
            this.twoPointDistance = twoPointDistance;
        }

        public void Execute()
        {
            twoPointDistance.Distance();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
