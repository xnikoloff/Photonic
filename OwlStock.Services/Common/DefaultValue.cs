namespace OwlStock.Services.Common
{
    public static class DefaultValue
    {
        /* PRICE PACKET DESCRIPTIONS */
        public const string IndividualPhotoshootDescription = "Включва обработените сполучливи кадри";
        public const string IndividualPlusPhotoshootDescription = "Пакет Стандартен + лукосозна фотокнига";
        public const string IndividualExtraPhotoshootDescription = "Пакет Плюс + 3 кадръра в рамка";
        public const string WeddingPhotoshootDescription = "Включва индивидуална фотосесия на младоженците със сватбена тематика + снимки със семейството и гостите";
        public const string WeddingPlusPhotoshootDescription = "Пакет Стандартен + снимки от подготовката";
        public const string WeddingExtraPhotoshootDescription = "Пакет Плюс + луксозна сватбена фотокнига";
        public const string PromPhotoshootDescription = "Включва индивидуална фотосесия на абитуриента/абитуриентката + снимки със семейството и гостите";
        public const string PromPlusPhotoshootDescription = "Пакет Стандартен + снимки от подготовката";
        public const string PromExtraPhotoshootDescription = "Пакет Плюс + луксозна фотокнига";
        public const string BaptismPhotoshootDescription = "Включва отразяване на цялото събитие + снимки с гостите";
        public const string BaptismPlusPhotoshootDescription = "Пакет Стандартен + индивидуална фотосесия на родителите и бебето";
        public const string BaptismExtraPhotoshootDescription = "Пакет Плюс + луксозна фотокнига";
        public const string AutomotivePhotoshootDescription = "Включва стандартни снимки на автомобила (например за каталози на автокъщи или обяви от частни лица)";
        public const string AutomotivePlusPhotoshootDescription = "Включва кадри на автомобила, заснети на специфична локация и с артистична обработка";
        public const string AutomotiveExtraPhotoshootDescription = "Включва всичко от пакет Артистичен плюс Rolling Shost (кадри в движение)";
        public const string ProductPhotoshootDescription = "Кадри на бял фон (например за електронни магазини)";
        public const string ProductPlusPhotoshootDescription = "Кадри с артистични елементи (например за реклами, блогове и др.)";
        public const string BusinessPortraitPhotoshootDescription = "Включва всички сполучливи кадри от фотосесията";
        public const string AutomotiveDescription = "Включва всички сполучливи кадри от фотосесията";
        public const string NegotiablePhotoshootDescription = "Ще изчислим цената спрямо вашите нужди";
        
        /* PRICE PACKETS */

        //Photoshoots
        public const decimal PortrairPhotoShoot = 150m;
        public const decimal PortrairPlusPhotoShoot = 300m;
        public const decimal PortrairExtraPhotoShoot = 350m;
        public const decimal FamilyPhotoShoot = 200m;
        public const decimal FamilyPlusPhotoShoot = 350m;
        public const decimal FamilyExtraPhotoShoot = 400m;
        public const decimal BusinessPortrait = 150m;
        public const decimal WeddingPhotoshoot = 300m;
        public const decimal WeddingPlusPhotoshoot = 400m;
        public const decimal WeddingExtraPhotoshoot = 600m;
        public const decimal PromPhotoshoot = 200m;
        public const decimal PromPlusPhotoshoot = 300m;
        public const decimal PromExtraPhotoshoot = 450m;
        public const decimal Baptism = 150m;
        public const decimal BaptismPlus = 200m;
        public const decimal BaptismExtra = 350m;
        public const decimal Automotive = 30m;
        public const decimal AutomotivePlus = 100m;
        public const decimal AutomotiveExtra = 180m;
        public const decimal Product = 50m;
        public const decimal ProductPlus = 100m;
        public const decimal SecretPhotoshoot = 200m;
        public const string NegotiablePriceText = "По договаряне";

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
