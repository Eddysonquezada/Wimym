namespace Wimym.Domain.Dtos
{
    public class AccountDto
    {
        public int AccountId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool State { get; set; }

       // public WalletDto Wallet { get; set; }

        public int WalletId { get; set; }
    }
}
