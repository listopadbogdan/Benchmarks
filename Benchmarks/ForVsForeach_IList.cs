using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class ForVsForeach_IList
    {
        public int count = 100_000_00;

        public static List<int> list = new List<int>();
        public static IList<int> Ilist = new List<int>();

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
                Ilist.Add(i);
            }
        }

        [Benchmark]
        public IList<int> ListForeachTest()
        {
            List<int> result = new List<int>();
            foreach (int i in list)
            {
                result.Add(i);
            }
            return result;
        }

        [Benchmark]
        public IList<int> ListForTest()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }
        
        [Benchmark]
        public IList<int> IListForeachTest()
        {
            List<int> result = new List<int>();
            foreach (int i in Ilist)
            {
                result.Add(i);
            }
            return result;
        }

        [Benchmark]
        public IList<int> IListForTest()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < Ilist.Count; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }
        
        [Benchmark]
        public IList<int> IListWithStaticCountForTest()
        {
            List<int> result = new List<int>();
            int cnt = Ilist.Count;
            for (int i = 0; i < cnt; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }
    }
}
