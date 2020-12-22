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

namespace Cpodo.CustomControls
{
	public class ScaleImageViewGestureDetector : GestureDetector.SimpleOnGestureListener
	{
		private readonly ScaleImageView m_ScaleImageView;
		public ScaleImageViewGestureDetector(ScaleImageView imageView)
		{
			m_ScaleImageView = imageView;
		}
		public override bool OnDown(MotionEvent e)
		{
			return true;
		}
		public override bool OnDoubleTap(MotionEvent e)
		{
			m_ScaleImageView.MaxZoomTo((int)e.GetX(), (int)e.GetY());
			m_ScaleImageView.Cutting();
			return true;
		}
	}
}