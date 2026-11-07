using Ferreteria.Repositories;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class QueryReportService(QueryReportRepository repo) : IQueryReportService
    {
        public readonly QueryReportRepository _repo = repo;
    }
}
