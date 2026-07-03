public class Loan
{
    public Guid Id { get; set; }
    public DateTime date_created { get; set; }
    public DateTime date_updated { get; set; }
    public decimal Principal { get; set; }
    public decimal Rate { get; set; }
    public decimal MonthlyPayment { get; set; }
    public int Months { get; set; }
}