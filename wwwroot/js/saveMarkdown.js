function saveMarkdown() {
    var markdownTitle = $("#markdownTitle").val();
    var markdownText = $("#markdownText").val();
    var markdownId = $("#markdownId").val();

    console.log("Markdown ID in saveMarkdown.js: " + markdownId);
    $.ajax({
        type: "POST",
        url: "/Editor/SaveMarkdown", // Adjust the URL to match your route
        data: { 
            markdownText: markdownText,
            markdownTitle: markdownTitle,
            markdownId: markdownId
        },
        success: function (data) {
            // Handle success (e.g., show a success message)
            alert("Markdown saved successfully!");
        },
        error: function (error) {
            // Handle error (e.g., show an error message)
            alert("Error saving markdown.");
        }
    });
}