using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace BenchMarksDatabase.Benchmarks;

[MemoryDiagnoser]
public class QueryBenchmarks
{
    [Params(10_000)]
    public int Size { get; set; }
    
    [Benchmark]
    public async Task Query_TableInt()
    {
        await using var context = new BenchMarkDbContext();

        await context.TableInt
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(Size)
            .Take(Size)
            .ToListAsync();
    }

    [Benchmark]
    public async Task Query_TableGuid()
    {
        await using var context = new BenchMarkDbContext();

        await context.TableGuid
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(Size)
            .Take(Size)
            .ToListAsync();
    }
    
    [Benchmark]
    public async Task Query_TableUlid()
    {
        await using var context = new BenchMarkDbContext();

        await context.TableUlid
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(Size)
            .Take(Size)
            .ToListAsync();
    }
    
    [Benchmark]
    public async Task Query_TableUlidBinary()
    {
        await using var context = new BenchMarkDbContext();

        await context.TableUlidBinary
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(Size)
            .Take(Size)
            .ToListAsync();
    }
}