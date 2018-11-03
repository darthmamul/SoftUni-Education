using System;
using System.Collections.Generic;
using System.Text;

namespace BachSoft.Contracts
{
    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> stuidentsWithMarks, string comparison, int studentsToTake);
    }
}
