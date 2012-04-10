/// <summary>
/// This code is only for safe of demostration. Do not use in a real production environment.
/// </summary>
namespace XmlReadApp
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Xml.Serialization;
	using System.IO;
	using System.Reflection;
	
	using Android.App;
	using Android.OS;
	using Android.Widget;
	
	[Activity (Label = "Simple", LaunchMode=Android.Content.PM.LaunchMode.SingleTask)]			
	public class SimpleList : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            SetContentView(Resource.Layout.Simple);
			ShowView();
		}
		
		private void ShowView()
		{
			ListView view = FindViewById<ListView>(Resource.Id.SimpleResultView);
			view.TextFilterEnabled = true;
			try 
			{
				string[] books = LoadData().Select(x=> x.Title).ToArray();
				view.Adapter = new ArrayAdapter<string>(this, Resource.Layout.ItemView, books);
			} 
			catch (Exception ex)
			{
				view.Adapter = new ArrayAdapter<string> (this, Resource.Layout.ItemView, new []{ ex.Message});
                Android.Util.Log.Error("Failure", "Error: " + ex.Message);
			}
		}
		
		private List<Book> LoadData()
		{
			var s = Resources.OpenRawResource(Resource.Raw.Books);
			List<Book> bks;
            using (TextReader reader = new StreamReader(s))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                bks = (List<Book>)serializer.Deserialize(reader);
            }
            Console.WriteLine("[RestGuideApplication] Loaded {0} restaurants", bks.Count);
			return bks;
		}
	}
}

//  this.RunOnUiThread(() => tv.Text = "Error: " + ex.Message);	

     