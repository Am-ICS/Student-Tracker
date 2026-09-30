using StudentTracker.Models;
using StudentTracker.ViewModels;
using StudentTracker.Views;

namespace StudentTracker.Services;

public class NavigationService : INavigationService
{
    private IServiceProvider serviceProvider;
    private INavigation? navigation;
    
    public NavigationService(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public void SetNavigation(INavigation navigation)
    {
        this.navigation = navigation;
    }

    public async Task PopAsync()
    {
        await this.navigation.PopAsync();
    }

    public async Task GoToTaskDetailAsync(TaskStudent task)
    {
        //use the service provider to get the models
        IDetailStudentTaskViewModel detailStudentTaskViewModel = 
            this.serviceProvider.GetRequiredService<IDetailStudentTaskViewModel>();
        IDeleteTaskViewModel deleteTaskViewModel = this.serviceProvider.GetRequiredService<IDeleteTaskViewModel>();

        await this.navigation.PushAsync(
            new DetailStudentTask(task,
                detailStudentTaskViewModel,
                deleteTaskViewModel)
        );
    }

    public async Task GoToAddNewTask()
    {
        //get the viewmodel
        IAddTaskViewModel addTaskViewModel = 
            this.serviceProvider.GetRequiredService<IAddTaskViewModel>();
        
        await this.navigation.PushAsync(new AddTask(addTaskViewModel));

    }
    
}