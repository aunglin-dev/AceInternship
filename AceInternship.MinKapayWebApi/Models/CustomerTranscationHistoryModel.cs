namespace AceInternship.MinKapayWebApi.Models
{
    public class CustomerTranscationHistoryModel
    {
        public int CustomerTransactionHistoryId { get; set; }
        public string FromMobileNo { get; set; }
        public string ToMobileNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
