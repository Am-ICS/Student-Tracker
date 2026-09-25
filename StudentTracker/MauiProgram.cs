using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using StudentTracker.Models;
using StudentTracker.Services;
using StudentTracker.ViewModels;
using StudentTracker.Views;

namespace StudentTracker;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<ObservableCollection<TaskStudent>>();
        builder.Services.AddSingleton<ITaskService, TaskService>();
        //builder.Services.AddSingleton<INavigationService, NavigationService>(); 
        builder.Services.AddTransient<INavigationService, NavigationService>();
        builder.Services.AddTransient<IMainPageViewModel, MainPageViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<App>();

        builder.Services.AddTransient<TaskStudent>();
        builder.Services.AddTransient<IDetailStudentTaskViewModel, DetailStudentTaskViewModel>();
        builder.Services.AddTransient<DetailStudentTask>();
        builder.Services.AddTransient<IAddTaskViewModel, AddTaskViewModel>();
        builder.Services.AddTransient<AddTask>();
        builder.Services.AddTransient<IDeleteTaskViewModel, DeleteTaskViewModel>();
        builder.Services.AddTransient<DeleteTask>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}