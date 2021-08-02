using ERPAPI.Auth;
using ERPAPI.Models;
using GlobalLib.DataContext;
using GlobalLib.Models.V_EIP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Threading.Tasks;
using wsSSOReference;
using static wsSSOReference.wsSSOSoapClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// DB Connection Strings
        /// </summary>
        private IConfiguration _configuration { get; }
        /// <summary>
        /// Log
        /// </summary>
        private ILogger<LoginController> _logger { get; }
        /// <summary>
        /// Jwt Handler
        /// </summary>
        private JwtHandler _jwtHandler { get; }
        /// <summary>
        /// V_EIP Entities
        /// </summary>
        private readonly V_EIPContext _context;
        /// <summary>
        /// Init
        /// </summary>
        /// <param name="c"></param>
        /// <param name="logger"></param>
        public LoginController(IConfiguration configuration,
                                ILogger<LoginController> logger,
                                JwtHandler jwtHandler,
                                V_EIPContext context)
        {
            _configuration = configuration;
            _logger = logger;
            // step 4-1, generate token by using JwtSecurityTokenHandler
            _jwtHandler = jwtHandler;
            _context = context;
        }
#if true
        /// <summary>
        /// Create tblAdmissionInfo data
        /// </summary>
        /// <remarks>
        ///     Sample request:
        ///     
        ///         POST /Todo
        ///         {
        ///             Phone
        ///             Screen_bytNum
        ///             ScreenD_strPhyRowId
        ///             ScreenD_strSeatId
        ///             DBName
        ///         }
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <response code="201"></response>
        /// <response code="400"></response>
        [HttpPost]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] UserForAuthentication data)
        {
            string BadMessage = string.Empty;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Error Message
            // Task<wsSSOReference.LoginByUserResponse> rs = null;
            // string[] userRoles = (string[])Session["UserRoles"];

            try
            {
                _logger.LogInformation($"Start:{data.Username}/{data.Password}");


                if (!String.IsNullOrEmpty(data.Password))
                {
                    // Consuming ASMX Web Services in ASP.NET Core
                    // https://www.thecodebuzz.com/consuming-asmx-web-services-in-asp-net-core/
                    // Consuming soap service in net core
                    // https://www.codepoc.io/blog/c-sharp/6092/consuming-soap-service-in-net-core
                    /////////////////////////////////////////////////////////////////////////////////////////
                    // Web References
                    LoginDetail wsLD = new LoginDetail()
                    {
                        strUserID = data.Username,
                        strUserPWD = data.Password
                    };

                    // SSO API
                    wsSSOSoapClient wsSSOR = new wsSSOSoapClient(EndpointConfiguration.wsSSOSoap);
                    LoginByUserResponse rs = wsSSOR.LoginByUserAsync(wsLD).Result;

                    if (string.IsNullOrEmpty(rs.Body.LoginByUserResult))
                    {
                        /////////////////////////////////////////////////////////////////////////////////////////
                        // Get DepartID
                        tblUser tblUserInfo = _context.tblUser.Find(wsLD.strUserID);

                        // var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
                        //if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                        //    return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

                        var signingCredentials = _jwtHandler.GetSigningCredentials();

                        IdentityUser user = new IdentityUser()
                        {
                            UserName = data.Username
                        };

                        var claims = _jwtHandler.GetClaims(user);
                        // the SecurityTokenDescriptor is based on Configuration in Startup.cs
                        var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                        // step 4-2, serializes a JwtSecurityToken into a JWT in compact serialization format
                        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                        return Ok(new AuthResponse { IsAuthSuccessful = true, Token = token });
                    }
                    else
                    {
                        BadMessage = rs.Body.LoginByUserResult;
                    }
#if fa


                    _logger.LogInformation($"Start {tblUserInfo.cUser_ID}");

                    if (string.IsNullOrEmpty(rs))
                    {
                        var identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, input.Username),
                        },
                        DefaultAuthenticationTypes.ApplicationCookie,
                        ClaimTypes.Name,
                        ClaimTypes.Role);

                        // if you want roles, just add as many as you want here (for loop maybe?)
                        identity.AddClaim(new Claim(ClaimTypes.Role, input.Username.ToLower()));
                        identity.AddClaim(new Claim(ClaimTypes.Role, tblUserInfo.cDepart_ID));

                        this.Session["role_id"] = input.Username;

                        // tell OWIN the identity provider, optional
                        // identity.AddClaim(new Claim(IdentityProvider, "Simplest Auth"));
                        Authentication.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = input.RememberMe
                        }, identity);

                        var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
                        if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                            return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

                        var signingCredentials = _jwtHandler.GetSigningCredentials();
                        var claims = _jwtHandler.GetClaims(user);
                        var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                        return Ok(new AuthResponse { IsAuthSuccessful = true, Token = token });
                    }
#endif
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return BadRequest(ex);
            }

            return BadRequest(new AuthResponse { IsAuthSuccessful = false, ErrorMessage = BadMessage, Token = null } );
        }
#endif
    }
}
