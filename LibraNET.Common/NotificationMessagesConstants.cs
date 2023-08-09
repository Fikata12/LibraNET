namespace LibraNET.Common
{
    public static class NotificationMessagesConstants
    {
        public const string GeneralErrorMessage = "Unexpected error occurred! Try again later or contact support.";

        public const string SuccessfulBookCreation = "Book was added successfully!";
        public const string UnsuccessfulBookCreation = "Unexpected error occurred while trying to add new book!";
        public const string SuccessfulBookEdit = "Book was edited successfully!";
        public const string UnsuccessfulBookEdit = "Unexpected error occurred while trying to edit a book!";
		public const string SuccessfulBookDeletion = "Successfully deleted book!";
		public const string UnsuccessfulBookDeletion = "Unexpected error occurred while trying to delete a book!";

		public const string SuccessfulAuthorCreation = "Author was added successfully!";
		public const string UnsuccessfulAuthorCreation = "Unexpected error occurred while trying to add new author!";
        public const string SuccessfulAuthorEdit = "Author was edited successfully!";
        public const string UnsuccessfulAuthorEdit = "Unexpected error occurred while trying to edit an author!";
		public const string SuccessfulAuthorDeletion = "Successfully deleted author!";
		public const string UnsuccessfulAuthorDeletion = "Unexpected error occurred while trying to delete an author!";

		public const string SuccessfulCategoryCreation = "Category was added successfully!";
		public const string UnsuccessfulCategoryCreation = "Unexpected error occurred while trying to add new category!";
        public const string SuccessfulCategoryEdit = "Category was edited successfully!";
        public const string UnsuccessfulCategoryEdit = "Unexpected error occurred while trying to edit a category!";
		public const string SuccessfulCategoryDeletion = "Successfully deleted category!";
		public const string UnsuccessfulCategoryDeletion = "Unexpected error occurred while trying to delete a category!";

		public const string UserNotFound = "User not found!";
        public const string TheUserIsAdmin = "The user you are trying to make Admin is already Admin!";
		public const string UnsuccessfulUserAdminify = "Failed to make the user an Admin.";
		public const string SuccessfulUserAdminify = "Successfully adminified user!";

		public const string InvalidRating = "The rating must be between 1 and 5 stars!";
		public const string UnsuccessfulBookRate = "Unexpected error occurred while trying to rate a book!";

		public const string InvalidComment = "The field comment must be between 1 and 300 characters long!";
		public const string UnsuccessfulBookComment = "Unexpected error occurred while trying to comment a book!";

		public const string InvalidQuantity = "Invalid quantity!";
		public const string UnsuccessfulAddToCart = "Unexpected error occurred while trying to add a book to your cart!";
		public const string SuccessfulAddToCart = "Successfully added book to your cart!";
		public const string UnsuccessfulRemoveFromCart = "Unexpected error occurred while trying to remove a book from your cart!";

		public const string SuccessfulAddToFavorite = "Successfully added book to your favorite books!";
		public const string UnsuccessfulAddToFavorite = "Unexpected error occurred while trying to add a book to your favorite books!";

		public const string SuccessfullyPlacedOrder = "Thank You for Your Order! Your order has been successfully placed. We appreciate your business!";
	}
}
