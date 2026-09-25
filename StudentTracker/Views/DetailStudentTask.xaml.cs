using System;
using StudentTracker.Models;
using StudentTracker.Services;
using StudentTracker.ViewModels;

namespace StudentTracker.Views;

public partial class DetailStudentTask : ContentPage
{
    public IDetailStudentTaskViewModel ViewModel { get; private set; }
    public IDeleteTaskViewModel DeleteViewModel { get; private set; }

    public DetailStudentTask (TaskStudent task, IDetailStudentTaskViewModel viewModel, IDeleteTaskViewModel deleteViewModel)
    {
        InitializeComponent();

        ViewModel = viewModel;
        DeleteViewModel = deleteViewModel;

        DeleteViewModel.TaskToDelete = task;

        BindingContext = task;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DeleteTask(DeleteViewModel));
    }
}