using System;
using Android.App;
using Android.Runtime;

namespace Victoire
{
    [Application]
    class App : Application
    {
        public static DrinkObject OnTapObj { set; get; }
        public static DrinkObject BeerObj { set; get; }
        public static EventObject EventsObj { set; get; }

        public App(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {
            // Constructor
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }
    }
}