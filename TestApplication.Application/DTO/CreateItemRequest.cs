using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Application.DTO
{
    public record CreateItemRequest(
         string Name,
         string Description,
         int Price,
         int Count,
         Guid CategoryId
     );

}
