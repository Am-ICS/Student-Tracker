using System.Collections.ObjectModel;
using StudentTask;
using StudentTracker.Models;
using StudentTracker.ViewModels;
using StudentTracker.Services;
namespace Test.Service;
public class DeleteTaskViewModelTest
{
    [Fact]
    public void TestSelectTask_TriggersEvent()
    {
        // setup
        var service = new TaskService(new ObservableCollection<TaskStudent>());
        var viewModel = new MainPageViewModel();
        var task = new TaskStudent { Name = "Complete Homework" };
        
        TaskStudent eventResult = null;
        viewModel.OnTaskSelected += (selectedTask) =>
        {;
            eventResult = selectedTask;
        };

        // invoke
        viewModel.SelectTask = task;

        // assert
        Assert.NotNull(eventResult);
        Assert.Equal("Complete Homework", eventResult.Name);
    }

}