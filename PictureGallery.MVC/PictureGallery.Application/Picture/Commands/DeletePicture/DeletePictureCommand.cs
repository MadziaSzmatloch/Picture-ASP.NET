using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture.Commands.DeletePicture
{
    public class DeletePictureCommand : PictureDto, IRequest
    {
    }
}
