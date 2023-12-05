﻿using Microsoft.AspNetCore.Mvc;
using PictureGallery.Application.Services;

namespace PictureGallery.MVC.Controllers
{
    public class PictureController : Controller
    {
        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.Picture picture)
        {
            await _pictureService.Create(picture);
            return RedirectToAction(nameof(Create)); //TODO: refactor
        }
    }
}