using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PictureGallery.Application.Picture;
using PictureGallery.Application.Picture.Commands.CreatePicture;
using PictureGallery.Application.Picture.Commands.EditPicture;
using PictureGallery.Application.Picture.Queries.GetAllPicture;
using PictureGallery.Application.Picture.Queries.GetPictureByEncodedName;

namespace PictureGallery.MVC.Controllers
{
    public class PictureController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PictureController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var pictures = await _mediator.Send(new GetAllPictureQuery());
            return View(pictures);
        }

        [Route("Picture/{encodedTitle}/Details")]
        public async Task<IActionResult> Details(string encodedTitle)
        {
            var picture = await _mediator.Send(new GetPictureByEncodedTitleQuery(encodedTitle));
            return View(picture);
        }

        [Route("Picture/{encodedTitle}/Edit")]
        public async Task<IActionResult> Edit(string encodedTitle)
        {
            var picture = await _mediator.Send(new GetPictureByEncodedTitleQuery(encodedTitle));
            //var dto = _mapper.Map<PictureDto>(picture);
            EditPictureCommand model = _mapper.Map<EditPictureCommand>(picture);
            return View(model);
        }

        [HttpPost]
        [Route("Picture/{encodedTitle}/Edit")]
        public async Task<IActionResult> Edit(string encodedTitle, EditPictureCommand command)
         {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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
