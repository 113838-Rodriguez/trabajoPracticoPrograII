using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;

namespace Ferreteria.Repositories
{
    public class QueryReportRepository(FerreteriaContext db) : IQueryReportRepository
    {
        public readonly FerreteriaContext _db = db;
    }
}