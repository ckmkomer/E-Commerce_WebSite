using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules
{
    public static class ValidationMessages
    {
        public const string NotEmpty = "{0} alanı boş geçilemez."; // Fluent Validation paketinden otomatik geliyor ve çalışmıyor.

        //public static string NotEmpty(string propertyName)
        //{
        //    return $"{propertyName} alanı boş geçilemez.";
        //}

        public const int MinimumLength = 2;
        public const string MinimumLengthMessage = "Lütfen en az 2 karakter girişi yapınız.";
        public const int MaximumLength = 50;
        public const string MaximumLengthMessage = "Lütfen en fazla 50 karakter girişi yapınız.";
        public const string Equal = "Şifreler birbiriyle uyuşmuyor.";
    }
}
