using Android.OS;
using Android.Views;
using Android.Gms.Maps;
using Android.App;
using Android.Gms.Maps.Model;

namespace Victoire.Fragments
{
    public class AboutFragment : Fragment, IOnMapReadyCallback
    {
        private GoogleMap _map;
        CameraUpdate cameraUpdate;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MapFragment _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }

            _mapFragment.GetMapAsync(this);
        }

        public static AboutFragment NewInstance()
        {
            return new AboutFragment { Arguments = new Bundle() };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.AboutFragment, null);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
            if (_map != null)
            {
                MarkerOptions victoire = new MarkerOptions();
                victoire.SetPosition(new LatLng(43.157026, -77.601180));
                victoire.SetTitle("Victoire Belgian Beer Bar & Bistro");
                _map.AddMarker(victoire);
            }
        }
    }
}