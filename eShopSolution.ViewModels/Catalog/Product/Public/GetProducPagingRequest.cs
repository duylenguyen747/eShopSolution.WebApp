﻿using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.Catalog.Product.Public
{
	public class GetProducPagingRequest : PagingRequestBase
	{
		public int? CategoryId { get; set; }

	}
}
