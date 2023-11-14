using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.GenreCategoryDtos;
using ECommerce.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;



namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IValidator<CreateCategoryDto> _createValidator;
        private readonly IValidator<UpdateCategoryDto> _updateValidator;
        private readonly ResultCategoryDto _resultValidator;

        public CategoryController(IMapper mapper, ICategoryService categoryService, IValidator<CreateCategoryDto> createValidator, IValidator<UpdateCategoryDto> updateValidator, ResultCategoryDto resultValidator)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _resultValidator = resultValidator;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetList());
            if (values != null)
            {
                
                return View(values);
            }

          
            return View();
        }


        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto createCategoryDto)
        {
            var validator = _createValidator.Validate(createCategoryDto);

            if (validator.IsValid)
            {
                var value = _mapper.Map<CreateCategoryDto, Category>(createCategoryDto);
                _categoryService.TAdd(value);

                

                return LocalRedirect("/Admin/Category/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createCategoryDto);
            }
        }

        public IActionResult DeleteCategory(int id)
        {
            var value =_categoryService.TGetByID(id);
            _categoryService.TDelete(value);
          
            return LocalRedirect("/Admin/Category/Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _mapper.Map<UpdateCategoryDto>(_categoryService.TGetByID(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var validator = _updateValidator.Validate(updateCategoryDto);

            if (validator.IsValid)
            {
                var value = _mapper.Map<UpdateCategoryDto, Category>(updateCategoryDto);
                _categoryService.TUpdate(value);

                return LocalRedirect("/Admin/Category/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateCategoryDto);
            }
        }

    }
}
