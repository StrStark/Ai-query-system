using databasTest.Models;
using Microsoft.EntityFrameworkCore;

namespace databasTest
{
    public class SalesQueryRepository
    {
        private readonly AdventureWorks2022Context _context;

        public SalesQueryRepository(AdventureWorks2022Context context)
        {
            _context = context;
        }

        public IQueryable<SalesOrderDetail> QuerySalesDetails()
        {
            return _context.SalesOrderDetails
                .Include(s => s.SalesOrder)
                .Include(s => s.SpecialOfferProduct)
                .AsQueryable();
        }
    }

}
