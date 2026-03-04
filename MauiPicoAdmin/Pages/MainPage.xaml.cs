using MauiPicoAdmin.Models;
using MauiPicoAdmin.PageModels;

namespace MauiPicoAdmin.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}