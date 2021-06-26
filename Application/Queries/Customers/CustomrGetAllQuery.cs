using Infra.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Customers
{
    public class CustomrGetAllQuery : IRequest<IEnumerable<UserTask>>
    {
        public int CategoryId { get; set; }
    }
}
