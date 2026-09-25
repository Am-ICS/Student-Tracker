using System.Collections.ObjectModel;
using StudentTask;
using StudentTracker.Models;
using StudentTracker.ViewModels;
using StudentTracker.Services;
namespace Tests.Service;


public class TaskServiceTest
{
    [Fact]
    public void TestAdd()
    {
        //setup
        TaskService taskService = new TaskService(new ObservableCollection<TaskStudent>());
        int expectedTaskCount = 1;
        
        TaskStudent task = new TaskStudent()
            { Name = "Complete Homework", ID = "example description" };
        
        //invoke
        taskService.Add(task);
        
        //assert
        Assert.Equal(expectedTaskCount, taskService.Tasks.Count);
    }
        [Fact]
    public void TestAddFail()
    {
        //setup
        TaskService taskService = new TaskService(new ObservableCollection<TaskStudent>());
        int expectedTaskCount = 1;
        
       
        
        //invoke
    
        Assert.Throws<ArgumentException>(()=>new TaskStudent()
            { Name = "" });
        
        //assert
        //Assert.NotEqual(expectedTaskCount, taskService.Tasks.Count);
    }
    [Fact]
    public void TestRemove()
    {
        //setup
        TaskService taskService = new TaskService(new ObservableCollection<TaskStudent>());
        int expectedTaskCount = 0;
        TaskStudent task = new TaskStudent()
            { Name = "Complete Homework", ID = "example description", };
        taskService.Add(task); // Add first so there is something to delete
        
        //invoke
        taskService.Delete(task);
        
        //assert
        Assert.Equal(expectedTaskCount, taskService.Tasks.Count);
    }

    [Fact]
    public void TestToggleComplete()
    {
        var task = new TaskStudent { Name = "Study",};

        var taskService = new TaskService(new ObservableCollection<TaskStudent> { task });

        taskService.Complete(task);

        Assert.True(task.IsCompleted);
    }
 

}
