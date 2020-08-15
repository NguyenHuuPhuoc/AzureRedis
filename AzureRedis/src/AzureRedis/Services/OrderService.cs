using AzureRedis.Models;
using MessagePack;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureRedis.Services
{
    public interface IOrderService
    {
        Task<PaginationSet<Models.Order>> GetAllOrderAsync(int pageIndex, int pageSize);
    }

    public class OrderService : IOrderService
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public OrderService(ConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = redis.GetDatabase();
        }

        public async Task<PaginationSet<Models.Order>> GetAllOrderAsync(int pageIndex, int pageSize)
        {
            var totalData = await GetAllAsync();
            var orders = totalData as Models.Order[] ?? totalData.ToArray();
            var queryData = orders.OrderByDescending(x => x.CheckInDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var res = new PaginationSet<Models.Order>
            {
                Items = queryData,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalRows = orders.Count()
            };
            return res;
        }

        private async Task<IEnumerable<Models.Order>> GetAllAsync()
        {
            try
            {
                var data = await _database.StringGetAsync("ALL_ORDERS");
                if (data.IsNullOrEmpty)
                {
                    return null;
                }

                return MessagePackSerializer.Deserialize<IEnumerable<Models.Order>>(data);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}