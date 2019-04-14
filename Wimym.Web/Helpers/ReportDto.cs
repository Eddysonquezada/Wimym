namespace Wimym.Web.Helpers
{
    public class GreaterUsersParticipationDto
    {
        public string User { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
        public int Photos { get; set; }
        public decimal Score { get; set; }
    }
}
