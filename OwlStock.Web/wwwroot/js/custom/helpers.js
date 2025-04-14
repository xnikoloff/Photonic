function filterPhotoshootTypeOptions() {
    $(".photoshoot-types-list option").each(function () {
        // Get the text of the current option
        let optionText = $(this).text();
        console.log(optionText);

        // Check if it contains "Plus" or "Extra"
        if (optionText.includes("Plus") || optionText.includes("Extra")) {
            $(this).remove(); // Hide the option
        }
    });
}