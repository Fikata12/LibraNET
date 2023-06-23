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
            public const int DescriptionMinLength = 30;

            public const int PageCountMax = 4300;
            public const int PageCountMin = 1;

            public const int LanguageMaxLength = 20;
            public const int LanguageMinLength = 3;
        }

        public static class Author
        {
            public const int FirstNameMaxLenght = 50;
            public const int FirstNameMinLenght = 2;

            public const int MiddleNameMaxLenght = 50;
            public const int MiddleNameMinLenght = 2;

            public const int LastNameMaxLenght = 50;
            public const int LastNameMinLenght = 2;

            public const int DescriptionMaxLength = 2100;
            public const int DescriptionMinLength = 30;
        }

        public static class Category
        {
            public const int NameMaxLenght = 30;
            public const int NameMinLenght = 3;
        }

        public static class Comment
        {
            public const int TextMaxLenght = 300;
            public const int TextMinLenght = 1;
        }

        public static class Publisher
        {
            public const int NameMaxLenght = 50;
            public const int NameMinLenght = 3;
        }
    }
}
