﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.ViewModels
{
    public class ProductParameters
    {
		const int maxPageSize = 50;
		public int PageNumber { get; set; } = 1;
		public string SearchString { get; set; } = null;
		

		private int _pageSize = 10;
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}
	}
}
