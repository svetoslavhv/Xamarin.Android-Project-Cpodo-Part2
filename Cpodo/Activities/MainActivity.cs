using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Cpodo.Activities;
using Android.Content.PM;
using Android.Content;

namespace Cpodo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : BaseActivity
	{
		//TEST GITHUB COMMITS
		Button informationBtn;
		ImageButton congressImageBtn;
		ImageButton exhibitionAreaImageBtn;
		ImageButton facebookImageBtn;
		ImageButton twitterImageBtn;

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			
            SetContentView(Resource.Layout.MainActivity);

			FindViews();

			BindClickEvents();

		}

		/// <summary>
		/// Method to find the views
		/// </summary>
		private void FindViews()
		{
			informationBtn = FindViewById<Button>(Resource.Id.informationBtn);
			congressImageBtn = FindViewById<ImageButton>(Resource.Id.congressImageBtn);
			exhibitionAreaImageBtn = FindViewById<ImageButton>(Resource.Id.exhibitionAreaImageBtn);
			facebookImageBtn = FindViewById<ImageButton>(Resource.Id.facebookImageBtn);
			twitterImageBtn = FindViewById<ImageButton>(Resource.Id.twitterImageBtn);
		}

		/// <summary>
		/// Method to bind the click events
		/// </summary>
		private void BindClickEvents()
		{
			informationBtn.Click += delegate
			{
				StartActivity(typeof(ContactInformationActivity));
				Finish();
			};
			
			congressImageBtn.Click += delegate
			{
				StartActivity(typeof(CongressActivity));
				Finish();
			};
			
			exhibitionAreaImageBtn.Click += delegate
			{
				StartActivity(typeof(ExhibitionAreaActivity));
				Finish();
			};
			
			facebookImageBtn.Click += delegate
			{
				var uri = Android.Net.Uri.Parse("https://www.facebook.com/");
				var intent = new Intent(Intent.ActionView, uri);
				StartActivity(intent);
			};
			
			twitterImageBtn.Click += delegate
			{
				var uri = Android.Net.Uri.Parse("https://twitter.com/");
				var intent = new Intent(Intent.ActionView, uri);
				StartActivity(intent);
			};
			
		}
		
	}
}