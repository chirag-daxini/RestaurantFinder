namespace RestaurantFinder.Models
{
    public class AppConstants
    {
        public class ApplicationUrls
        {
            public const string BYPOSTCODE = "restaurants/bypostcode/{0}";
        }

        public class ValidationConstant
        {
            public const string POST_CODE_REGEX = "^([A-Za-z][A-Ha-hJ-Yj-y]?[0-9][A-Za-z0-9]? ?[0-9][A-Za-z]{2}|[Gg][Ii][Rr] ?0[Aa]{2})$";
        }
    }
}
