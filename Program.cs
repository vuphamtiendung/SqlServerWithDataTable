using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SqlServerWithDataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTableClass data = new DataTableClass();
            data.DataTableIteration();
            data.CopyAndClone();
            data.DataTableDelete();
            data.DataTableRemove();

            ReadLine();
        }
    }
}
