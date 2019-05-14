
$(window).on('load', function () {

    // animate login & signup fields placeholder
    $('.login_form, .signup_form, .upload_file_modal, .profile_modal').find('input:not([type="submit"]), textarea').on('keyup  blur focus', function (e) {

        var $this = $(this),
            label = $this.prev('label');
        if (e.type === 'keyup' || e.type === 'keydown') {
            if ($this.val() === '') {
                $(this).css({ "height": "44px", "padding": "5px 12px" });
                label.removeClass('active highlight');
            } else {
                $(this).css({ "height": "65px", "padding": "20px 12px 5px 12px" });
                label.addClass('active highlight');
            }
        } else if (e.type === 'blur') {
            if ($this.val() === '') {
                $(this).css({ "height": "44px", "padding": "5px 12px" });
                label.removeClass('active highlight');
            } else {
                $(this).css({ "height": "65px", "padding": "20px 12px 5px 12px" });
                label.removeClass('highlight');
            }
        } else if (e.type === 'focus') {
            if ($this.val() === '') {
                $(this).css({ "height": "44px", "padding": "5px 12px" });
                label.removeClass('highlight');
            }
            else if ($this.val() !== '') {
                $(this).css({ "height": "65px", "padding": "20px 12px 5px 12px" });
                label.addClass('highlight');
            }
        }
    });

    // animate login & signup fields placeholder (fix for reload) 
    $('.login_form, .signup_form, .profile_modal').find('input:not([type="submit"]), textarea').each(function () {
        var $this = $(this),
            label = $this.prev('label');
        if ($this.val() === '') {
            $(this).css({ "height": "44px", "padding": "5px 12px" });
            label.removeClass('active highlight');
        } else {
            $(this).css({ "height": "65px", "padding": "20px 12px 5px 12px" });
            label.addClass('active highlight');
        }
    });


    /* Open & Close Navigation */
    $('.bars').on("click", function () {
        $('.bars .bar').toggleClass('bar-close');
        $('.navbar_circle').toggleClass('navbar_circle_show');
        $('.navbar_circle ol li#nabbar_animate_1').toggleClass('animated fadeInRight');
        $('.navbar_circle ol li#nabbar_animate_2').toggleClass('animated fadeInRight delay-hs');
        $('.navbar_circle ol li#nabbar_animate_3').toggleClass('animated fadeInRight delay-s');

    });

    $(document).mouseup(function (e) {
        var container = $(".navbar_circle");
        var closeBtn = $('.bars');
        var isOpen = $('.navbar_circle').hasClass('navbar_circle_show');
        // if the target of the click isn't the container nor a descendant of the container
        if (!container.is(e.target) && container.has(e.target).length === 0 && isOpen && !closeBtn.is(e.target) && closeBtn.has(e.target).length === 0) {
            $('.bars').click();
        }
    });


    /* Search filter button */
    $('.search_container .filter_btn').on("click", function () {
        $(this).toggleClass('avtive_color');
        $('.search_filters_container').toggleClass('search_filters_container_show');
        $('.search_filters_container').toggleClass('animated flipInX faster');
    });


 

});