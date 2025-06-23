using System.Collections.Generic;

namespace Pmb.PharmacyControl.Domain.AppServices.Auth.Commands
{
    public class GenerateTokenCommand
    {
        public Dictionary<string, string>? Claims { get; set; }
    }
}
    