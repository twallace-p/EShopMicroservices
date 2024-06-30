﻿
namespace Ordering.Application.Orders.Queries.GetOrders;
public class GetOrdersHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginzationRequest.PageIndex;
        var pageSize = query.PaginzationRequest.PageSize;

        var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);

        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new GetOrdersResult(
            new PaginatedResult<OrderDto>(
                pageIndex, 
                pageSize, 
                totalCount, 
                orders.ToOrderDtoList()
            ));
    }
}
