using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ToDoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoModel>> ListarTodos()
    {
        var toDos = _context.ToDo.ToList();
        if (toDos != null)
        {
            return Ok(toDos);
        }
        return NotFound("Nenhum lista foi encontrado");
    }

    [HttpGet("{id}")]
    public ActionResult<ToDoModel> BuscarPorId(int id)
    {
        var toDoId = _context.ToDo.Find(id);
        if (toDoId != null)
        {
            return Ok(toDoId);
        }
        
        return NotFound("Item não encontrado");
    }
    
    [HttpPost]
    public ActionResult<ToDoModel> CriarToDo(ToDoModel toDoModel)
    {
        if (toDoModel == null)
        {
            return BadRequest("Ocorreu um erro na solicitação");
        }
        
        _context.Add(toDoModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscarPorId), new { id = toDoModel.Id }, toDoModel);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(ToDoModel toDoModel,int id)
    {
        var toDo = _context.ToDo.FirstOrDefault(t => t.Id == id);
        
        if(toDo == null){
            return NotFound();
        }
        
        toDo.Title = toDoModel.Title;
        toDo.Description = toDoModel.Description;
        
        _context.ToDo.Update(toDo);
        _context.SaveChanges();
        return Ok(toDoModel);
    }

    [HttpDelete("{id:int}")]
    public ActionResult RemoverToDo(int id)
    {
        var toDo = _context.ToDo.FirstOrDefault(t => t.Id == id);
        if (toDo == null)
        {
            return BadRequest();
        }

        _context.ToDo.Remove(toDo);
        _context.SaveChanges();

        return Ok(toDo);
    }
}