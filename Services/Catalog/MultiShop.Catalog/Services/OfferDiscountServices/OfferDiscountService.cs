using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.OfferDiscountDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;
        private readonly IMapper _mapper;

        public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var mongoClient = new MongoClient(_databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            _offerDiscountCollection = mongoDatabase.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO)
        {
            var value = _mapper.Map<OfferDiscount>(createOfferDiscountDTO);
            await _offerDiscountCollection.InsertOneAsync(value);

        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountID == id);
        }

        public async Task<List<ResultOfferDiscountDTO>> GetAllOfferDiscountAsync()
        {
            var values = await _offerDiscountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDTO>>(values);
        }

        public async Task<GetByIDOfferDiscountDTO> GetByIDOfferDiscountAsync(string id)
        {
            var values = await _offerDiscountCollection.Find<OfferDiscount>(x => x.OfferDiscountID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDOfferDiscountDTO>(values);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO)
        {
            var values = _mapper.Map<OfferDiscount>(updateOfferDiscountDTO);
            await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountID == updateOfferDiscountDTO.OfferDiscountID, values);
        }
    }
}
