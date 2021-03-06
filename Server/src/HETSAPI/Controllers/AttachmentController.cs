using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using HETSAPI.Models;
using HETSAPI.Services;
using HETSAPI.Authorization;

namespace HETSAPI.Controllers
{
    /// <summary>
    /// Attachment Controller
    /// </summary>
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class AttachmentController : Controller
    {
        private readonly IAttachmentService _service;

        /// <summary>
        /// Attachment Controller Constructor
        /// </summary>
        public AttachmentController(IAttachmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create bulk attachment records
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Attachment created</response>
        [HttpPost]
        [Route("/api/attachments/bulk")]
        [SwaggerOperation("AttachmentsBulkPost")]
        [RequiresPermission(Permission.Admin)]
        public virtual IActionResult AttachmentsBulkPost([FromBody]Attachment[] items)
        {
            return _service.AttachmentsBulkPostAsync(items);
        }
       
        /// <summary>
        /// Delete attachment
        /// </summary>
        /// <param name="id">id of Attachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>
        [HttpPost]
        [Route("/api/attachments/{id}/delete")]
        [SwaggerOperation("AttachmentsIdDeletePost")]
        [RequiresPermission(Permission.Login)]
        public virtual IActionResult AttachmentsIdDeletePost([FromRoute]int id)
        {
            return _service.AttachmentsIdDeletePostAsync(id);
        }

        /// <summary>
        /// Returns the binary file component of an attachment
        /// </summary>
        /// <param name="id">Attachment Id</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/attachments/{id}/download")]
        [SwaggerOperation("AttachmentsIdDownloadGet")]
        public virtual IActionResult AttachmentsIdDownloadGet([FromRoute]int id)
        {
            return _service.AttachmentsIdDownloadGetAsync(id);
        }
    }
}
