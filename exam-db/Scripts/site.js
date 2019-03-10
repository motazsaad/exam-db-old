
$(window).on('load', function () {

    $('.login_form').find('input:not([type="submit"]), textarea').on('load', function (e) {

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


    // animate login & signup fields placeholder
    $('.login_form').find('input:not([type="submit"]), textarea').on('keyup  blur focus', function (e) {

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

   
});