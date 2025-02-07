using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmService;

public class Service(List<UserDto> users)
{
    public List<UserDto> Users { set; get; } = users;

    public List<OrderDto>  GetAllOrders()
    {
        var orders = new List<OrderDto>();
        foreach (var user in Users)
        {
            foreach (var order in user.Orders)
            {
                orders.Add(order);
            }
        }

        return orders;
    }
}
