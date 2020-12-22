using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cpodo.Activities
{
	[Activity(Label = "ExhibitionAreaActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class ExhibitionAreaActivity : BaseActivity
	{
		ImageButton exhibitionMapImageBtn;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.ExhibitionAreaActivity);

			Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};

			exhibitionMapImageBtn = FindViewById<ImageButton>(Resource.Id.exhibitionMapImageBtn);
			exhibitionMapImageBtn.Click += delegate
			{
				//this prevents user to click the button several times while CongressMapActivity is loading
				exhibitionMapImageBtn.Enabled = false;

				//open CongressMapActivity passing it the name of the current activity
				var congressMapActivity = new Intent(this, typeof(CongressMapActivity));
				congressMapActivity.PutExtra("previousActivity", "ExhibitionAreaActivity");
				StartActivity(congressMapActivity);
				Finish();
			};
		}

		public override void OnBackPressed()
		{
			StartActivity(typeof(MainActivity));
			Finish();
		}
	}
}