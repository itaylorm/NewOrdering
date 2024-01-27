using BenchmarkDotNet.Attributes;

namespace NewOrdering;

[MemoryDiagnoser(false)]
public class Benchmarks
{

    private readonly Random _random = new Random(420);

    private int[] _items;
    private int[] _items2;

    private List<int> _list;
    private List<int> _list2;

    [GlobalSetup]
    public void Setup()
    {
        _items = Enumerable.Range(1, 100).Select(i => _random.Next()).ToArray();
        _items2 = _items.ToArray();
        _list = _items.ToList();
        _list2 = _list.ToList();
    }

    [Benchmark]
    public int[] OrderBy() => _items.OrderBy(i => i).ToArray();

    [Benchmark]
    public int[] Order() => _items.Order().ToArray();

    [Benchmark]
    public int[] OrderByDescending() => _items.OrderByDescending(i => i).ToArray();

    [Benchmark]
    public int[] OrderDescending() => _items.OrderDescending().ToArray();

    [Benchmark]
    public int[] Sort() {
        Array.Sort(_items2);
        return _items2;
    }

    [Benchmark]
    public List<int> ListOrderBy() => _list.OrderBy(i => i).ToList();

    [Benchmark]
    public List<int> ListOrder() => _list.Order().ToList();

    [Benchmark]
    public List<int> ListOrderByDescending() => _list.OrderByDescending(i => i).ToList();

    [Benchmark]
    public List<int> ListOrderDescending() => _list.OrderDescending().ToList();

    [Benchmark]
    public List<int> ListSort()
    {
       _list2.Sort();
       return _list2;
    }
}
