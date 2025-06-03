using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.FeatureDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var mongoClient = new MongoClient(_databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection = mongoDatabase.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDTO createFeatureDTO)
        {
            var value = _mapper.Map<Feature>(createFeatureDTO);
            await _featureCollection.InsertOneAsync(value);

        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureID == id);
        }

        public async Task<List<ResultFeatureDTO>> GetAllFeatureAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDTO>>(values);
        }

        public async Task<GetByIDFeatureDTO> GetByIDFeatureAsync(string id)
        {
            var values = await _featureCollection.Find<Feature>(x => x.FeatureID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDFeatureDTO>(values);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDTO)
        {
            var values = _mapper.Map<Feature>(updateFeatureDTO);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureID == updateFeatureDTO.FeatureID, values);
        }
    }
}
