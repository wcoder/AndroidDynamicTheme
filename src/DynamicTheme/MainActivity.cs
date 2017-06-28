using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace DynamicTheme
{
	[Activity(
		MainLauncher = true,
		Label = "@string/ApplicationName",
		Icon = "@drawable/icon",
		Theme = "@style/AppTheme.Dark")]
	public class MainActivity : Activity
	{
		public int CurrentTheme => PackageManager.GetActivityInfo(ComponentName, 0).Theme;

		protected override void OnCreate(Bundle bundle)
		{
			// change theme
			SetTheme(StaticStore.IsDarkTheme ? Resource.Style.AppTheme_Dark : Resource.Style.AppTheme_Light);

			// create view

			base.OnCreate(bundle);
			SetContentView (Resource.Layout.Main);

			// setup buttons

			var darkButton = FindViewById<Button>(Resource.Id.darkThemeButton);
			darkButton.Click += (sender, args) =>
			{
				StaticStore.IsDarkTheme = true;
				RestartActivity();
			};

			var lightButton = FindViewById<Button>(Resource.Id.lightThemeButton);
			lightButton.Click += (sender, args) =>
			{
				StaticStore.IsDarkTheme = false;
				RestartActivity();
			};

		}

		private void RestartActivity()
		{
			var intent = new Intent(this, typeof(MainActivity));
			StartActivity(intent);
			Finish();
		}
	}
}

