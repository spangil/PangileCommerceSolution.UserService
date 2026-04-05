using System;
using System.Collections.Generic;
using System.Text;

namespace PangileCommerce.Core.DTO;

public record RegisterRequest(string? Email, string? Password, string? PersonName, GenderOptions Gender);
   
