using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.Service;
using DataAccessLayer.EntityFramework;
using DtoLayer.Dtos.ServiceDtos;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Concrete;
using ECommerce.BusinessLayer.ValidationRules.About;
using ECommerce.BusinessLayer.ValidationRules.BodySize;
using ECommerce.BusinessLayer.ValidationRules.Brand;
using ECommerce.BusinessLayer.ValidationRules.Color;
using ECommerce.BusinessLayer.ValidationRules.Contact;
using ECommerce.BusinessLayer.ValidationRules.Feature;
using ECommerce.BusinessLayer.ValidationRules.GenreCategory;
using ECommerce.BusinessLayer.ValidationRules.Product;
using ECommerce.BusinessLayer.ValidationRules.SocialMedia;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.EntityFramework;
using ECommerce.DtoLayer.Dtos.AboutDtos;
using ECommerce.DtoLayer.Dtos.BodySizeDtos;
using ECommerce.DtoLayer.Dtos.BrandDtos;
using ECommerce.DtoLayer.Dtos.ColorDtos;
using ECommerce.DtoLayer.Dtos.ContactDtos;
using ECommerce.DtoLayer.Dtos.FeatureDtos;
using ECommerce.DtoLayer.Dtos.GenreCategoryDtos;
using ECommerce.DtoLayer.Dtos.ProductDtos;
using ECommerce.DtoLayer.Dtos.SocialMediaDtos;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.BusinessLayer.Registration
{
    public static class ServiceAppRegistration
    {
        public static IServiceCollection ServicesApp(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DbCon")));

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IValidator<CreateServiceDto>, CreateServiceDtoValidator>();
            services.AddScoped<IValidator<UpdateServiceDto>, UpdateServiceDtoValidator>();

            services.AddScoped<ICartDal, EfCartDal>();
            services.AddScoped<ICartService, CartManager>();

            services.AddScoped<IContactUsDal, EfContactUsDal>();
            services.AddScoped<IContactUsService, ContactUsManager>();
          
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IValidator<CreateProductDto>, CreateProductDtoValidator>();
            services.AddScoped<IValidator<UpdateProductDto>, UpdateProductDtoValidator>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IValidator<UpdateCategoryDto>, UpdateCategoryDtoValidator>();
            services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryDtoValidator>();
            services.AddScoped<ResultCategoryDto>();

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IValidator<UpdateAboutDto>, UpdateAboutDtoValidator>();
            services.AddScoped<IValidator<ResultAboutDto>, ResultAboutDtoValidator>();

            services.AddScoped<IColorDal, EfColorDal>();
            services.AddScoped<IColorService, ColorManager>();
            services.AddScoped<IValidator<CreateColorDto>, CreateColorDtoValidator>();
            services.AddScoped<IValidator<UpdateColorDto>, UpdateColorDtoValidator>();

            services.AddScoped<IBrandDal, EfBrandDal>();
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IValidator<CreateBrandDto>, CreateBrandDtoValidator>();
            services.AddScoped<IValidator<UpdateBrandDto>, UpdateBrandDtoValidator>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IValidator<CreateContactDto>, CreateContactDtoValidator>();
            services.AddScoped<IValidator<UpdateContactDto>, UpdateContactDtoValidator>();

            services.AddScoped<IBodySizeDal, EfBodySizeDal>();
            services.AddScoped<IBodySizeService, BodySizeManager>();
            services.AddScoped<IValidator<CreateBodySizeDto>, CreateBodySizeDtoValidator>();
            services.AddScoped<IValidator<UpdateBodySizeDto>, UpdateBodySizeDtoValidator>();

            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IFeatureService, FeatureManager>();

            services.AddScoped<IValidator<CreateFeatureDto>, CreateFeatureDtoValidator>();
            services.AddScoped<IValidator<UpdateFeatureDto>, UpdateFeatureDtoValidator>();

            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<IValidator<CreateSocialMediaDto>, CreateSocialMediaDtoValidator>();
            services.AddScoped<IValidator<UpdateSocialMediaDto>, UpdateSocialMediaDtoValidator>();


            return services;
        }
    }
}
