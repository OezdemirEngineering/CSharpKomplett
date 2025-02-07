using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmService;

public class UserDto(PersonalDto dto, List<OrderDto> orders)
{
    public PersonalDto PersonalDto { get; set; } = dto;
    public List<OrderDto> Orders { get; set; } = orders;
}
