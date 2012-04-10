/// <summary>
/// This code is only for safe of demostration. Do not use in a real production environment.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

using Android.App;
using Android.OS;
using Android.Widget;

namespace XmlReadApp
{
	[Activity (Label = "Custom", LaunchMode=Android.Content.PM.LaunchMode.SingleTask)]			
	class CustomList:ListActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			this.ListAdapter = new BookListAdapter(this,LoadData());
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

