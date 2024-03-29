﻿using AutoMapper;
using PictureGallery.Application.Picture;
using PictureGallery.Application.Picture.Commands.EditPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Mappings
{
    public class PictureMappingProfile : Profile
    {
        public PictureMappingProfile() 
        {
            CreateMap<PictureDto, Domain.Entities.Picture>();

            CreateMap<Domain.Entities.Picture, PictureDto>();

            CreateMap<Domain.Entities.Picture, EditPictureCommand>();
        }
    }
}
