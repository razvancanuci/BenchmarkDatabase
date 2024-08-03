using BenchmarkDotNet.Attributes;
using BenchMarksDatabase.Entities;

namespace BenchMarksDatabase.Benchmarks;

[MemoryDiagnoser]
public class InsertBenchmarks
{
    [Params(10_000)]
    public int Size { get; set; }

    [Benchmark]
    public async Task Insert_TableInt()
    {
        await using var context = new BenchMarkDbContext();

        for (int i = 0; i < Size; i++)
        {
            context.TableInt.Add(new TableInt());
        }

        await context.SaveChangesAsync();
    }

    [Benchmark]
    public async Task Insert_TableGuid()
    {
        await using var context = new BenchMarkDbContext();

        for (int i = 0; i < Size; i++)
        {
            context.TableGuid.Add(new TableGuid());
        }

        await context.SaveChangesAsync();
    }
    
    [Benchmark]
    public async Task Insert_TableUlid()
    {
        await using var context = new BenchMarkDbContext();

        for (int i = 0; i < Size; i++)
        {
            context.TableUlid.Add(new TableUlid
            {
                Id = Ulid.NewUlid()
            });
        }

        await context.SaveChangesAsync();
    }
    
    [Benchmark]
    public async Task Insert_TableUlidBinary()
    {
        await using var context = new BenchMarkDbContext();

        for (int i = 0; i < Size; i++)
        {
            context.TableUlidBinary.Add(new TableUlidBinary
            {
                Id = Ulid.NewUlid()
            });
        }

        await context.SaveChangesAsync();
    }
}