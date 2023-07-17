using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            //var runner = BenchmarkRunner.Run<ListVsBigList>();
            var runner = BenchmarkRunner.Run<ForVsForeach_IList>();
        }
    }
}
