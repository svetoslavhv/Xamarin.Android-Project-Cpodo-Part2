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

namespace Cpodo.HelperClasses
{
	/// <summary>
	/// A class which makes requests to a database
	/// </summary>
	public static class DatabaseHelper
	{
		/// <summary>
		/// The full path to the databases
		/// </summary>
		public static string databasesPath = Android.OS.Environment.ExternalStorageDirectory.ToString() + "/Android/data/Cpodo.Cpodo";

		/// <summary>
		/// Method which gets all the records from a database table
		/// </summary>
		/// <typeparam name="T">database model</typeparam>
		/// <param name="databaseName">database name</param>
		/// <returns>all the records from the table</returns>
		public static List<T> GetAllFromTable<T>(string databaseName) where T: new()
		{
			using (var connection = new SQLiteConnection(System.IO.Path.Combine(databasesPath, databaseName)))
			{
				try
				{
					var all = connection.Table<T>().ToList();
					return all;
				}
				catch (Exception ex)
				{
					return null;

				}
			}
		}
	}
}