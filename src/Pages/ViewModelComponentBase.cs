using System.ComponentModel;
using Microsoft.AspNetCore.Components;

public abstract class ViewModelComponentBase<TViewModel> : ComponentBase, IDisposable
    where TViewModel : class, INotifyPropertyChanged
{
    [Inject]
    protected TViewModel ViewModel { get; set; } = default!;

    protected override void OnInitialized()
    {
        ViewModel.PropertyChanged += OnViewModelChanged;
    }

    protected virtual void OnViewModelChanged(object? sender, PropertyChangedEventArgs e) => InvokeAsync(StateHasChanged);

    public void Dispose() => ViewModel.PropertyChanged -= OnViewModelChanged;
}