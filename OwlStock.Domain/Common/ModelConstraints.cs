namespace OwlStock.Domain.Common
{
    public static class ModelConstraints
    {
        //Photo
        public const int PictureNameMaxLength = 500;
        public const int PictureDescriptionMaxLength = 2000;
        public const int PictureGeoLocationMaxLength = 100;
        public const int PictureGearMaxLength = 1000;
        public const string PhotoFormFileDisplayName = "File";

        //PhotoShoot
        public const int PersonNameMaxLength = 50;
        public const int PersonEmailMaxLength = 200;
        public const int PersonPhoneMaxLenth = 30;
        public const int PhotoShootTypeDescriptionMaxLength = 500;
        public const int GoogleMapsLinkDescriptionMxLength = 300;
        public const int PhotoDeliveryAddressMxLength = 150;
        public const int UserPlace = 50;
        public const int UICMinLength = 9;
        public const int UICMaxLength = 13;


        //Common
        public const string TagsRequiredErrorMessage = "Tags are required";
        public const string CategoriesRequiredErrorMessage = "Categories are required";
        public const string FormFilesRequiredErrorMessage = "Upload a file";

        //City
        internal const int SettlementNameMaxLength = 100;
        internal const int PostCodeMaxLength = 10;  
        internal const int LatLongMaxLength = 25;

        //Testimony
        public const int TestimonyNameMinLength = 2;
        public const int TestimonyNameMaxLength = 30;
        public const int TestimonyJobMinLength = 5;
        public const int TestimonyJobMaxLength = 200;
        public const int TestimonyStarsMinCount = 1;
        public const int TestimonyStarsMaxCount = 5;
        public const int TestimonyContentMinLength = 5;
        public const int TestimonyContentMaxLength = 5000;

        public const string TestimonyFirstNameMinLengthErrorMessage = "Въведете поне 2 символа за име";
        public const string TestimonyFirstNameMaxLengthErrorMessage = "Въведете най-много 30 символа за име";
        public const string TestimonyLastNameNameMinLengthErrorMessage = "Въведете поне 2символа за фамилия";
        public const string TestimonyLastNameNameMaxLengthErrorMessage = "Въведете най-много 30 символа за фамилия";
        public const string TestimonyDescriptionMinLengthErrorMessage = "Въведете поне 5 символа за Вашето мнение";
        public const string TestimonyDescriptionMaxLengthErrorMessage = "Въведете най-много 5000 символа за Вашето мнение";
        public const string TestimonyDescriptionStarsErrorMessage = "Оценете ни с от 1 до 5 звезди";
    }
}
