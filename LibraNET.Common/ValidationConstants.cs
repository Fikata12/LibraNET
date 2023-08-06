namespace LibraNET.Common
{
    public static class ValidationConstants
    {
        public static class Book
        {
            public const int TitleMaxLength = 120;
            public const int TitleMinLength = 1;

            public const int ISBNLength = 13;

            public const int DescriptionMaxLength = 2100;
            public const int DescriptionMinLength = 30;

            public const int PageCountMax = 4300;
            public const int PageCountMin = 1;

            public const int LanguageMaxLength = 20;
            public const int LanguageMinLength = 3;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "20000";

            public const int CountMinValue = 0;
            public const int CountMaxValue = int.MaxValue;

			public const int PublisherNameMaxLength = 50;
			public const int PublisherNameMinLength = 3;
		} 

        public static class Author
        {
            public const int NameMaxLength = 90;
            public const int NameMinLength = 3;

            public const int DescriptionMaxLength = 2100;
            public const int DescriptionMinLength = 30;
        }

        public static class Category
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 3;
        }

        public static class Comment
        {
            public const int CommentMaxLength = 300;
            public const int CommentMinLength = 1;
        }

		public static class Rating
		{
			public const int RatingMinValue = 1;
			public const int RatingMaxValue = 5;
		}

		public static class Order
		{
			public const int RecipientNameMaxLength = 60;
			public const int RecipientNameMinLength = 6;

            public const int PhoneNumberMaxLength = 13;
            public const int PhoneNumberMinLength = 10;

            public const int AddressMaxLength = 150;
		}

		public static class Address
		{
			public const int TownNameMaxLength = 30;
			public const int TownNameMinLength = 3;

            public const int PostCodeLength = 4;

			public const int AddressMaxLength = 50;
			public const int AddressMinLength = 5;
		}

        public static class ApplicationUser
        {
            public const int FirstNameMaxLength = 30;
            public const int FirstNameMinLength = 1;

			public const int LastNameMaxLength = 30;
			public const int LastNameMinLength = 1;

            public const int PhoneNumberMaxLength = 13;
            public const int PhoneNumberMinLength = 10;
        }
	}
}
