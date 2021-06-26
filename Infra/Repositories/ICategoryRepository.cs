using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
    }
}
