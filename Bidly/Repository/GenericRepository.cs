using Bidly.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Bidly.Repository
{
    public class GenericRepository<tbl_entity> : Irepository<tbl_entity> where tbl_entity : class
    {
        DbSet<tbl_entity> _dbset;
        private dbonline_ShoppingEntities _Dbentity;

        public GenericRepository(dbonline_ShoppingEntities Dbentity)
        {
            _Dbentity = Dbentity;
            _dbset = _Dbentity.Set<tbl_entity>();
        }

        public void Add(tbl_entity entity)
        {
            _dbset.Add(entity);
            _Dbentity.SaveChanges();
        }

        public IEnumerable<tbl_entity> Getallrecords()
        {
            return _dbset.ToList();
        }

        public int Getallrecordscount()
        {
            return _dbset.Count();
        }

        public IQueryable<tbl_entity> GetallRecordsuearable()
        {
            return _dbset;
        }

        public tbl_entity GetFirstorDefault(int record)
        {
            return _dbset.Find(record);
        }

        public tbl_entity GetFirstorDefaultByparameter(Expression<Func<tbl_entity, bool>> wherepredict)
        {
            return _dbset.Where(wherepredict).FirstOrDefault();
        }

        public IEnumerable<tbl_entity> GetLlistParameter(Expression<Func<tbl_entity, bool>> wherepredict)
        {
            return _dbset.Where(wherepredict).ToList();
        }

        public IEnumerable<tbl_entity> GetresultBysqlprocedure(string query, params object[] parameters)
        {
            if (parameters != null)
            {
                return _Dbentity.Database.SqlQuery<tbl_entity>(query, parameters).ToList();
            }
            else
                return _Dbentity.Database.SqlQuery<tbl_entity>(query).ToList();
        }

        public void InactiveAndDeleteMarkBywhereclause(Expression<Func<tbl_entity, bool>> wherepredict, Action<tbl_entity> Foreachpredict)
        {
            _dbset.Where(wherepredict).ToList().ForEach(Foreachpredict);
        }

        public void Remove(tbl_entity entity)
        {
            if (_Dbentity.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
        }

        public void RemoveBywhereClause(Expression<Func<tbl_entity, bool>> wherepredict)
        {
            List<tbl_entity> entity = _dbset.Where(wherepredict).ToList();
        }

        public void RemoveRangeByWhere(Expression<Func<tbl_entity, bool>> wherepredict)
        {
            List<tbl_entity> entity = _dbset.Where(wherepredict).ToList();
            foreach (var ent in entity)
            {
                Remove(ent);
            }
        }

        public void Update(tbl_entity entity)
        {
            _dbset.Attach(entity);
            _Dbentity.Entry(entity).State = EntityState.Modified;
            _Dbentity.SaveChanges();
        }

        public void UpdateBywhereclause(Expression<Func<tbl_entity, bool>> wherepredict, Action<tbl_entity> Foreachpredict)
        {
            _dbset.Where(wherepredict).ToList().ForEach(Foreachpredict);
        }

        public IEnumerable<tbl_entity> GetrecordsToShow(int PageNo, int PageSize, int CurrentPage, Expression<Func<tbl_entity, bool>> wherepredict, Expression<Func<tbl_entity, int>> orderbypredict)
        {
            if (wherepredict != null)
            {
                return _dbset.OrderBy(orderbypredict).Where(wherepredict).ToList();
            }
            else
            {
                return _dbset.OrderBy(orderbypredict).ToList();
            }
        }

        public IEnumerable<tbl_entity> GetProduct()
        {
            return _dbset.ToList();
        }
    }
}