namespace MainSite.Data.Models
{
    public class LedgerEntry
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now.ToUniversalTime();

        public decimal Amount { get; set; }

        public string Comment { get; set; }
    }
}
