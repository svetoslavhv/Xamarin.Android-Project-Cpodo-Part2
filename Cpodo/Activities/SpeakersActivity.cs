using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Cpodo.Adapters;
using Cpodo.HelperClasses;
using Cpodo.Models;

namespace Cpodo.Activities
{
	[Activity(Label = "SpeakersActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class SpeakersActivity : BaseActivity
	{
		TextView internationalSpeakersTextView;

		TextView nationalSpeakersTextView;

		RecyclerView speakersRecyclerView;

		// Layout manager that lays out each card in the RecyclerView:
		RecyclerView.LayoutManager speakersLayoutManager;

		// Adapter that accesses the data set (speakers):
		SpeakersAdapter speakersAdapter;
		
		/// <summary>
		/// List that contains all the speakers
		/// </summary>
		List<Speaker> allSpeakers;

		/// <summary>
		/// List that contains the international speakers
		/// </summary>
		List<Speaker> internationalSpeakers;

		/// <summary>
		/// List that contains the national speakers
		/// </summary>
		List<Speaker> nationalSpeakers;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.SpeakersActivity);

			Android.Widget.Toolbar toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};
			
			//get all the speakers from the db
			allSpeakers = DatabaseHelper.GetAllFromTable<Speaker>("speakers.db");

			//get only the international spakers
			internationalSpeakers = allSpeakers.Where(x => x.Nationality.Equals("international")).ToList();

			//get only the national speakers
			nationalSpeakers = allSpeakers.Where(x => x.Nationality.Equals("national")).ToList();

			speakersRecyclerView = FindViewById<RecyclerView>(Resource.Id.speakersRecyclerView);
			speakersLayoutManager = new LinearLayoutManager(this);
			speakersRecyclerView.SetLayoutManager(speakersLayoutManager);
			LoadSpeakers(internationalSpeakers);

			internationalSpeakersTextView = FindViewById<TextView>(Resource.Id.internationalSpeakersTextView);
			internationalSpeakersTextView.Click += delegate
			{
				//change TextViews's style when selected/not-selected
				internationalSpeakersTextView.SetBackgroundResource(Resource.Drawable.textView_selected);
				nationalSpeakersTextView.SetBackgroundResource(Resource.Drawable.textView_unselected);

				LoadSpeakers(internationalSpeakers);
			};

			nationalSpeakersTextView = FindViewById<TextView>(Resource.Id.nationalSpeakersTextView);
			nationalSpeakersTextView.Click += delegate
			{
				//change TextViews's style when selected/not-selected
				nationalSpeakersTextView.SetBackgroundResource(Resource.Drawable.textView_selected);
				internationalSpeakersTextView.SetBackgroundResource(Resource.Drawable.textView_unselected);

				LoadSpeakers(nationalSpeakers);
			};
		}

		/// <summary>
		/// Load speakers inside activity
		/// </summary>
		/// <param name="speakers">speakers</param>
		private void LoadSpeakers(List<Speaker> speakers)
		{
			speakersAdapter = new SpeakersAdapter(speakers);
			speakersAdapter.ItemClick += OnItemClick;
			speakersRecyclerView.SetAdapter(speakersAdapter);
		}

		private void OnItemClick(object sender, string speakerResumeUrl)
		{
			var speakerDetailsActivity = new Intent(this, typeof(SpeakerDetailsActivity));
			speakerDetailsActivity.PutExtra("speakerResumeUrl", speakerResumeUrl);
			StartActivity(speakerDetailsActivity);
		}

		public override void OnBackPressed()
		{
			StartActivity(typeof(CongressActivity));
			Finish();
		}
	}
}