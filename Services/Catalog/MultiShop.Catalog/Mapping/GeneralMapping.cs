using AutoMapper;
using MultiShop.Catalog.DTOs.AboutDTOs;
using MultiShop.Catalog.DTOs.BrandDTOs;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.DTOs.ContactDTOs;
using MultiShop.Catalog.DTOs.FeatureDTOs;
using MultiShop.Catalog.DTOs.FeatureSliderDTOs;
using MultiShop.Catalog.DTOs.OfferDiscountDTOs;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.DTOs.SpecialOfferDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetByIDCategoryDTO>().ReverseMap();

            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, GetByIDProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductsWithCategoryDTO>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, GetByIDProductDetailDTO>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, GetByIDProductImageDTO>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDTO>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDTO>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDTO>().ReverseMap();
            CreateMap<FeatureSlider, GetByIDFeatureSliderDTO>().ReverseMap();

            CreateMap<SpecialOffer, ResultSpecialOfferDTO>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDTO>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDTO>().ReverseMap();
            CreateMap<SpecialOffer, GetByIDSpecialOfferDTO>().ReverseMap();

            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetByIDFeatureDTO>().ReverseMap();

            CreateMap<OfferDiscount, ResultOfferDiscountDTO>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDTO>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDTO>().ReverseMap();
            CreateMap<OfferDiscount, GetByIDOfferDiscountDTO>().ReverseMap();

            CreateMap<Brand, ResultBrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();
            CreateMap<Brand, UpdateBrandDTO>().ReverseMap();
            CreateMap<Brand, GetByIDBrandDTO>().ReverseMap();

            CreateMap<About, ResultAboutDTO>().ReverseMap();
            CreateMap<About, CreateAboutDTO>().ReverseMap();
            CreateMap<About, UpdateAboutDTO>().ReverseMap();
            CreateMap<About, GetByIDAboutDTO>().ReverseMap();


            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
            CreateMap<Contact, GetByIDContactDTO>().ReverseMap();

        }
    }
}
