using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Cpodo.Models;
using Cpodo.ViewHolders;

namespace Cpodo.Adapters
{
	public class SpeakersAdapter : RecyclerView.Adapter
	{
		public event EventHandler<string> ItemClick;
		public List<Speaker> listOfSpeakers;

		public SpeakersAdapter(List<Speaker> speakers)
		{
			listOfSpeakers = speakers;
		}

		public override int ItemCount
		{
			get { return listOfSpeakers.Count; }
		}

		void OnClick(int position)
		{
			if (ItemClick != null)
				ItemClick(this, listOfSpeakers[position].Resume);
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			SpeakerViewHolder vh = holder as SpeakerViewHolder;

			var imageBitmap = GetImageBitmapFromUrl(listOfSpeakers[position].Photo);
			vh.speakerPhotoImageView.SetImageBitmap(imageBitmap);
			
			vh.speakerNameTextView.Text = listOfSpeakers[position].Name;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemView = LayoutInflater.From(parent.Context).
						Inflate(Resource.Layout.SpeakerCardView, parent, false);

			SpeakerViewHolder vh = new SpeakerViewHolder(itemView, OnClick);
			return vh;
		}

		private Bitmap GetImageBitmapFromUrl(string url)
		{
			Bitmap imageBitmap = null;

			using (var webClient = new WebClient())
			{
				var imageBytes = webClient.DownloadData(url);
				if (imageBytes != null && imageBytes.Length > 0)
				{
					imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
				}
			}

			return imageBitmap;
		}
	}
}