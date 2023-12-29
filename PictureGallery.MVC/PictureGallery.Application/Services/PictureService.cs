using AutoMapper;
using PictureGallery.Application.Picture;
using PictureGallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper _mapper;

        public PictureService(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task Create(PictureDto pictureDto)
        {
            var picture = _mapper.Map<Domain.Entities.Picture>(pictureDto);
            picture.EncodeTitle();
            picture.SetImageName();
            await _pictureRepository.Create(picture);
        }
    }
}
