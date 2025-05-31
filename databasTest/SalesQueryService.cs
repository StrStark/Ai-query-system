using databasTest;
using databasTest.Models;
using Microsoft.EntityFrameworkCore;

public class SalesQueryService
{
    private readonly SalesQueryRepository _repository;

    public SalesQueryService(SalesQueryRepository repository)
    {
        _repository = repository;
    }

    public IQueryable<object> GetFilteredSales(
        DateTime? from = null,
        DateTime? to = null,
        int? productId = null,
        decimal? minRevenue = null,
        decimal? maxDiscount = null,
        short? minQty = null
    )
    {
        var query = _repository.QuerySalesDetails();

        if (from.HasValue)
            query = query.Where(s => s.SalesOrder.OrderDate >= from.Value);

        if (to.HasValue)
            query = query.Where(s => s.SalesOrder.OrderDate <= to.Value);

        if (productId.HasValue)
            query = query.Where(s => s.ProductId == productId.Value);

        if (minQty.HasValue)
            query = query.Where(s => s.OrderQty >= minQty.Value);

        if (maxDiscount.HasValue)
            query = query.Where(s => s.UnitPriceDiscount <= maxDiscount.Value);

        if (minRevenue.HasValue)
            query = query.Where(s => s.LineTotal >= minRevenue.Value);

        return query.Select(s => new
        {
            s.SalesOrderId,
            s.ProductId,
            s.OrderQty,
            s.UnitPrice,
            s.UnitPriceDiscount,
            s.LineTotal,
            s.SalesOrder.OrderDate
        });
    }
}
