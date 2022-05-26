using System;
using System.Threading.Tasks;

using First.Prototype.Administrator.Application.Interfaces;
using First.Prototype.Administrator.Application.ViewModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.Prototype.UI.Web.Controllers
{
  public class UserController : Controller
  {
    private readonly IUserAppService _service;

    public UserController(IUserAppService service)
    {
      _service = service;
    }

    // GET: UserController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: UserController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(UserViewModel viewModel)
    {
      try
      {
        if(!ModelState.IsValid)
          return View(viewModel);

        var response = await _service.Register(viewModel);
        if(!response.Success)
        {
          ViewBag.Error = response.Message;
          return View(viewModel);
        }

        ViewBag.Success = response.Message;
        return RedirectToAction(nameof(Index));
      }
      catch(Exception ex)
      {
        ViewBag.Error = ex.Message;
        return View(viewModel);
      }
    }

    // GET: UserController/Delete/5
    public async Task<ActionResult> Delete(Guid id)
    {
      try
      {
        var viewModel = await _service.GetById(id);
        if(viewModel is null)
        {
          ViewBag.Error = "Not Found";
          return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
      }
      catch(Exception ex)
      {
        ViewBag.Error = ex.Message;
        return RedirectToAction(nameof(Index));
      }
    }

    // POST: UserController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(UserViewModel viewModel)
    {
      try
      {
        var response = await _service.Remove(viewModel.Id);
        if(!response.Success)
        {
          ViewBag.Error = response.Message;
          return View(viewModel);
        }

        ViewBag.Success = response.Message;
        return RedirectToAction(nameof(Index));
      }
      catch(Exception ex)
      {
        ViewBag.Error = ex.Message;
        return View(viewModel);
      }
    }

    // GET: UserController/Details/5
    public async Task<ActionResult> Details(Guid id)
    {
      try
      {
        var viewModel = await _service.GetById(id);
        if(viewModel is null)
        {
          ViewBag.Error = "Not Found";
          return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
      }
      catch(Exception ex)
      {
        ViewBag.Error = ex.Message;
        return RedirectToAction(nameof(Index));
      }
    }

    // GET: UserController/Edit/5
    public async Task<ActionResult> Edit(Guid id)
    {
      try
      {
        var viewModel = await _service.GetById(id);
        if(viewModel is null)
        {
          ViewBag.Error = "Not Found";
          return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
      }
      catch(Exception ex)
      {
        ViewBag.Error = ex.Message;
        return RedirectToAction(nameof(Index));
      }
    }

    // POST: UserController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(UserViewModel viewModel)
    {
      try
      {
        if(!ModelState.IsValid)
          return View(viewModel);

        var response = await _service.Update(viewModel);
        if(!response.Success)
        {
          ViewBag.Error = response.Message;
          return View(viewModel);
        }

        ViewBag.Success = response.Message;
        return RedirectToAction(nameof(Index));
      }
      catch(Exception ex)
      {
        ViewBag.Error = ex.Message;
        return View(viewModel);
      }
    }

    // GET: UserController
    public async Task<ActionResult> Index()
    {
      var list = await _service.GetAll();
      return View(list);
    }
  }
}