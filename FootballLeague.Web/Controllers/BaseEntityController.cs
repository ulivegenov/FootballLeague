namespace FootballLeague.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FootballLeague.Data.Models;
    using FootballLeague.Services.Data.Contracts;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Contracts;
    using FootballLeague.Web.ViewModels.Contracts;

    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseEntityController<TEntity, TKey, TEntityWebInputModel, TEntityServiceInputModel,
                                                   TEntityServiceDetailsModel, TEntityWebAllModel,
                                                   TEntityWebDetailsModel> : Controller
        where TEntity : BaseDeletableEntity<TKey>
        where TEntityServiceInputModel : IServiceInputModel
        where TEntityWebInputModel : IWebInputModel
        where TEntityServiceDetailsModel : IServiceDetailsModel<TKey>
        where TEntityWebAllModel : IWebAllModel<TKey>
        where TEntityWebDetailsModel : IWebDetailsModel<TKey>
    {
        private readonly IBaseService<TKey> entityService;

        public BaseEntityController(IBaseService<TKey> entityService)
        {
            this.entityService = entityService;
        }

        public virtual async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TEntityWebInputModel entityWebInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(entityWebInputModel);
            }

            var entityServiceModel = entityWebInputModel.To<TEntityServiceInputModel>();

            await this.entityService.CreateAsync(entityServiceModel);

            return this.Redirect($"/{typeof(TEntity).Name}s/All");
        }

        public async Task<IActionResult> All(TEntityWebAllModel viewModel)
        {
            var entities = await this.entityService
                                     .GetAllAsync<TEntityServiceDetailsModel>();

            this.AddEntitiesToViewModel(viewModel, entities);

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(TKey id)
        {
            var entity = await this.entityService.GetByIdAsync<TEntityServiceDetailsModel>(id);
            var viewModel = entity.To<TEntityWebDetailsModel>();

            return this.View(viewModel);
        }

        public async Task<IActionResult> Edit(TKey id)
        {
            var entity = await this.entityService.GetByIdAsync<TEntityServiceDetailsModel>(id);
            var viewModel = entity.To<TEntityWebDetailsModel>();

            return this.View(viewModel);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(TEntityWebDetailsModel entityEditModel)
        {
            if (!this.ModelState.IsValid)
            {
                var entity = await this.entityService.GetByIdAsync<TEntityServiceDetailsModel>(entityEditModel.Id);
                var viewModel = entity.To<TEntityWebDetailsModel>();

                return this.View(viewModel);
            }

            var serviceEntity = entityEditModel.To<TEntityServiceDetailsModel>();

            await this.entityService.EditAsync(serviceEntity);

            return this.Redirect($"/{typeof(TEntity).Name}s/Details/{serviceEntity.Id}");
        }

        public async Task<IActionResult> Delete(TKey id)
        {
            var entity = await this.entityService.GetByIdAsync<TEntityServiceDetailsModel>(id);
            var viewModel = entity.To<TEntityWebDetailsModel>();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TEntityWebDetailsModel entityDetailsModel)
        {
            if (!this.ModelState.IsValid)
            {
                var entity = await this.entityService.GetByIdAsync<TEntityServiceDetailsModel>(entityDetailsModel.Id);
                var viewModel = entity.To<TEntityWebDetailsModel>();

                return this.View(viewModel);
            }

            await this.entityService.DeleteByIdAsync(entityDetailsModel.Id);

            return this.Redirect($"/{typeof(TEntity).Name}s/All");
        }

        protected void AddEntitiesToViewModel(TEntityWebAllModel viewModel, IEnumerable<TEntityServiceDetailsModel> entities)
        {
            foreach (var entity in entities)
            {
                viewModel.Entities.Add(entity.To<TEntityWebDetailsModel>());
            }
        }
    }
}
