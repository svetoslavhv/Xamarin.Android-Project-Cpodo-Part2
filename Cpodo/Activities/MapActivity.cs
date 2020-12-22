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
	[Activity(Label = "MapActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class MapActivity : BaseActivity
	{
		Toolbar toolbar;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.MapActivity);

			toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};
		}

		public override void OnBackPressed()
		{
			StartActivity(typeof(LocationActivity));
			Finish();
		}
	}
}