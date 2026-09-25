using StudentTracker.ViewModels;
using StudentTracker.Views;

namespace StudentTracker;

public partial class App : Application
{
    private MainPage mainPage;

    public App(MainPage mainPage)
    {
        InitializeComponent();

        this.mainPage = mainPage;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(mainPage));
    }
}