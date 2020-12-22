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
using Android.Webkit;
using Android.Widget;

namespace Cpodo.Activities
{
	[Activity(Label = "SpeakerDetailsActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class SpeakerDetailsActivity : BaseActivity
	{
		WebView speakerResumeWebView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.SpeakerDetailsActivity);
			
			Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};

			string speakerResumeUrl = Intent.GetStringExtra("speakerResumeUrl");

			//open the pased URL from SpeakersActivity in this activity
			speakerResumeWebView = FindViewById<WebView>(Resource.Id.speakerResumeWebView);
			speakerResumeWebView.SetWebViewClient(new WebViewClient());
			speakerResumeWebView.LoadUrl(speakerResumeUrl);
			speakerResumeWebView.Settings.JavaScriptEnabled = true;
			speakerResumeWebView.Settings.BuiltInZoomControls = true;
			speakerResumeWebView.Settings.SetSupportZoom(true);
			speakerResumeWebView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
			speakerResumeWebView.ScrollbarFadingEnabled = false;

		}
		
		public override void OnBackPressed()
		{
			Finish();
		}
	}
}