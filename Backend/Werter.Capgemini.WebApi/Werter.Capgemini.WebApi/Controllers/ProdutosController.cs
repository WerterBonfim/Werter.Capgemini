using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Werter.Capgemini.WebApi.Application.Commands;

namespace Werter.Capgemini.WebApi.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : BaseController
    {
        //[ProducesResponseType(typeof(ViewModelBase), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return RespostaPersonalizada(new {Nome = "Guitarra"});
        }
        
        
        [HttpPost]
        public IActionResult Cadastrar(
            List<IFormFile> files,
            [FromForm] RegistrarProdutoCommand command
        )
        {
            if (files == null)
            {
                AdicionarErro("A imagem não foi fornecida");
                return RespostaPersonalizada();
            }

            var arquivoPostado = files.FirstOrDefault();

            // TODO: Definir 2 MB como tamanho maximo. Validar extenção do arquivo
            var arquivoInvalido = arquivoPostado.Length <= 0;
            if (arquivoInvalido)
                return StatusCode(417, new {Mensagem = "Arquivo ou imagem inválida"});

            // requisitos.Extencao = ObterExtencaoArquivo(arquivoPostado);
            // var resultado = _servicosDeFotos.LidarCom(requisitos);
            // if (!resultado.Sucesso)
            //     return BadRequest(resultado);
            //
            // GravarFotoNoDiretorio(resultado, arquivoPostado);
            //
            // return Ok(resultado);

            return RespostaPersonalizada();
        }
    }
}