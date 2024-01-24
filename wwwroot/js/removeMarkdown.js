function removeMarkdown(markdownId) {
    if (confirm("Are you sure you want to remove this markdown?")) {
        $.ajax({
            type: "POST",
            url: "/Editor/RemoveMarkdown",
            data: { markdownId: markdownId },
            success: function (data) {
                // Handle success (e.g., update UI)
                console.log("Markdown removed.");
            },
            error: function (error) {
                // Handle error (e.g., show an error message)
                alert("Error removing markdown.");
            }
        });
    }
}