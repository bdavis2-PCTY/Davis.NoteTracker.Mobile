using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Davis.NoteTracker.Mobile.Core.ViewModels;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Platforms.Android;

namespace Davis.NoteTracker.Mobile.Droid
{
    [Activity(
        Theme = "@style/AppTheme")]
    public class MainActivity : MvxFormsAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            UserDialogs.Init(() => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity);

            base.OnCreate(bundle);
        }
    }
}
