﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CatalogDTOs.FeatureSliderDTOs
{
    public class UpdateFeatureSliderDTO
    {
        public string FeatureSliderID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public bool Status { get; set; }
    }
}
