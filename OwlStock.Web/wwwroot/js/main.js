(function ($) {
    "use strict";


    $(window).on('load', function () {
        getCurrentCategory();
        //porfolio filter
        $('.portfolio-menu ul li').removeClass('active');
        $("#cat-" + getCurrentCategory()).addClass('active');
        filter($("#cat-" + getCurrentCategory()));

        $('.portfolio-menu ul li').click(function () {
            $('.portfolio-menu ul li').removeClass('active');
            $(this).addClass('active');

            filter($(this));
        });

        var popup_btn = $('.popup-btn');
        popup_btn.magnificPopup({
            type: 'image',
            gallery: {
                enabled: true
            }
        });
    });

    // Spinner
    var spinner = function () {
        setTimeout(function () {
            if ($('#spinner').length > 0) {
                $('#spinner').removeClass('show');
            }
        }, 1);
    };
    spinner();
    
    
    // Initiate the wowjs
    new WOW().init();


    // Sticky Navbar
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('.sticky-top').addClass('shadow-sm').css('top', '0px');
        } else {
            $('.sticky-top').removeClass('shadow-sm').css('top', '-100px');
        }
    });
    
    
    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({scrollTop: 0}, 1500, 'easeInOutExpo');
        return false;
    });


    // Facts counter
    $('[data-toggle="counter-up"]').counterUp({
        delay: 10,
        time: 2000
    });


    // Date and time picker
    $('.date').datetimepicker({
        format: 'L'
    });
    $('.time').datetimepicker({
        format: 'LT'
    });


    // Header carousel
    $(".header-carousel").owlCarousel({
        autoplay: true,
        autoplayTimeout: 5000,
        smartSpeed: 1500,
        loop: true,
        nav: false,
        dots: false,
        items: 1,
        dotsData: true,
    });


    // Testimonials carousel
    $('.testimonial-carousel').owlCarousel({
        autoplay: false,
        smartSpeed: 1000,
        loop: false,
        nav: false,
        dots: true,
        items: 1,
        dotsData: true,
    });

    
})(jQuery);

// Set Stars Rating for Testimony
function setStarsRating(rating) {
    $("#Stars").val(parseInt(rating));
}


//portfolio filter
function filter(element) {
    var selector = element.attr('data-filter');
    if(selector === "*") {
        selector = "";
    }
    $('.portfolio-item').isotope({
        filter: selector,
        percentPosition: true,
        masonry: {
            columnWidth: '.grid-sizer'
        }
    });
    return false;
}

function getCurrentCategory() {
    let category = $("#portfolioCategoryDescription").val();
    
    if (category) {
        return category.toLowerCase();
    }

    return "";
}
