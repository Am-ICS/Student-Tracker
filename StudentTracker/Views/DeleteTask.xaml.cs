
using System;
using StudentTracker.ViewModels;

namespace StudentTracker.Views;

public partial class DeleteTask : ContentPage
{
    private IDeleteTaskViewModel deleteTaskViewModel;

    public DeleteTask(IDeleteTaskViewModel viewModel)
    {
        InitializeComponent();

        deleteTaskViewModel = viewModel;

        BindingContext = deleteTaskViewModel;
    }

    private async void onDeleteTaskClicked(object sender, EventArgs e)
    {
        try
        {
            deleteTaskViewModel.DeleteTask();

            await Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}