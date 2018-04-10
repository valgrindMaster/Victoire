using Android.App;
using Android.OS;
using Android.Support.Design.Widget;

namespace Victoire
{
    [Activity(Theme = "@style/MyTheme", Label = "Victoire")]
    public class MainActivity : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            BottomNavBarSetup(Resource.Id.action_food);
        }

        private void NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            BottomNavBarSetup(e.Item.ItemId);
        }
    }
}

