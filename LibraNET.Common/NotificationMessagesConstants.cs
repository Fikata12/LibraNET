namespace LibraNET.Common
{
    public static class NotificationMessagesConstants
    {
        public const string GeneralErrorMessage = "Unexpected error occurred! Try again later or contact support.";

        public const string SuccessfulBookCreation = "Book was added successfully!";
        public const string UnsuccessfulBookCreation = "Unexpected error occurred while trying to add new book!";
        public const string SuccessfulBookEdit = "Book was edited successfully!";
        public const string UnsuccessfulBookEdit = "Unexpected error occurred while trying to edit a book!";

        public const string SuccessfulAuthorCreation = "Author was added successfully!";
		public const string UnsuccessfulAuthorCreation = "Unexpected error occurred while trying to add new author!";
        public const string SuccessfulAuthorEdit = "Author was edited successfully!";
        public const string UnsuccessfulAuthorEdit = "Unexpected error occurred while trying to edit an author!";

		public const string SuccessfulCategoryCreation = "Category was added successfully!";
		public const string UnsuccessfulCategoryCreation = "Unexpected error occurred while trying to add new category!";
        public const string SuccessfulCategoryEdit = "Category was edited successfully!";
        public const string UnsuccessfulCategoryEdit = "Unexpected error occurred while trying to edit a category!";

        public const string UserNotFound = "User not found!";
        public const string TheUserIsAdmin = "The user you are trying to make Admin is already Admin!";
		public const string UnsuccessfulUserAdminify = "Failed to make the user an Admin.";
		public const string SuccessfulUserAdminify = "Successfully adminified user!";
	}
}
