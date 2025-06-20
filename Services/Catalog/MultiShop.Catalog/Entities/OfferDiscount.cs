﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class OfferDiscount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OfferDiscountID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageURL { get; set; }
        public string ButtonTitle { get; set; }
    }
}
