using Bidly.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bidly.Repository
{
    public class GenerixUnitofWork:IDisposable
    {
        private dbonline_ShoppingEntities DBentity = new dbonline_ShoppingEntities();

        public Irepository<Tbl_EntityType> GetRepositoryInstance <Tbl_EntityType>() where Tbl_EntityType : class
        {
            return new GenericRepository<Tbl_EntityType>(DBentity);
        }

        public void SaveChanges()
        {
            DBentity.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DBentity.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        
    }
}