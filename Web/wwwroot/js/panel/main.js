$('.custom-dropdown-toggle').click(function() {
    let element = $(this).attr('data-dropdown-toggle');
    $(`[data-dropdown-container="${element}"]`).slideToggle();
});