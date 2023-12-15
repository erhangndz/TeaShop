using Microsoft.AspNetCore.Identity;

namespace TeaShop.Presentation.Validations
{
    public class CustomIdentityValidator: IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Description = "Şifrede en az 1 adet rakam bulunmalıdır."
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Description = $"Şifreniz en az {length} karakter içermelidir."
            };
        }


        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Description = "Şifrede en az 1 adet büyük harf bulunmalıdır."
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Description = "Şifrede en az 1 adet küçük harf bulunmalıdır."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Description = "Şifrede en az 1 adet simge (*,+,!,-,_...) bulunmalıdır."
            };
        }



    }
}
