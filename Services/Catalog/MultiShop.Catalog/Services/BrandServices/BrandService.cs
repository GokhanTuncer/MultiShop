using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.BrandDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var mongoClient = new MongoClient(_databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            _brandCollection = mongoDatabase.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDTO createBrandDTO)
        {
            var value = _mapper.Map<Brand>(createBrandDTO);
            await _brandCollection.InsertOneAsync(value);

        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x => x.BrandID == id);
        }

        public async Task<List<ResultBrandDTO>> GetAllBrandAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDTO>>(values);
        }

        public async Task<GetByIDBrandDTO> GetByIDBrandAsync(string id)
        {
            var values = await _brandCollection.Find<Brand>(x => x.BrandID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDBrandDTO>(values);
        }

        public async Task UpdateBrandAsync(UpdateBrandDTO updateBrandDTO)
        {
            var values = _mapper.Map<Brand>(updateBrandDTO);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandID == updateBrandDTO.BrandID, values);
        }
    }
}
