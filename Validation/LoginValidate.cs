using FluentValidation;

namespace EczaneMesaj.Validation
{
    public class LoginValidate : AbstractValidator<Models.Tbl_User>
    {
        public LoginValidate()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("KULLANICI ADINIZ BOŞ GEÇEMEZSİNİZ !!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("ŞİFRENİZ BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("KULLANICI ADINIZ 20 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("ŞİFRENİZ 20 KARAKTERDEN FAZLA OLAMAZ !!");
        }
    }
}