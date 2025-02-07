using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmService;

public record OrderDto(string OrderId, List<ProductDto> Products);
