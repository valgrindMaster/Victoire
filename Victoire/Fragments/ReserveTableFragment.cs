using Android.App;
using Android.OS;
using Android.Views;

namespace Victoire.Fragments
{
    public class ReserveTableFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static ReserveTableFragment NewInstance()
        {
            return new ReserveTableFragment { Arguments = new Bundle() };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.ReserveTableFragment, null);
        }
    }
}