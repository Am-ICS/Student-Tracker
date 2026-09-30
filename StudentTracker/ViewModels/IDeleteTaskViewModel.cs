using System.Windows.Input;
using StudentTracker.Models;

namespace StudentTracker.ViewModels;

public interface IDeleteTaskViewModel
{
    TaskStudent TaskToDelete { get; set; }
    public ICommand DeleteTaskCommand { get; }

}