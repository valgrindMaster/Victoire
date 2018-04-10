using System;
using System.Collections.Generic;

public class Location
{
    public string Zip { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Street { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class PlaceJson
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Location Location { get; set; }
}

public class EventItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PlaceJson Place_json { get; set; }
    public DateTime Start_time { get; set; }
    public DateTime? End_time { get; set; }
    public int Location_id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string Location_name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Street { get; set; }
    public string Country { get; set; }
    public string Zip { get; set; }
    public object Latitude { get; set; }
    public object Longitude { get; set; }
    public bool From_facebook { get; set; }
    public object Link { get; set; }
}

public class EventObject
{
    public List<EventItem> Events { get; set; }
}