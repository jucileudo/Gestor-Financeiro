using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Core.CommonsObjects
{
    public   class Email
    {
        public const int EmailAddressMaxLength = 254;
        public const int EmailAddressLength = 5;
        public string EmailAddress { get; private set; }

        //Construtor do EntityFramework
        protected Email() { }

        public Email(string emailAddress)
        {
            if (!ValidarEmail(emailAddress)) throw new DomainException("E-mail inválido");
            EmailAddress = emailAddress;
        }

        public static bool ValidarEmail(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
