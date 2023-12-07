using EvoSystems.DataContext;

namespace EvoSystems.Repository;

class Repository<T> where T : class
{
    private readonly AppDBContext _context;
    public Repository(AppDBContext context)
    {
        _context = context;
    }

    public async Task PostAsync(T obj)
    {
        await _context.Set<T>().AddAsync(obj);
    }
}