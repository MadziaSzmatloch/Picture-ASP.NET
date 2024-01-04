using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture.Queries.GetPictureByEncodedName
{
    public class GetPictureByEncodedTitleQuery : IRequest<Domain.Entities.Picture>
    {
        public string EncodedTitle { get; set; }
        public GetPictureByEncodedTitleQuery(string encodedTitle)
        {
            EncodedTitle = encodedTitle;
        }
    }
}
