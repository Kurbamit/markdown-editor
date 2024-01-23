using Microsoft.AspNetCore.Mvc;
using MDEdit.Models;
using MDEdit.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Editor()
        {
            // Assuming you have a service method to get user-specific markdowns
            var userId = Guid.Empty; // Replace with actual user ID when implementing authentication
            var userMarkdowns = await _editorIOService.GetUserMarkdownsAsync(userId);

            return View("MainEditor", userMarkdowns);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMarkdown(string markdownText, string? markdownTitle, Guid markdownId)
        {
            try
            {
                var userId = Guid.Empty; // Change to Guid.Empty for now since there is no user authentication
                
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "ModelState is not valid." });
                }

                await _editorIOService.SaveMarkdownAsync(markdownText, markdownTitle, userId, markdownId);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving markdown");
                return Json(new { success = false, message = "Error saving markdown." });
            }
        }

        public async Task<IActionResult> EditMarkdown(Guid markdownId)
        {
            var (success, markdown) = await _editorIOService.GetMarkdownByIdAsync(markdownId);
            if (!success)
            {
                // Handle the case where the markdown is not found
                return RedirectToAction("Editor");
            }

            return View("EditMarkdown", markdown);
        }
    }
}
