using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _ProductImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var mongoClient = new MongoClient(_databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            _ProductImageCollection = mongoDatabase.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDTO);
            await _ProductImageCollection.InsertOneAsync(value);

        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<List<ResultProductImageDTO>> GetAllProductImageAsync()
        {
            var values = await _ProductImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDTO>>(values);
        }

        public async Task<GetByIDProductImageDTO> GetByIDProductImageAsync(string id)
        {
            var values = await _ProductImageCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDProductImageDTO>(values);
        }

        public async Task<List<GetByIDProductImageDTO>> GetByProductIDProductImageAsync(string id)
        {
            var values = await _ProductImageCollection.Find(x => x.ProductID ==id).ToListAsync();
            return _mapper.Map<List<GetByIDProductImageDTO>>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDTO);
            await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDTO.ProductImageID, values);
        }
    }
}
