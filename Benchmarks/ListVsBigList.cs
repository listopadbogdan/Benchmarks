using BenchmarkDotNet.Attributes;
using Magnum.Collections;

[MemoryDiagnoser]
public class ListVsBigList
{
    private readonly int _capacity = 10_000_000;

    [Benchmark]
    public List<Item> FillListWithCapacityTest()
    {
        List<Item> list = new List<Item>(capacity: _capacity);
        for (int i = 0; i < _capacity; i++)
        {
            Item item = new Item()
            {
                id = Guid.NewGuid(),
                name = i.ToString(),
                description = string.Concat(i, i),
            };

            list.Add(item);
        }

        return list;
    }


    [Benchmark]
    public List<Item> FillListWithoutCapacityTest()
    {
        List<Item> list = new List<Item>();

        for (int i = 0; i < _capacity; i++)
        {
            Item item = new Item()
            {
                id = Guid.NewGuid(),
                name = i.ToString(),
                description = string.Concat(i, i),
            };

            list.Add(item);
        }

        return list;
    }


    [Benchmark]
    public BigList<Item> FillBigListWithoutCapacityTest()
    {
        BigList<Item> bigList = new BigList<Item>();

        for (int i = 0; i < _capacity; i++)
        {
            Item item = new Item()
            {
                id = Guid.NewGuid(),
                name = i.ToString(),
                description = string.Concat(i, i),
            };

            bigList.Add(item);
        }

        return bigList;
    }
}

public class Item
{
    public Guid id { get; init; }

    public string name { get; set; }

    public string description { get; set; }
}