﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }
    }
}
