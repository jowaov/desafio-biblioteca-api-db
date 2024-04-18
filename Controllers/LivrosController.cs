using DesafioAPIRocketseat.Communications.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPIRocketseat.Controllers
{
    [Route("biblioteca/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private BibliotecaDB _livros;

        public LivrosController(BibliotecaDB livro)
        {

            _livros = livro;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RequestLivroCreateJson), StatusCodes.Status201Created)]
        public IActionResult criarLivro(RequestLivroCreateJson novoLivro)
        {
           _livros.Add(novoLivro);
            _livros.SaveChanges();
           return Ok(novoLivro);
        }

        [HttpGet("buscarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult consultarTodosOsLivros()
        {
            return Ok(_livros.Livros);
        }

        [HttpGet("buscarPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult consultarLivrosPorId(int id)
        {
            var resultadoConsulta = _livros.Livros.Find(id);
            if (resultadoConsulta == null)
                return NotFound("Nenhum livro cadastrado com esse ID.");
            return Ok(resultadoConsulta);
        }

        [HttpPut("editar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult editarLivro([FromBody] RequestLivroCreateJson editar, int id)
        {
            var editarLivro = _livros.Livros.Find(id);
            if (editarLivro == null)
                return NotFound("Nenhum livro cadastrado com esse ID.");

            editarLivro.Titulo = editar.Titulo;
            editarLivro.Autor = editar.Autor;
            editarLivro.Preco = editar.Preco;
            editarLivro.Genero = editar.Genero;
            editarLivro.Estoque = editar.Estoque;

            _livros.Livros.Update(editarLivro);
            _livros.SaveChanges();
            return NoContent();
        }

        [HttpDelete("deletar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult deletarLivro([FromRoute] int id)
        {
            var deletarLivro = _livros.Livros.Find(id);
            if (deletarLivro == null)
                return NotFound("Nenhum livro cadastrado com esse ID.");
            _livros.Livros.Remove(deletarLivro);
            _livros.SaveChanges();
            return NoContent();
        }
    }
}
