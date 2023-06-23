namespace LibraNET.Common
{
    public static class ValidationConstants
    {
        public static class Book
        {
            public const int TitleMaxLenght = 120;
            public const int TitleMinLenght = 1;

            public const int ISBNLength = 13;

            public const int DescriptionMaxLength = 2100;
            public const int DescriptionMinLength = 600;

            public const int PageCountMax = 4300;
            public const int PageCountMin = 1;

            public const int LanguageMaxLength = 20;
            public const int LanguageMinLength = 3;
        }
    }
}
