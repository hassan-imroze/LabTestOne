﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public BusinessDbContext Db;

        protected BaseRepository(DbContext db)
        {
            Db = db as BusinessDbContext;
        }

        public virtual IQueryable<TEntity> Filter(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            var query = Db.Set<TEntity>().AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                var properties = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var includeProperty in properties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            //    if (skip < 0) skip = 0;
            //     if (take <= 0) take = 10;
            //     query = query.Skip(skip).Take(take);
            return query;
        }

        public IQueryable<TEntity> Get()
        {
            var query = Db.Set<TEntity>().AsQueryable();
            return query;
        }
        public TEntity GetById(string id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return Db.Set<TEntity>().Add(entity);
        }

        public virtual bool Delete(TEntity entity)
        {
            var remove = Db.Set<TEntity>().Remove(entity);
            return true;
        }

        public virtual bool Edit(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual bool Save()
        {
            var changes = Db.SaveChanges();
            return changes > 0;
        }
    }
}

