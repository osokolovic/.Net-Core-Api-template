using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ServiceCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Infrastructure
{
    public class TemplateContext : DbContext, IUnitOfWork
    {
        private readonly ILogger<TemplateContext> Logger;
        public IConfiguration Configuration { get; }
        public TemplateContext(ILogger<TemplateContext> logger, IConfiguration configuration) : base()
        {
            Logger = logger;
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public void Commit()
        {
            base.SaveChanges();
        }

        //error CS8107: Feature 'default literal' is not available in C# 7.0. Please use language version 7.1 or greater.
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
