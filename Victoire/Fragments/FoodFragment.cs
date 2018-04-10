using Android.App;
using Android.OS;
using Android.Views;

namespace Victoire.Fragments
{
    public class FoodFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static FoodFragment NewInstance()
        {
            return new FoodFragment { Arguments = new Bundle() };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.FoodFragment, null);
        }
    }
}