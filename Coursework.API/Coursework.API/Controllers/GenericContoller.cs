using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    public abstract class GenericContoller<Tdto, TEntity> : Controller
        where TEntity : IEntity, new()
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;

        protected GenericContoller(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        protected GenericContoller(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tdto>> Get()
        {
            try
            {
                return Ok(
                    mapper.Map<IEnumerable<Tdto>>(
                        unitOfWork.GetRepositoryByType(typeof(TEntity))
                            .GetAll()));
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
                return Ok(
                    mapper.Map<Tdto>(
                        await unitOfWork.GetRepositoryByType(typeof(TEntity))
                            .GetAsync(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostAsync([FromBody]Tdto model)
        {
            try
            {
                await unitOfWork.GetRepositoryByType(typeof(TEntity))
                    .AddAsync(
                        mapper.Map<TEntity>(model));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(string id, [FromBody]Tdto model)
        {
            try
            {
                unitOfWork.GetRepositoryByType(typeof(TEntity))
                    .Update(
                        mapper.Map<TEntity>(model));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                unitOfWork.GetRepositoryByType(typeof(TEntity))
                    .Remove(new TEntity { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
