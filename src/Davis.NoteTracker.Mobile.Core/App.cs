using Acr.UserDialogs;
using Davis.NoteTracker.Mobile.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace Davis.NoteTracker.Mobile.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<DashboardViewModel>();

            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
        }
    }
}
