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

namespace Cpodo.ViewHolders
{
	public class ScheduleViewHolder : RecyclerView.ViewHolder
	{
		public ImageView starImageView { get; private set; }
		public TextView hourAndScheduleTextView { get; private set; }

		// Get references to the views defined in the CardView layout.
		public ScheduleViewHolder(View itemView)
			: base(itemView)
		{
			// Locate and cache view references:
			starImageView = itemView.FindViewById<ImageView>(Resource.Id.starImageView);
			hourAndScheduleTextView = itemView.FindViewById<TextView>(Resource.Id.hourAndScheduleTextView);
		}
	}
}