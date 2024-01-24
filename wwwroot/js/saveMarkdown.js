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
        url: "/Editor/SaveMarkdown",
        data: { 
            markdownText: markdownText,
            markdownTitle: markdownTitle,
            markdownId: markdownId
        },
        success: function (data) {
            // Handle success (e.g., show a success message)
            console.log("Markdown saved successfully.");
        
            // Clear Title and Markdown Text inputs
            $("#markdownTitle").val('');
            $("#markdownText").val('');
        
            // Check if the server response contains a redirect URL
            if (data.redirectUrl) {
                // Redirect to the specified URL
                window.location.href = data.redirectUrl;
            }
        },
        error: function (error) {
            // Handle error (e.g., show an error message)
            alert("Error saving markdown.");
        }
    });
}
