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
	[Table("schedules")]
	public class Schedule
	{
		[PrimaryKey]
		[Column("id")]
		public int Id { get; set; }

		[Column("day")]
		public string Day { get; set; }

		[Column("hour")]
		public string Hour { get; set; }

		[Column("short_description")]
		public string ShortDescription { get; set; }

		[Column("long_description")]
		public string LongDescription { get; set; }

	}
}