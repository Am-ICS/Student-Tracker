using System.ComponentModel;
using StudentTracker.Models;
using StudentTracker.ViewModels;
using StudentTracker.Services;

namespace StudentTracker.Views;

public partial class MainPage : ContentPage
{
    
    public IMainPageViewModel ViewModel { get; private set; }
    private IDetailStudentTaskViewModel detailViewModel;
    private IAddTaskViewModel addTaskViewModel;
    private IDeleteTaskViewModel deleteViewModel;
    
    public MainPage(
        IMainPageViewModel viewModel,
        IDetailStudentTaskViewModel detailViewModel,
        IAddTaskViewModel addTaskViewModel,
        IDeleteTaskViewModel deleteViewModel)
    {
        ViewModel = viewModel;
        this.detailViewModel = detailViewModel;
        this.addTaskViewModel = addTaskViewModel;
        this.deleteViewModel = deleteViewModel;

        InitializeComponent();

        ViewModel.OnTaskSelected += (task) => NavigateToTaskDetailsPage(task);

        BindingContext = ViewModel;
    }

    public async void NavigateToTaskDetailsPage(TaskStudent task)
    {
        await Navigation.PushAsync(new DetailStudentTask(task, detailViewModel, deleteViewModel));
    }
	
    protected override void OnAppearing()
    {
        base.OnAppearing();
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            string appDataDirectory = FileSystem.AppDataDirectory;
            Storage.Init(appDataDirectory);

            await ViewModel.LoadStudentAsync();
        });
    }

    // private async void OnAddNewTaskStudentClicked(object sender, EventArgs e)
    // {
    //
    //     await Navigation.PushAsync(new AddTask(addTaskViewModel));
    // }

    public void OnFilterClicked(object sender, EventArgs e)
    {
        if (ViewModel.IsVisible == true)
        {
            ViewModel.IsVisible = false;
        }
        else if (ViewModel.IsVisible == false)
        {
            ViewModel.IsVisible = true;
        }
        
    }
    

}