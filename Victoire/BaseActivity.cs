using Android.App;
using Android.Support.Design.Widget;
using Victoire.Fragments;

namespace Victoire
{
    public class BaseActivity : Activity
    {
        protected void BottomNavBarSetup(int id)
        {
            Fragment fragment = null;

            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            bottomNavigation.NavigationItemSelected += (s, e) =>
            {
                switch (e.Item.ItemId)
                {
                    case Resource.Id.action_food:
                        fragment = FoodFragment.NewInstance();
                        break;

                    case Resource.Id.action_drinks:
                        fragment = DrinksFragment.NewInstance();
                        break;

                    case Resource.Id.action_reserve:
                        fragment = ReserveTableFragment.NewInstance();
                        break;

                    case Resource.Id.action_events:
                        fragment = EventsFragment.NewInstance();
                        break;

                    case Resource.Id.action_about:
                        fragment = AboutFragment.NewInstance();
                        break;
                }

                if (fragment == null) return;

                FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
            };
        }
    }
}