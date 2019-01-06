using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Davis.NoteTracker.Mobile.Core.ViewModels
{
    public class DashboardViewModel : MvxViewModel
    {
        private readonly IUserDialogs _UserDialogs;
        private readonly IMvxNavigationService _NavigationService;
        public DashboardViewModel(IUserDialogs pUserDialogs, IMvxNavigationService pNavigationService)
        {
            _UserDialogs = pUserDialogs;
            _NavigationService = pNavigationService;
            
        }

        private MvxObservableCollection<string> _Items = new MvxObservableCollection<string>();
        public MvxObservableCollection<string> Items
        {
            get => _Items;
            set => SetProperty(ref _Items, value);
        }

        private bool _IsNoNoteLabelVisible = true;
        public bool IsNoNoteLabelVisible
        {
            get => _IsNoNoteLabelVisible;
            set => SetProperty(ref _IsNoNoteLabelVisible, value);
        }


        public ICommand AddNoteCommand => new MvxAsyncCommand(AddNote);
        private async Task AddNote()
        {
            var IsFirstCreationAttempt = true;
            var NoteText = string.Empty;

            do
            {
                PromptResult Dialog = await _UserDialogs.PromptAsync(new PromptConfig()
                {
                    CancelText = "Cancel",
                    Message = "Enter your note message below.",
                    OkText = "Create",
                    Title = "Create Note",
                });

                if (!Dialog.Ok)
                {
                    return;
                }
                else if (!IsFirstCreationAttempt)
                {
                    _UserDialogs.Toast("Please enter text or click Cancel", TimeSpan.FromSeconds(3));
                }

                IsFirstCreationAttempt = false;
                NoteText = Dialog.Text;
            } while (string.IsNullOrWhiteSpace(NoteText));


            IProgressDialog LoadingDialog = _UserDialogs.Loading("Creating Note", null, null, true, MaskType.Gradient);

            await Task.Delay(3000);
            LoadingDialog.Hide();

            Items.Add(NoteText);
            IsNoNoteLabelVisible = false;

            _UserDialogs.Toast("Note successfully created!", TimeSpan.FromMilliseconds(1500));
        }
    }
}
