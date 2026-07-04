using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DecimalMath;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private decimal _principal;
    [ObservableProperty] private decimal _rate;
    [ObservableProperty] private decimal _months;
    [ObservableProperty] private decimal? _monthlyPayment;

    private ObservableCollection<Loan> _loans = [];

    public ReadOnlyObservableCollection<Loan> Loans { get; }

    public MainViewModel()
    {
        Loans = new(_loans);
    }

    [RelayCommand]
    public async Task AddNewLoan()
    {
        if (MonthlyPayment is null) return;
        var monthlyPayment = MonthlyPayment.Value;
        var newLoan = new Loan(Principal, Rate, monthlyPayment, (int)Months);
        _loans.Add(newLoan);
    }

    [RelayCommand]
    public async Task CalculateMonthlyPayment()
    {
        // M = (p * i)/(1 - (1 + i)^-n)
        var realRate = Rate / 12 / 100;
        var denominator = 1 - DecimalEx.Pow(1 + realRate, -Months);
        MonthlyPayment = (Principal * realRate / denominator);
    }
}