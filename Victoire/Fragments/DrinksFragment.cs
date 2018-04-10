using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;

namespace Victoire.Fragments
{
    public class DrinksFragment : Fragment
    {
        private RecyclerView view;
        private LinearLayoutManager manager;
        private DrinksAdapter adapter;

        private DrinkObject onTapItems;
        private DrinkObject beerItems;

        private View myFragmentView;

        private void SetupRecyclerView(DrinkObject items)
        {
            adapter = new DrinksAdapter(items);
            view = (RecyclerView)myFragmentView.FindViewById(Resource.Id.drinks_recycler_view);
            manager = new LinearLayoutManager(this.Activity);
            view.SetAdapter(adapter);
            view.SetLayoutManager(manager);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            onTapItems = App.OnTapObj;
            beerItems = App.BeerObj;
        }

        public static DrinksFragment NewInstance()
        {
            return new DrinksFragment { Arguments = new Bundle() };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            myFragmentView = inflater.Inflate(Resource.Layout.DrinksFragment, null);

            SetupRecyclerView(onTapItems);

            Button btn_on_tap = myFragmentView.FindViewById<Button>(Resource.Id.button_on_tap);
            Button btn_beer = myFragmentView.FindViewById<Button>(Resource.Id.button_beer);

            btn_on_tap.Click += delegate
            {
                SetupRecyclerView(beerItems);
            };

            btn_beer.Click += delegate
            {
                SetupRecyclerView(onTapItems);
            };

            return myFragmentView;
        }
    }
}