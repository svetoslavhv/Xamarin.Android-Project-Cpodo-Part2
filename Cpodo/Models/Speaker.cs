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
using SQLite;

namespace Cpodo.Models
{
	[Table("speakers")]
	public class Speaker
	{
		[Column("photo")]
		public string Photo { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("resume")]
		public string Resume { get; set; }

		[Column("nationality")]
		public string Nationality { get; set; }
	}
}