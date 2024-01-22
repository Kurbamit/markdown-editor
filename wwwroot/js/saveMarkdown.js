function saveMarkdown() {
    var markdownTitle = $("#markdownTitle").val();
    var markdownText = $("#markdownText").val();
    $.ajax({
        type: "POST",
        url: "/Editor/SaveMarkdown", // Adjust the URL to match your route
        data: { 
            markdownText: markdownText,
            markdownTitle: markdownTitle
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