using System;
using System.Collections.Generic;

public class DrinkItem
{
    public int Id { get; set; }
    public int Section_id { get; set; }
    public int Position { get; set; }
    public int Untappd_id { get; set; }
    public string Label_image { get; set; }
    public string Brewery_location { get; set; }
    public bool Cask { get; set; }
    public bool Nitro { get; set; }
    public object Tap_number { get; set; }
    public string Rating { get; set; }
    public bool In_production { get; set; }
    public string Untappd_beer_slug { get; set; }
    public int Untappd_brewery_id { get; set; }
    public string Name { get; set; }
    public string Original_name { get; set; }
    public object Custom_name { get; set; }
    public string Description { get; set; }
    public object Custom_description { get; set; }
    public string Original_description { get; set; }
    public string Style { get; set; }
    public object Custom_style { get; set; }
    public string Original_style { get; set; }
    public string Brewery { get; set; }
    public object Custom_brewery { get; set; }
    public string Original_brewery { get; set; }
    public string Calories { get; set; }
    public string Custom_calories { get; set; }
    public string Original_calories { get; set; }
    public string Abv { get; set; }
    public string Custom_abv { get; set; }
    public string Original_abv { get; set; }
    public string Ibu { get; set; }
    public string Custom_ibu { get; set; }
    public string Original_ibu { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}

public class DrinkObject
{
    public List<DrinkItem> Items { get; set; }
}