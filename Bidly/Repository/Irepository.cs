using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Bidly.Repository
{
    public interface Irepository<tbl_Entity> where tbl_Entity:class
    {
        IEnumerable<tbl_Entity> GetProduct();
        IEnumerable<tbl_Entity> Getallrecords();
        IQueryable<tbl_Entity> GetallRecordsuearable();
        int Getallrecordscount();
        void Add(tbl_Entity entity);
        void Update(tbl_Entity entity);
        void UpdateBywhereclause(Expression<Func<tbl_Entity,bool>>wherepredict, Action<tbl_Entity>Foreachpredict);
        tbl_Entity GetFirstorDefault(int record);
        void Remove(tbl_Entity entity);
        void RemoveBywhereClause(Expression<Func<tbl_Entity,bool>>wherepredict);
        void RemoveRangeByWhere(Expression<Func<tbl_Entity,bool>> wherepredict);
        void InactiveAndDeleteMarkBywhereclause(Expression<Func<tbl_Entity,bool>> wherepredict, Action<tbl_Entity>Foreachpredict);
        tbl_Entity GetFirstorDefaultByparameter(Expression<Func<tbl_Entity, bool>>wherepredict);
        IEnumerable<tbl_Entity> GetLlistParameter(Expression<Func<tbl_Entity, bool>> wherepredict);
        IEnumerable<tbl_Entity> GetresultBysqlprocedure(string query, params object[] parameters);
        IEnumerable<tbl_Entity> GetrecordsToShow(int PageNo, int PageSize, int CurrentPage, Expression<Func<tbl_Entity, bool>> wherepredict, Expression<Func<tbl_Entity, int>> orderbypredict);
    }
}