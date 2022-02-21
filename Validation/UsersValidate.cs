using EczaneMesaj.Models;
using FluentValidation;

namespace EczaneMesaj.Validation
{
    public class UsersValidate : AbstractValidator<Tbl_User>
    {
        public UsersValidate()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("KULLANICI ADINIZ BOŞ GEÇEMEZSİNİZ !!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("ŞİFRENİZ BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İSMİNİZ BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("KULLANICI ADINIZ 20 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("ŞİFRENİZ 20 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İSMİNİZ 50 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Image).MaximumLength(250).WithMessage("RESMİNİZ 250 KARAKTERDEN FAZLA OLAMAZ !!");
        }
    }
}