using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NuGet.DependencyResolver;
using TeaShop.Dto.Dtos.AccountDtos;
using TeaShop.Entity.Models;

namespace TeaShop.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        

        public AccountController(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
           
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var newUser = _mapper.Map<AppUser>(registerDto);
          var result =   await _userManager.CreateAsync(newUser,registerDto.Password);
            if(result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla sisteme kaydedildi");
            }
            return BadRequest(result.Errors);
           
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
           
         var result =  await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false,false);
            if(result.Succeeded)
            {

                
                return Ok("Kullanıcı girişi başarılı");
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
            
            
        }
    }
}
