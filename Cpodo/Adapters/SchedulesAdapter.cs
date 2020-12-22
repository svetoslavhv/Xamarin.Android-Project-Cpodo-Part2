using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Cpodo.Models;
using Cpodo.ViewHolders;

namespace Cpodo.Adapters
{
	public class SchedulesAdapter : RecyclerView.Adapter
	{
		public List<Schedule> listOfSchedules;

		public SchedulesAdapter(List<Schedule> schedules)
		{
			listOfSchedules = schedules;
		}

		public override int ItemCount
		{
			get { return listOfSchedules.Count; }
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			ScheduleViewHolder vh = holder as ScheduleViewHolder;
			
			vh.hourAndScheduleTextView.Text = /*listOfSchedules[position].Hour + " " + */listOfSchedules[position].ShortDescription;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemView = LayoutInflater.From(parent.Context).
						Inflate(Resource.Layout.ScheduleCardView, parent, false);

			ScheduleViewHolder vh = new ScheduleViewHolder(itemView);
			return vh;
		}
	}
}