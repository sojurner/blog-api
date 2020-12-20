using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PKBlog.Models;
using PKBlog.DataAccess;
using PKBlog.DataAccess.Models;

namespace PKBlog.Controllers
{

    [ApiController]
    [Route("/api/pageview")]
    [Produces("application/json")]
    public class PageViewController : ControllerBase
    {
        #region Properties

        /// <summary>
        /// Logger
        /// </summary>
        private ILogger<PageViewController> _logger { get; }
        private PKBlogContext _context;

        #endregion

        public PageViewController(ILogger<PageViewController> logger, PKBlogContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PageViewDTO>> Get(string type, string name)
        {
            try
            {
                var pageView = _context.PageViews.FirstOrDefault(x => x.Name == name && x.Type == type);

                if(pageView == null)
                {
                    pageView = new PageView()
                    {
                        Type = type,
                        Name = name,
                        Count = 1
                    };

                    _context.PageViews.Add(pageView);
                }
                else
                {
                    pageView.Count += 1;
                    _context.PageViews.Update(pageView);
                }

                await _context.SaveChangesAsync();


                return new PageViewDTO(pageView);
            }
            catch(Exception e)
            {
                _logger.LogError($"Failed to get; Exception:{e}");
                throw;
            }
        }
    }
}
