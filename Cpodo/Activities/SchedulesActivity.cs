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
using Cpodo.Models;

namespace Cpodo.Activities
{
	[Activity(Label = "ScheduleActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class SchedulesActivity : BaseActivity
	{
		TextView scheduleFridayTextView;
		TextView scheduleSaturdayTextView;
		RecyclerView schedulesRecyclerView;
		
		// Layout manager that lays out each card in the RecyclerView:
		RecyclerView.LayoutManager schedulesLayoutManager;

		// Adapter that accesses the data set (schedules):
		SchedulesAdapter schedulesAdapter;
		
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.SchedulesActivity);

			Android.Widget.Toolbar toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};
			

			List<Schedule> schedules = new List<Schedule>
				{
					new Schedule { ShortDescription = "Short Desctription 1"},
					new Schedule { ShortDescription = "Short Desctription 2"}
				};

			schedulesRecyclerView = FindViewById<RecyclerView>(Resource.Id.schedulesRecyclerView);
			schedulesLayoutManager = new LinearLayoutManager(this);
			schedulesRecyclerView.SetLayoutManager(schedulesLayoutManager);
			schedulesAdapter = new SchedulesAdapter(schedules);
			schedulesRecyclerView.SetAdapter(schedulesAdapter);

			scheduleFridayTextView = FindViewById<TextView>(Resource.Id.scheduleFridayTextView);
			scheduleFridayTextView.Click += delegate
			{
				//change TextViews color
				scheduleSaturdayTextView.SetBackgroundResource(Resource.Drawable.textView_unselected);
				scheduleFridayTextView.SetBackgroundResource(Resource.Drawable.textView_selected);

				//TODO: Change recyclerview here
			};

			scheduleSaturdayTextView = FindViewById<TextView>(Resource.Id.scheduleSaturdayTextView);
			scheduleSaturdayTextView.Click += delegate
			{
				//change TextViews color
				scheduleFridayTextView.SetBackgroundResource(Resource.Drawable.textView_unselected);
				scheduleSaturdayTextView.SetBackgroundResource(Resource.Drawable.textView_selected);

				//TODO: Change recyclerview here
			};

		}

		public override void OnBackPressed()
		{
			StartActivity(typeof(CongressActivity));
			Finish();
		}
	}
}