namespace Wimym.Model.Shared.Helper
{
    public class ApiFilter
    {
        public string Sort { get; set; }
        public bool Descending { get; set; }
        public string Filter { get; set; }

        // Pagination logic
        public int Take { get; set; }
        public int Page { get; set; }

        public ApiFilter()
        {
            Take = 25;
        }
    }
}
