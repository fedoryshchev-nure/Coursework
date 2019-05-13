using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Data.Repositories.Generic;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    public abstract class GenericContoller<Tdto, TEntity> : Controller
        where TEntity : class, IEntity, new()
    {
        private readonly IGenericRepository<TEntity> repository;
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;

        protected GenericContoller(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.GetRepository<TEntity>();
        }

        protected GenericContoller(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tdto>>> GetAsync()
        {
            try
            {
                var entities = await repository.GetAllAsync();
                var dtos = mapper.Map<IEnumerable<Tdto>>(entities);

                return Ok(dtos);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tdto>> GetAsync(string id)
        {
            try
            {
                var entity = await repository.GetAsync(id);
                var dto = mapper.Map<Tdto>(entity);

                if (dto == null)
                    return NotFound();

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Tdto>> PostAsync([FromBody]Tdto dto)
        {
            try
            {
                var entity = mapper.Map<TEntity>(dto);
                await repository.AddAsync(entity);

                await unitOfWork.CompleteAsync();

                dto = mapper.Map<Tdto>(entity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Tdto>> Put(string id, [FromBody]Tdto dto)
        {
            try
            {
                var entity = await repository.GetAsync(id);
                mapper.Map<Tdto, TEntity>(dto, entity);

                await unitOfWork.CompleteAsync();

                dto = mapper.Map<Tdto>(entity);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                repository.Remove(new TEntity { Id = id });

                await unitOfWork.CompleteAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
