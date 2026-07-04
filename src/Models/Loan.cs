public class Loan
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public decimal Principal { get; set; }
    public decimal Rate { get; set; }
    public decimal MonthlyPayment { get; set; }
    public int Months { get; set; }

    public Loan(decimal principal, decimal rate, decimal monthlyPayment, int months)
    {
        Id = Guid.NewGuid();
        DateCreated = DateTime.UtcNow;
        DateUpdated = DateTime.UtcNow;
        Principal = principal;
        Rate = rate;
        MonthlyPayment = monthlyPayment;
        Months = months;
    }
}