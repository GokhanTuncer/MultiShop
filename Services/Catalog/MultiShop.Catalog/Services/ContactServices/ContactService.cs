using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ContactDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _ContactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var mongoClient = new MongoClient(_databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            _ContactCollection = mongoDatabase.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDTO createContactDTO)
        {
            var value = _mapper.Map<Contact>(createContactDTO);
            await _ContactCollection.InsertOneAsync(value);

        }

        public async Task DeleteContactAsync(string id)
        {
            await _ContactCollection.DeleteOneAsync(x => x.ContactID == id);
        }

        public async Task<List<ResultContactDTO>> GetAllContactAsync()
        {
            var values = await _ContactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDTO>>(values);
        }

        public async Task<GetByIDContactDTO> GetByIDContactAsync(string id)
        {
            var values = await _ContactCollection.Find<Contact>(x => x.ContactID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDContactDTO>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDTO updateContactDTO)
        {
            var values = _mapper.Map<Contact>(updateContactDTO);
            await _ContactCollection.FindOneAndReplaceAsync(x => x.ContactID == updateContactDTO.ContactID, values);
        }
    }
}
