﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RpaPlatformProject.DataAccess.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly RpaDbContext _context;
		private readonly DbSet<T> _dbSet;
		public GenericRepository(RpaDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
		{
			return await _dbSet.Where(predicate).ToListAsync();
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}
	}
}
