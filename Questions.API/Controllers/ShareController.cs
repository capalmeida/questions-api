using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questions.Domain.Models;
using Questions.Services.Interfaces;
using Questions.Services.ViewModels;

namespace Questions.API.Controllers
{
    /// <inheritdoc />
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private readonly IShareService _shareService;

        /// <summary>
        /// Share Controller
        /// </summary>
        /// <param name="shareService"></param>
        public ShareController(IShareService shareService)
        {
            _shareService = shareService;
        }

        /// <summary>
        /// Share
        /// </summary>
        /// <param name="destinationEmail"></param>
        /// <param name="contentUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/share")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Share([Required] string destinationEmail, [Required] string contentUrl)
        {
            await _shareService.ShareAsync(destinationEmail, contentUrl);
            return Ok(new
            {
                status = "OK"
            });
        }

    }
}