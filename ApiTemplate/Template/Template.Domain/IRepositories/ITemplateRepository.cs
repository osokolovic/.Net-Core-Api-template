using ServiceCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template.Domain.Models;

namespace Template.Domain.IRepositories
{
    public interface ITemplateRepository : IRepository<TemplateModel>
    {
    }
}
