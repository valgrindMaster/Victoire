using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Victoire
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        private const string ON_TAP = "on tap";
        private const string LOCATION_ID = "4384";
        private const string API_TOKEN = "jp9W3DTf4MdsxuRmc2zn";
        private const string UNAME = "brian.victoire.rochester@gmail.com";

        private string on_tap_menu_id;
        private string on_tap_section_id;

        private string beer_menu_id;
        private string beer_section_id;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetupIds();
            GetDrinks();
            GetEvents();
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task.Run(() =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            });
        }

        private void SetupIds()
        {
            SetMenuIds();
            SetSectionIds();
        }

        private void SetMenuIds()
        {
            string endpoint = "https://business.untappd.com/api/v1/locations/{0}/menus";
            string[] parameters = new string[1];
            parameters[0] = LOCATION_ID;

            string content = MakeCallout(endpoint, parameters);

            try
            {
                dynamic jsonResponse = JObject.Parse(content);

                string temp_name1 = jsonResponse.menus[0].name;
                string temp_id1 = jsonResponse.menus[0].id;
                string temp_name2 = jsonResponse.menus[1].name;
                string temp_id2 = jsonResponse.menus[1].id;

                if (string.Equals(temp_name1, ON_TAP, StringComparison.OrdinalIgnoreCase))
                {
                    on_tap_menu_id = temp_id1;
                    beer_menu_id = temp_id2;
                }
                else
                {
                    beer_menu_id = temp_id1;
                    on_tap_menu_id = temp_id2;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred (MENU): " + ex.Message);
            }
        }

        private void SetSectionIds()
        {
            string endpoint = "https://business.untappd.com/api/v1/menus/{0}/sections";

            string[] parameters1 = new string[1];
            string[] parameters2 = new string[1];
            parameters1[0] = on_tap_menu_id;
            parameters2[0] = beer_menu_id;

            string on_tap_content = MakeCallout(endpoint, parameters1);
            string beer_content = MakeCallout(endpoint, parameters2);

            try
            {
                dynamic on_tap_jsonResponse = JObject.Parse(on_tap_content);
                dynamic beer_jsonResponse = JObject.Parse(beer_content);

                on_tap_section_id = on_tap_jsonResponse.sections[0].id;
                beer_section_id = beer_jsonResponse.sections[0].id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred (SECTION): " + ex.Message);
            }
        }

        private void GetDrinks()
        {
            string endpoint = "https://business.untappd.com/api/v1/sections/{0}/items";

            string[] parameters1 = new string[1];
            string[] parameters2 = new string[1];
            parameters1[0] = on_tap_section_id;
            parameters2[0] = beer_section_id;

            string on_tap_json = MakeCallout(endpoint, parameters1);
            string beer_json = MakeCallout(endpoint, parameters2);
            Console.WriteLine("ABC:::");
            Console.WriteLine(on_tap_json);
            Console.WriteLine(beer_json);
            try
            {
                DrinkObject on_tap_items = JsonConvert.DeserializeObject<DrinkObject>(on_tap_json);
                DrinkObject beer_items = JsonConvert.DeserializeObject<DrinkObject>(beer_json);

                Console.WriteLine("LETS SEE...");
                Console.WriteLine(on_tap_items.Items == null);
                Console.WriteLine(beer_items.Items == null);

                App.OnTapObj = on_tap_items;
                App.BeerObj = beer_items;

                Console.WriteLine(on_tap_items.Items);
                Console.WriteLine(beer_items.Items);
            }
            catch (Exception ex)
            {
                App.OnTapObj = null;
                App.BeerObj = null;
                Console.WriteLine("ERROR! " + ex.Message);
            }
        }

        private void GetEvents()
        {
            string endpoint = "https://business.untappd.com/api/v1/locations/{0}/events";

            string[] parameters = new string[1];
            parameters[0] = LOCATION_ID;

            string events_json = MakeCallout(endpoint, parameters);

            try
            {
                EventObject events = JsonConvert.DeserializeObject<EventObject>(events_json);
                App.EventsObj = events;
            }
            catch (Exception ex)
            {
                App.EventsObj = null;
                Console.WriteLine("ERROR! " + ex.Message);
            }
        }

        private string MakeCallout(string uri, string[] parameters)
        {
            var request = WebRequest.Create(string.Format(uri, parameters));
            request.ContentType = "application/json";
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(UNAME + ":" + API_TOKEN));
            request.Headers.Add("Authorization", "Basic " + svcCredentials);
            request.Method = "GET";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {

                if (response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Console.Out.WriteLine("Response contained empty body...");
                    }
                    else
                    {
                        return content;
                    }
                }

                return "";
            }
        }
    }
}
