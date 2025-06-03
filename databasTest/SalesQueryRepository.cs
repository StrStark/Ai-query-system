using Microsoft.EntityFrameworkCore;

namespace databasTest
{
    public class SalesQueryRepository
    {
        private readonly RsvpContext _context;

        public SalesQueryRepository(RsvpContext context)
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
