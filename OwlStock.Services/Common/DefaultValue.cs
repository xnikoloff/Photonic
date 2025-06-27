namespace OwlStock.Services.Common
{
    public static class DefaultValue
    {
        //Photoshoots
        internal const decimal PortrairPhotoShoot = 150m;
        internal const decimal PortrairPlusPhotoShoot = 200m;
        internal const decimal PortrairExtraPhotoShoot = 250m;
        internal const decimal FamilyPhotoShoot = 200m;
        internal const decimal FamilyPlusPhotoShoot = 250m;
        internal const decimal FamilyExtraPhotoShoot = 300m;
        internal const decimal BusinessPortrait = 150m;
        internal const decimal WeddingPhotoshoot = 400m;
        internal const decimal WeddingPlusPhotoshoot = 700m;
        internal const decimal WeddingExtraPhotoshoot = 900m;
        internal const decimal PromPhotoshoot = 300m;
        internal const decimal PromPlusPhotoshoot = 500m;
        internal const decimal PromExtraPhotoshoot = 700m;
        internal const decimal Baptism = 300m;
        internal const decimal BaptismPlus = 500m;
        internal const decimal BaptismExtra = 700;
        internal const decimal Automotive = 100m;
        internal const decimal Product = 50m;
        internal const decimal ProductPlus = 100m;

        //Fuel
        public const decimal FuelPriceByKilometer = 0.18m;
        public const decimal TripTax = 5m;

        //not used for now
        //Speed (in KM/h)
        //internal const int Speed = 60;
        
        //Current location
        internal const string DefaultSettlement = "Асеновград";
        internal const double DefaultSettlementLatitude = 42.010493;
        internal const double DefaultSettlementLongitude = 24.878557;

        //Serviced Regions GeoData
        public const double LatitudePlovdiv = 42.143543;
        public const double LongitudePlovdiv = 24.751459;
        public const double LatitudeHaskovo = 41.934594;
        public const double LongitudeHaskovo = 25.555545;
        public const double LatitudeStaraZagora = 42.425663;
        public const double LongitudeStaraZagora = 25.634676;
        public const double LatitudePazarzhik = 42.190478;
        public const double LongitudePazarzhik = 24.336608;

    }
}
