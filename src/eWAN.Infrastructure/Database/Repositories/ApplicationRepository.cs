using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Application;
    using Microsoft.EntityFrameworkCore;
    using Application = Entities.Application;

    public class ApplicationRepository : IApplicationRepository
    {
        public ApplicationRepository(EwanContext context) => this._context = context ?? throw new ArgumentNullException(nameof(context));

        private readonly EwanContext _context;

        public async Task Add(IApplication newApplication)
        {
            this._context.Entry(newApplication.Applicant).State = EntityState.Unchanged;
            this._context.Applications.Add((Application) newApplication);
            await this._context.SaveChangesAsync();
        }

        public IApplication GetApplicationById(string id)
        {
            return (IApplication) this._context.Applications.FirstOrDefault(x => x.PublicId == id && x.DeletedAt == null);
        }

        public List<IApplication> GetApplicationsByApplicantId(int applicantId)
        {
            var query = this._context.Applications.Where(x => x.Applicant.Id == applicantId && x.DeletedAt == null);
            return query.Cast<IApplication>().ToList();
        }
    }
}
