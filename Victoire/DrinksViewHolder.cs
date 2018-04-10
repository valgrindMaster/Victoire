using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Victoire
{
    public class DrinksViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public TextView Type { get; private set; }
        public TextView Made { get; private set; }
        public ImageView Drink { get; private set; }

        public DrinksViewHolder(View itemView) : base(itemView)
        {
            // Locate and cache view references:
            Name = itemView.FindViewById<TextView>(Resource.Id.drink_name_text_view);
            Type = itemView.FindViewById<TextView>(Resource.Id.drink_type_text_view);
            Made = itemView.FindViewById<TextView>(Resource.Id.drink_made_text_view);
            Drink = itemView.FindViewById<ImageView>(Resource.Id.drink_imageview);
        }
    }
}