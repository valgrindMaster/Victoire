using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Java.Net;
using System;

namespace Victoire
{
    class DrinksAdapter : RecyclerView.Adapter
    {
        private DrinkObject items;

        public DrinksAdapter(DrinkObject items)
        {
            this.items = items;
        }

        public override int ItemCount
        {
            get { return items.Items.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DrinksViewHolder vh = holder as DrinksViewHolder;

            vh.Name.Text = items.Items[position].Name;
            vh.Type.Text = items.Items[position].Style;
            vh.Made.Text = items.Items[position].Brewery_location;

            //URL url = new URL(items.Items[position].Label_Image);
            //var bitmap = BitmapFactory.DecodeStream(url.OpenConnection().InputStream);

            //vh.Drink.SetImageBitmap(bitmap);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.DrinksRecyclerView, parent, false);

            // Create a ViewHolder to hold view references inside the DrinksRecyclerView:
            return new DrinksViewHolder(itemView);
        }
    }
}