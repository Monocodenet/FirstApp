/// <summary>
/// This code is only for safe of demostration. Do not use in a real production environment.
/// </summary>
using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace XmlReadApp
{
	public class BookListAdapter : BaseAdapter<Book>
	{
		Activity context;
		public List<Book> Books;

		public BookListAdapter(Activity context, List<Book> books)
			: base()
		{
			this.context = context;
			this.Books = books;
		}

		public override int Count
		{
			get { return this.Books.Count; }
		}

		public override Book this[int position]
		{
			get { return this.Books[position]; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			//Get our object for this position
			var item = this.Books[position];

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			var view = convertView;

			if (convertView == null || !(convertView is LinearLayout))
			{
				view = context.LayoutInflater.Inflate(Resource.Layout.BookItem, parent, false);
			}

			//Find references to each subview in the list item's view
			var textTop = view.FindViewById(Resource.Id.Title) as TextView;
			var textBottom = view.FindViewById(Resource.Id.Category) as TextView;

			//Assign this item's values to the various subviews
			textTop.SetText(item.Title, TextView.BufferType.Normal);
			textBottom.SetText(item.Category, TextView.BufferType.Normal);

			//Finally return the view
			return view;
		}

		public override long GetItemId(int position)
		{
			return position;
		}
	}
}
