using System.Collections.ObjectModel;
using StudentTracker.Models;
using StudentTracker.Services;
using StudentTracker.Views;

namespace StudentTracker.ViewModels;

public interface IAddTaskViewModel
{
    public string Name { get; set; }

    public Task AddTask();
}