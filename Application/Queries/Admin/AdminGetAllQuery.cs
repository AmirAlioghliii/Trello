using Infra.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Admin
{
    public class AdminGetAllQuery:IRequest<IEnumerable<UserTask>>
    {
    }
}
