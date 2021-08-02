using GlobalLib.DataContext;
using GlobalLib.Models.V_EIP;
using GlobalLib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

// Using Dapper in ASP.NET Core Web API
// https://www.freecodespot.com/blog/using-dapper-in-asp-net-core-web-api/
// Using Dapper In ASP.NET Core Web API
// https://www.c-sharpcorner.com/article/using-dapper-in-asp-net-core-web-api/
/// <summary>
/// 
/// </summary>
namespace ERPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_EIPController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IDapper _dapper;
        /// <summary>
        /// Log
        /// </summary>
        private ILogger<V_EIPController> _logger { get; }
        /// <summary>
        /// V_EIP
        /// </summary>
        /// <param name="dapper"></param>
        public V_EIPController(IDapper dapper,
                               ILogger<V_EIPController> logger,
                               V_EIPContext context)
        {
            _logger = logger;
            _dapper = dapper;
        }

        [HttpGet]
        public async Task<List<tblUser>> Get()
        {
            var result = await Task.FromResult(_dapper.GetAll<tblUser>(@$"Select * 
                                                                        FROM tblUser", 
                                                                        null, 
                                                                        commandType: CommandType.Text));
            return result;
        }
    }
}
