using MauiPicoAdmin.Models;

namespace MauiPicoAdmin.Pages;

public partial class ProjectDetailPage : ContentPage
{
    public ProjectDetailPage(ProjectDetailPageModel model)
    {
        InitializeComponent();

        BindingContext = model;
    }
}
