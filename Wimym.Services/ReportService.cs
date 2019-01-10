namespace Services
{
    using System;
    using System.Threading.Tasks;
    using Wimym.DatabaseContext;
    using Wimym.Model.Shared.Helper;

    public interface IReportService
    {
        Task<DataGridResponse> GreaterUsersParticipation(DataGrid grid);
    }

    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public Task<DataGridResponse> GreaterUsersParticipation(DataGrid grid)
        {
            throw new NotImplementedException();
        }
    }
}
