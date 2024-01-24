function saveMarkdown() {
    var markdownTitle = $("#markdownTitle").val();
    var markdownText = $("#markdownText").val();
    var markdownId = $("#markdownId").val();

    if (!markdownText.trim()) {
        alert("Markdown text is empty. Please enter some text.");
        return;
    }
    
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
            console.log("Markdown saved successfully.");
        },
        error: function (error) {
            // Handle error (e.g., show an error message)
            alert("Error saving markdown.");
        }
    });
}