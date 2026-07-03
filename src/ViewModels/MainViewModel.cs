using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DecimalMath;

public partial class MainViewModel: ObservableObject
{
    [ObservableProperty] private decimal _principal;
    [ObservableProperty] private decimal _rate;
    [ObservableProperty] private decimal _months;
    [ObservableProperty] private decimal _monthlyPayment;

    [RelayCommand]
    public async Task CalculateMonthlyPayment()
    {
        // M = (p * i)/(1 - (1 + i)^-n)
        var realRate = Rate / 12 / 100;
        var denominator = 1 - DecimalEx.Pow(1 + realRate, -Months);
        MonthlyPayment = (Principal * realRate / denominator);
    }
}