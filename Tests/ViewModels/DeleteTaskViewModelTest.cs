using System.Collections.ObjectModel;
using Moq;
using StudentTracker.Models;
using StudentTracker.ViewModels;
using StudentTracker.Services;
namespace Test.Service;
public class DeleteTaskViewModelTest
{
    [Fact]
    public void DeleteTask_RemovesTaskFromServiceTasksCollection()
    {
        {
            // Arrange
            var taskToDelete = new TaskStudent { Name = "Complete Homework" };
            //var tasks = new ObservableCollection<TaskStudent>() { taskToDelete };
            
            //the delete command trigger taskservice.delete
            //so we only care if the taskservice.delete got triggered
            
            var mockTaskService = new Mock<ITaskService>();
            ITaskService service = mockTaskService.Object;
            var mockNavigationService = new Mock<INavigationService>();
            INavigationService navigationService = mockNavigationService.Object;
            mockNavigationService.Setup(nav=> nav.PopAsync()).Returns(Task.CompletedTask);
            var viewModel = new DeleteTaskViewModel(service, navigationService)
            {
                TaskToDelete = taskToDelete
            };
            
            //act
            viewModel.DeleteTaskCommand.Execute(null);
            
            //assert / verify
            mockTaskService.Verify(
                taskService=> 
                    taskService.Delete(taskToDelete),
                Times.Once
            );
            
        }


    }

}