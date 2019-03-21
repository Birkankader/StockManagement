using StockManagement.WebUI.Entity;
using StockManagement.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StockManagement.WebUI.Repository.Concrete.EntityFramework
{
  public class EfUrunRepository : EfGenericRepository<Urun>,IUrunRepository
  {

    public EfUrunRepository(StockManagementContext context)
      : base(context)
    {

    }
    public StockManagementContext StockContext
    {
      get { return context as StockManagementContext; }
    }

  }
}