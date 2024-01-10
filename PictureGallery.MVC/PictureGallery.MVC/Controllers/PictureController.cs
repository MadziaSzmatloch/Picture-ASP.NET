using AutoMapper;
using PictureGallery.Application.ApplicationUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PictureGallery.Application.Picture;
using PictureGallery.Application.Picture.Commands.CreatePicture;
using PictureGallery.Application.Picture.Commands.EditPicture;
using PictureGallery.Application.Picture.Queries.GetAllPicture;
using PictureGallery.Application.Picture.Queries.GetPictureByEncodedName;
using PictureGallery.Application;
using PictureGallery.Domain.Entities;
using PictureGallery.Domain.Interfaces;
using PictureGallery.Application.Picture.Commands.DeletePicture;

namespace PictureGallery.MVC.Controllers
{
    public class PictureController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public PictureController(IMediator mediator, IMapper mapper, IUserContext userContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<IActionResult> Index()
        {
            var pictures = await _mediator.Send(new GetAllPictureQuery());
            var currentUser = _userContext.GetCurrentUser();

            var ViewModel = new PictureListViewModel
            {
                Pictures = pictures,
                User = currentUser
            };
            return View(ViewModel);
        }


        [Authorize]
        public async Task<IActionResult> UsersPictures()
        {
            var pictures = await _mediator.Send(new GetAllPictureQuery());
            var currentUser = _userContext.GetCurrentUser();

            var ViewModel = new PictureListViewModel
            {
                Pictures = pictures.Where(sc => sc.CreatedById == currentUser.Id),
                User = currentUser
            };
            return View(ViewModel);
        }

        [Route("Picture/{encodedTitle}/Details")]
        public async Task<IActionResult> Details(string encodedTitle)
        {
            var picture = await _mediator.Send(new GetPictureByEncodedTitleQuery(encodedTitle));
            var currentUser = _userContext.GetCurrentUser();

            var ViewModel = new PictureViewModel
            {
                Picture = picture,
                User = currentUser
            };
            return View(ViewModel);
        }

        [Route("Picture/{encodedTitle}/Edit")]
        public async Task<IActionResult> Edit(string encodedTitle)
        {
            var picture = await _mediator.Send(new GetPictureByEncodedTitleQuery(encodedTitle));

            var user = _userContext.GetCurrentUser();
            bool isEditable = user != null && picture.CreatedById == user.Id;
            if (!isEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(DeletePictureCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
