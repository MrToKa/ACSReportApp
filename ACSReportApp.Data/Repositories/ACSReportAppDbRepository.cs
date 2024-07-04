using ACSReportApp.Data.Common;

namespace ACSReportApp.Data.Repositories
{
    public class ACSReportAppDbRepository : Repository, IACSReportAppDbRepository
    {
        public ACSReportAppDbRepository(ACSReportAppDbContext context)
        {
            Context = context;
        }
    }
}
