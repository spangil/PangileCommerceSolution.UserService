using PangileCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PangileCommerce.Core.ServiceContracts;

    public interface IUsersService
    {
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);

    }

