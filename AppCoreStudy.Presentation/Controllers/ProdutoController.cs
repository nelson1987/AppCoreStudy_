using AppCoreStudy.Entities;
using AppCoreStudy.Presentation.ViewModels.Produto;
using AppCoreStudy.Repository;
using AppCoreStudy.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AppCoreStudy.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/produto")]
    //[Authorize("Bearer")]
    public class ProdutoController : Controller
    {
        [HttpPost]
        [ProducesResponseType(200)] //Ok
        [ProducesResponseType(400)] //Requisição Inválida
        [ProducesResponseType(500)] //Erro Interno de Servidor
        public IActionResult Create([FromBody] ProdutoCadastroViewModel model,
                                    [FromServices] IProdutoService repository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto produtoCadastro = Mapper.Map<Produto>(model);
                    repository.Cadastrar(produtoCadastro);
                    return Ok();//200
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);//500
                }
            }
            return BadRequest();//400
        }

        [HttpPut]
        [ProducesResponseType(200)] //Ok
        [ProducesResponseType(400)] //Requisição Inválida
        [ProducesResponseType(500)] //Erro Interno de Servidor
        public IActionResult Update([FromBody] ProdutoEdicaoViewModel model,
                                    [FromServices] IProdutoService repository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto produtoAlterado = Mapper.Map<Produto>(model);
                    repository.Editar(produtoAlterado);

                    return Ok();//200
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);//500
                }
            }
            return BadRequest();//400
        }
        /*
        [HttpDelete("{idProduto}")]
        [ProducesResponseType(200)] //Ok
        [ProducesResponseType(404)] //Nao Encontrado
        [ProducesResponseType(500)] //Erro Interno de Servidor
        public IActionResult Delete(int idProduto,
                                    [FromServices] IProdutoService repository)
        {
            try
            {
                Produto produtoAlterado = repository.GetById(idProduto);

                if (produtoAlterado == null)
                    return NotFound();

                repository.De(idProduto);

                return Ok();//200
                //TODO: Criar 404- caso não ache o idProduto
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);//500
            }
        }
        */
        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<ProdutoConsultaViewModel>))] //Ok
        //[ProducesResponseType(500)] //Erro Interno de Servidor
        //public IActionResult GetAll([FromServices] IProdutoService repository)
        //{
        //    try
        //    {
        //        var lista = new List<ProdutoConsultaViewModel>();

        //        foreach (var p in repository.FindAll())
        //            lista.Add(Mapper.Map<ProdutoConsultaViewModel>(p));

        //        return Ok(lista);//200
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);//500
        //    }
        //}

        //[HttpGet("{idProduto}")]
        //[ProducesResponseType(200, Type = typeof(ProdutoConsultaViewModel))] //Ok
        //[ProducesResponseType(500)] //Erro Interno de Servidor
        //public IActionResult GetById(int idProduto,
        //                            [FromServices] IProdutoService repository)
        //{
        //    try
        //    {
        //        Produto produto = repository.GetById(idProduto);

        //        if (produto == null)
        //            return NotFound();

        //        return Ok(Mapper.Map<ProdutoConsultaViewModel>(produto));//200
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);//500
        //    }
        //}
    }
}
