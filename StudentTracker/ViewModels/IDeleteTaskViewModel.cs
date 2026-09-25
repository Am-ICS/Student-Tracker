using StudentTracker.Models;

namespace StudentTracker.ViewModels;

public interface IDeleteTaskViewModel
{
    TaskStudent TaskToDelete { get; set; }

    void DeleteTask();
}