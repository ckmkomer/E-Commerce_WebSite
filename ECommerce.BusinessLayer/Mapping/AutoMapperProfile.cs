using AutoMapper;
using DtoLayer.Dtos.ServiceDtos;
using ECommerce.DtoLayer.Dtos.AboutDtos;
using ECommerce.DtoLayer.Dtos.AppRoleDtos;
using ECommerce.DtoLayer.Dtos.AppUserDtos;
using ECommerce.DtoLayer.Dtos.BodySizeDtos;
using ECommerce.DtoLayer.Dtos.BrandDtos;
using ECommerce.DtoLayer.Dtos.ColorDtos;
using ECommerce.DtoLayer.Dtos.ContactDtos;
using ECommerce.DtoLayer.Dtos.ContactUsDtos;
using ECommerce.DtoLayer.Dtos.FeatureDtos;
using ECommerce.DtoLayer.Dtos.GenreCategoryDtos;
using ECommerce.DtoLayer.Dtos.ProductDetailDtos;
using ECommerce.DtoLayer.Dtos.ProductDtos;
using ECommerce.DtoLayer.Dtos.SocialMediaDtos;
using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Concrete.Identity;

namespace ECommerce.BusinessLayer.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()


        {

            CreateMap<AppUser, LoginAppUserDto>().ReverseMap();
            CreateMap<AppUser, RegisterAppUserDto>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserDto>().ReverseMap();

            CreateMap<AppRole, ResultAppRoleDto>().ReverseMap();
            CreateMap<AppRole, CreateAppRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateAppRoleDto>().ReverseMap();
            CreateMap<AppUser, ResultAppUserRoleDto>().ReverseMap();



            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            CreateMap<BodySize, ResultBodySizeDto>().ReverseMap();
            CreateMap<BodySize, CreateBodySizeDto>().ReverseMap();
            CreateMap<BodySize, UpdateBodySizeDto>().ReverseMap();

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();

            CreateMap<Calor, ResultColorDto>().ReverseMap();
            CreateMap<Calor, CreateColorDto>().ReverseMap();
            CreateMap<Calor, UpdateColorDto>().ReverseMap();

           

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();

            CreateMap<ContactUs, ResultContactUsDto>().ReverseMap();
            CreateMap<ContactUs,  CreateContactUsDto>().ReverseMap();
            CreateMap<ContactUs, UpdateContactUsDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

          
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            

            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();

            

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();

            


        }
    }
}
