using MauiAppChapterEightAndNine.ViewModels;

namespace MauiAppChapterEightAndNine.Views;

public partial class DataValidationPage : ContentPage
{
	public DataValidationPage(DataValidationViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}