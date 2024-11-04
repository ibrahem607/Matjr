using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Management.Instrumentation;
using System.Threading.Tasks;

public class Repository<T>:IRepository<T> where T : class
{
	private readonly ApplicationDbContext _context;
	private readonly DbSet<T> _dbSet;



	public Repository(ApplicationDbContext context )
	{
		_context = context;
		_dbSet = context.Set<T>();
	}

	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<T> GetByIdAsync(int id)
	{
		return await _dbSet.FindAsync(id);
	}

	public async Task AddAsync(T entity)
	{
		await _dbSet.AddAsync(entity);
		_context.SaveChangesAsync();
	}
	public async Task UpdateAsync(T entity)
	{
		await _dbSet.UpdateAsync(entity);
		 _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var entity = await _dbSet.FindAsync( id);
		if (entity != null) 
		{
			await _dbSet.DeleteAsync(entity);
			 _context.SaveChangesAsync();
		}



}