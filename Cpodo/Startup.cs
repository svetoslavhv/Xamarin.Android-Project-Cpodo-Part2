using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Calligraphy;

namespace Cpodo
{
	[Application]
	public class Startup : Application
	{
		public Startup(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer) { }

		public override void OnCreate()
		{
			base.OnCreate();

			//Set Exo2_Bold.otf fontFamily for the entire application
			CalligraphyConfig.InitDefault(
				new CalligraphyConfig.Builder()
					.SetDefaultFontPath("fonts/Exo2_Bold.otf")
					.SetFontAttrId(Resource.Attribute.fontPath)
					.Build()
			);
		}
	}
}