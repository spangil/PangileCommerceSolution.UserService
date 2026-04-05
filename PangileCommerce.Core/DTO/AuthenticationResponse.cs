using System;
using System.Collections.Generic;
using System.Text;

namespace PangileCommerce.Core.DTO;

public record AuthenticationResponse(Guid UserID, string? Email, string? PersonName, string? Gender, string? Token = null, bool Success = false)
{
    //Parameterless constructor
    public AuthenticationResponse() : this(default,default,default,default,default,default)
    {
        
    }
}

