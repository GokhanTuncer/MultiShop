using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.AboutDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var mongoClient = new MongoClient(_databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            _aboutCollection = mongoDatabase.GetCollection<About>(_databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDTO createAboutDTO)
        {
            var value = _mapper.Map<About>(createAboutDTO);
            await _aboutCollection.InsertOneAsync(value);

        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.AboutID == id);
        }

        public async Task<List<ResultAboutDTO>> GetAllAboutAsync()
        {
            var values = await _aboutCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDTO>>(values);
        }

        public async Task<GetByIDAboutDTO> GetByIDAboutAsync(string id)
        {
            var values = await _aboutCollection.Find<About>(x => x.AboutID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDAboutDTO>(values);
        }

        public async Task UpdateAboutAsync(UpdateAboutDTO updateAboutDTO)
        {
            var values = _mapper.Map<About>(updateAboutDTO);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutID == updateAboutDTO.AboutID, values);
        }
    }
}
