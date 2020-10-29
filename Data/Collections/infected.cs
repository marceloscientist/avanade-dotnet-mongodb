using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Data.Collections
{
    public class Infected
    {
        public Infected(DateTime birthdate, string gender, double latitude, double longitude) 
        {
            this.Birthdate = birthdate;
            this.Gender = gender;
            this.Location = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public GeoJson2DGeographicCoordinates Location { get; set; }
    }
}