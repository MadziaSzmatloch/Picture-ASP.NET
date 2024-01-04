using MediatR;
using Microsoft.AspNetCore.Mvc;
using PictureGallery.Application.Picture.Commands.CreatePicture;
using PictureGallery.Application.Picture.Queries.GetAllPicture;

namespace PictureGallery.MVC.Controllers
{
    public class PictureController : Controller
    {
        private readonly IMediator _mediator;

        public PictureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var pictures = await _mediator.Send(new GetAllPictureQuery());
            return View(pictures);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePictureCommand command)
         {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
