using Microsoft.AspNetCore.Mvc;
using FirstApp.DataContext;
using Microsoft.EntityFrameworkCore;
using FirstApp.Models;
using FirstApp.Src.Entity;

namespace FirstApp.Controllers;

public class ClassInfoController : Controller{
  private readonly AppDbContext _context;
  public ClassInfoController(AppDbContext context)
  {
    _context = context;
  }
  [HttpGet]
  public async  Task<IActionResult> IndexAsync()
  {
    var list = await _context.ClassInfos.ToListAsync();
    return View(list);
  }


[HttpGet]
public IActionResult Create(){
  return View(new ClassInfoVm());
}

[HttpPost]

    public async Task<IActionResult> Create(ClassInfoVm model)
    {
        try
        { 
          if (!ModelState.IsValid){

            throw new Exception("Invalid data");
          }
            var classInfo = new ClassInfo
            {
                Name = model.Name,
                Description = model.Description,
                CreatedAt = DateTime.UtcNow
            };
            await _context.ClassInfos.AddAsync(classInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Update(long id){
      try{
        var info= await _context.ClassInfos.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (info == null) throw new Exception($"class info id {id} not found");
        var model = new ClassInfoVm(){
          Name = info.Name,
          Description = info.Description

        };
        return View(model);
      
      }
      catch (Exception e){
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public async Task<IActionResult> Update(long id, ClassInfoVm model){
      try{
        var info= await _context.ClassInfos.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (info == null) throw new Exception($"class info id {id} not found");
        info.Name= model.Name;
        info.Description = model.Description;
        _context.ClassInfos.Update(info);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      catch (Exception e){
        return BadRequest(e.Message);
      }
    }
    [HttpGet]
    public async Task<IActionResult> Delete(long id){
      try{
        var info= await _context.ClassInfos.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (info == null) throw new Exception($"class info id {id} not found");

        _context.ClassInfos.Remove(info);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      catch (Exception e){
        return BadRequest(e.Message);
      }
    }
}


