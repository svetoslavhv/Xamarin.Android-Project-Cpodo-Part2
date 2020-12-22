using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Cpodo.Fragments
{
	public class MultipurposeRoomFragment : Android.Support.V4.App.Fragment
	{
		public MultipurposeRoomFragment()
		{
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.MultipurposeRoomFragment, container, false);
			return view;
		}
	}
}