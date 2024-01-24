function removeMarkdown(markdownId) {
    if (confirm("Are you sure you want to remove this markdown?")) {
        $.ajax({
            type: "POST",
            url: "/Editor/RemoveMarkdown",
            data: { markdownId: markdownId },
            success: function (data) {
                // Handle success
                console.log("Markdown removed successfully.");

                // Remove the card from the DOM
                $("#markdownCard_" + markdownId).remove();
            },
            error: function (error) {
                // Handle error (e.g., show an error message)
                console.error("Error removing markdown:", error);
                alert("Error removing markdown. Please try again or reload the page.");
            }
        });
    }
}
