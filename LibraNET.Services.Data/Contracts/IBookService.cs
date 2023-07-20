﻿using LibraNET.Services.Data.Models;
using LibraNET.Web.ViewModels;

namespace LibraNET.Services.Data.Contracts
{
    public interface IBookService
	{
		Task<ICollection<HomeBookViewModel>> LastThreeBooksAsync();
		Task<CurrentBooksServiceModel> AllAsync(AllBooksViewModel model);
		Task<decimal> MinPrice();
		Task<decimal> MaxPrice();
	}
}
