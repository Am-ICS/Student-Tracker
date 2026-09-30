using StudentTracker.Services;
using StudentTracker.ViewModels;
using StudentTracker.Views;

namespace StudentTracker;

public partial class App : Application
{
    private MainPage mainPage;
    private readonly INavigationService navigationService;

    public App(MainPage mainPage, INavigationService  navigationService)
    {
        InitializeComponent();

        this.mainPage = mainPage;
        this.navigationService = navigationService;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        NavigationPage navigationPage = new NavigationPage(mainPage);
        this.navigationService.SetNavigation(navigationPage.Navigation);
        return new Window(navigationPage);
    }
}