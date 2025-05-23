﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var mongoClient = new MongoClient(_databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = mongoDatabase.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            var value = _mapper.Map<Category>(createCategoryDTO);
            await _categoryCollection.InsertOneAsync(value);

        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryID == id);
        }

        public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDTO>>(values);
        }

        public async Task<GetByIDCategoryDTO> GetByIDCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDCategoryDTO>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var values = _mapper.Map<Category>(updateCategoryDTO);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDTO.CategoryID, values);
        }
    }
}
