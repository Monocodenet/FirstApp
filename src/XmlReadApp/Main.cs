/// <summary>
/// This code is only for safe of demostration. Do not use in a real production environment.
/// </summary>
namespace XmlReadApp
{
	using System;
	using Android.App;
 	using Android.Widget;
 	using Android.OS;
	
    [Activity(Label = "Main", MainLauncher = true)]
    public class Main : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main);
            
            // Get our button from the layout resource,
            // and attach an event to it
            Button btnSimpleData = FindViewById<Button>(Resource.Id.ListSimple);
			btnSimpleData.Click += (sender, e) => 
			{
				StartActivity (typeof (SimpleList));
			};
			Button btnCustomData = FindViewById<Button>(Resource.Id.ListCustom);
			btnCustomData.Click += (sender, e) => 
			{
				StartActivity (typeof(CustomList));
			};
        }
    }
}

