﻿using System;
using MauiAppNFC.ViewModels;

namespace MauiAppNFC.Views
{
	public class BaseContentPage: ContentPage
	{
		public BaseContentPage(BaseViewModel baseViewModel)
		{
			BindingContext = baseViewModel;
		}
	}
}

