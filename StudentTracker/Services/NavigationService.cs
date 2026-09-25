using StudentTracker.Models;
using StudentTracker.ViewModels;
using StudentTracker.Views;

namespace StudentTracker.Services;

public class NavigationService : INavigationService
{
    private IDetailStudentTaskViewModel _detailStudentTaskViewModel { get; set; }
    private IDeleteTaskViewModel _deleteTaskViewModel { get; set; }
  

    public NavigationService(IDeleteTaskViewModel deleteTaskViewModel, 
        IDetailStudentTaskViewModel detailStudentTaskViewModel)
    {
        _detailStudentTaskViewModel = detailStudentTaskViewModel;
        _deleteTaskViewModel = deleteTaskViewModel;
   
    }

    public async Task PopAsync()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    public async Task GoToTaskDetailAsync(TaskStudent task)
    {
        await Shell.Current.Navigation.PushAsync(new DetailStudentTask(task, _detailStudentTaskViewModel, _deleteTaskViewModel));
    }

    public async Task GoToAddNewTask()
    {
        IAddTaskViewModel addTaskViewModel =
            Application.Current.Handler.MauiContext.Services
                .GetService<IAddTaskViewModel>();

        await Shell.Current.Navigation.PushAsync(
            new AddTask(addTaskViewModel));
    }
    
}