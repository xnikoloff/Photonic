function filterPhotoshootTypeOptions() {
    $(".photoshoot-types-list option").each(function () {
        // Get the text of the current option
        let optionText = $(this).text();
        
        // Check if it contains "Plus" or "Extra"
        if (optionText.includes("Plus") || optionText.includes("Extra")) {
            $(this).attr("hidden", true); // Hide the option
        }
    });
}