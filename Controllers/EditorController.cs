using Microsoft.AspNetCore.Mvc;
using MDEdit.Models;
using MDEdit.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace MDEdit.Controllers
{
    public class EditorController : Controller
    {
        private readonly ILogger<EditorController> _logger;
        private readonly IEditorIOService _editorIOService;

        public EditorController(ILogger<EditorController> logger, IEditorIOService editorIOService)
        {
            _logger = logger;
            _editorIOService = editorIOService;
        }
    
        public IActionResult Editor()
        {
            return View("MainEditor");
        }

        [HttpPost]
        public async Task<IActionResult> SaveMarkdown(string markdownText, string? markdownTitle)
        {
            try
            {
                var userId = Guid.Empty; // Change to Guid.Empty for now since there is no user authentication

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "ModelState is not valid." });
                }

                await _editorIOService.SaveMarkdownAsync(markdownText, markdownTitle, userId);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving markdown");
                return Json(new { success = false, message = "Error saving markdown." });
            }
        }
    }
}