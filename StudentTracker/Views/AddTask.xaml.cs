using System;
using System.Collections.ObjectModel;
using StudentTracker.Models;
using StudentTracker.Services;
using StudentTracker.ViewModels;

namespace StudentTracker.Views;

public partial class AddTask : ContentPage
{
    private IAddTaskViewModel addTaskViewModel;
    public AddTask(IAddTaskViewModel viewModel)
    {
        InitializeComponent();
        addTaskViewModel = viewModel;
        
        BindingContext = addTaskViewModel;
    }
    
}