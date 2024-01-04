using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture.Commands.EditPicture
{
    public class EditPictureCommand : PictureDto, IRequest
    {
    }
}
