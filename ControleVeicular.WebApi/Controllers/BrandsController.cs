using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleVeicular.Domain.Model;
using ControleVeicular.Repository.Data;
using ControleVeicular.Repository;

namespace ControleVeicular.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        public DataContext Context { get; }
        public IControleVeicularRepository Repository { get; }
        public BrandsController(DataContext context, IControleVeicularRepository repository)
        {
            this.Context = context;
            this.Repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await Repository.GetAll<Brand>(); 
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro genérico");
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var results = await Repository.GetById<Brand>(id); 
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro genérico");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Brand model)
        {
            try
            {
                Repository.Add(model);
                if (await Repository.SaveChangesAsync())
                {
                    return Ok();
                    //Não uso o Created aqui por dois motivos, se fosse o anúncio aqui por exemplo, eu poderia redirecionar para a página do anúncio, todavia,
                    //eu fico pensando no fluxo do usuário, ele provavelmente iria adicionar vários anúncios de uma só vez, se toda vez
                    //que ele insere um anúncio, o sistema redirecionar ele, ele vai perder muito tempo. O outro motivo é que eu poderia
                    //mostrar um modal simples informando que foi inserido com sucesso, mas como estou tentando economizar o máximo de tempo
                    //e recursos desnecessários, vou manter o Ok.
                }                
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro genérico");
            }

            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(Guid Id, Brand model)
        {
            try
            {
                var brand = await Repository.GetById<Brand>(Id);
                if (brand == null) return NotFound();

                Repository.Update(model);

                if (await Repository.SaveChangesAsync())
                {
                    return Ok();
                }                
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro genérico");
            }

            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var brand = await Repository.GetById<Brand>(Id);
                if (brand == null) return NotFound();

                Repository.Delete(brand);
                
                if (await Repository.SaveChangesAsync())
                {
                    return Ok();
                }                
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro genérico");
            }

            return BadRequest();
        }
    }
}
