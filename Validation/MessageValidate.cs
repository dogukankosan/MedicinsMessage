using EczaneMesaj.Models;
using FluentValidation;

namespace EczaneMesaj.Validation
{
    public class MessageValidate : AbstractValidator<Tbl_Message>
    {
        public MessageValidate()
        {
            RuleFor(x => x.Context).NotEmpty().WithMessage("MESAJ İÇERİĞİ BOŞ GEÇİLEMEZ !!");
        }
    }
}