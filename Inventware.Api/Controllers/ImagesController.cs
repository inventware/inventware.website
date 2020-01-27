using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Inventware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImagesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet("getLogo")]
        public ActionResult<string> Get()
        {
            return Path.Combine(_hostingEnvironment.WebRootPath, "Images\\INVENTWARE.png");
        }

        [HttpGet("getImageCalledOf/{ImageName}")]
        public ActionResult<string> Get(string imageName)
        {
            var pathFilePart = Path.Combine("Images", imageName);
            return Path.Combine(_hostingEnvironment.WebRootPath, pathFilePart);
        }


        // GET api/values
        [HttpGet("getImageAt/{ImagePath}")]
        public ActionResult<string> Get(string imagePath, string imageName)
        {
            var pathFilePart = Path.Combine(imagePath, imageName);
            return Path.Combine(_hostingEnvironment.WebRootPath, pathFilePart);
        }

        /// Caminho para conteúdo: Path.Combine(_hostingEnvironment.ContentRootPath,"Diretorio_Dentro_Raiz\\Nome_arquivo.png");
    }
}