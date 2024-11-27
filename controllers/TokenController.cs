// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// using api.Interfaces;
// using api.Models;

using Microsoft.AspNetCore.Mvc;

using Panoglide.Services.Azure;
// using Microsoft.EntityFrameworkCore;

namespace Panoglide.Controllers;

[Route("api/v1/token")]
[ApiController]
public class TokenController() : ControllerBase
{
    // private readonly UserManager<AppUser> _userManager;
    // private readonly ITokenService _tokenService;
    // private readonly AzureService _azure = azure;

    [HttpGet]
    public async Task<IActionResult> GetSasToken()
    {

        // return Ok();

        // if (!ModelState.IsValid)
        // {
        //     return BadRequest(ModelState);
        // }

        // var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

        // if (user == null)
        // {
        //     return Unauthorized("Invalid username!");
        // }

        // var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        // if (!result.Succeeded)
        // {
        //     return Unauthorized("Username not found and/or password incorrect");
        // }

        return Ok(AzureService.GenSasToken());
    }
}