using CommunityToolkit.Mvvm.Input;
using MauiPicoAdmin.Models;

namespace MauiPicoAdmin.PageModels;

public interface IProjectTaskPageModel
{
    IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
    bool IsBusy { get; }
}