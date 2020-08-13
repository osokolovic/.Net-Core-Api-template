using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.IRepositories;
using ServiceCore;
using Template.Domain.Models;

namespace Template.Infrastructure.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly TemplateContext _context;
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }
        public TemplateRepository(TemplateContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public TemplateModel Add(TemplateModel newEntity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TemplateModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TemplateModel> FindBy(Expression<Func<TemplateModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TemplateModel> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TemplateModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
