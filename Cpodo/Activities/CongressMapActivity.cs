using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Cpodo.Fragments;

namespace Cpodo.Activities
{
	[Activity(Label = "CongressMapActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class CongressMapActivity : BaseActivity
	{
		Toolbar toolbar;

		TextView exhibitionAreaTextView;
		TextView multipurposeRoomTextView;

		/// <summary>
		/// variable that holds the name of the previous activity
		/// (the activity which called this activity)
		/// </summary>
		string previousActivity;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.CongressMapActivity);

			toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};

			exhibitionAreaTextView = FindViewById<TextView>(Resource.Id.exhibitionAreaTextView);
			multipurposeRoomTextView = FindViewById<TextView>(Resource.Id.multipurposeRoomTextView);

			ExhibitionAreaFragment exhibitionAreaFragment = new ExhibitionAreaFragment();
			MultipurposeRoomFragment multipurposeRoomFragment = new MultipurposeRoomFragment();

			SupportFragmentManager.BeginTransaction().Add(Resource.Id.imageZoneLinearLayout, exhibitionAreaFragment).Commit();
			
			exhibitionAreaTextView.Click += delegate
			{
				//change one fragment for another
				SupportFragmentManager.BeginTransaction().Replace(Resource.Id.imageZoneLinearLayout, exhibitionAreaFragment).Commit();

				exhibitionAreaTextView.SetBackgroundResource(Resource.Drawable.textView_selected);
				multipurposeRoomTextView.SetBackgroundResource(Resource.Drawable.textView_unselected);
			};

			multipurposeRoomTextView.Click += delegate
			{
				//change one fragment for another
				SupportFragmentManager.BeginTransaction().Replace(Resource.Id.imageZoneLinearLayout, multipurposeRoomFragment).Commit();

				multipurposeRoomTextView.SetBackgroundResource(Resource.Drawable.textView_selected);
				exhibitionAreaTextView.SetBackgroundResource(Resource.Drawable.textView_unselected);
			};

			//get the previous activity name
			previousActivity = Intent.GetStringExtra("previousActivity");
		}
		
		public override void OnBackPressed()
		{
			//Check which activity called the current activity and go back there
			if (previousActivity.Equals("ExhibitionAreaActivity"))
			{
				StartActivity(typeof(ExhibitionAreaActivity));
				Finish();
			}

			if (previousActivity.Equals("CongressActivity"))
			{
				StartActivity(typeof(CongressActivity));
				Finish();
			}
		}
	}
}