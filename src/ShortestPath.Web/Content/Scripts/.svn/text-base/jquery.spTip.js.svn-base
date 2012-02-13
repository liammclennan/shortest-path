
(function($) {

    $.fn.spTip = function(message) {

        return this.each(function() {
            $(this).qtip({
                content: message,
                show: 'mouseover',
                hide: 'mouseout',
                style: {
                    width: 350,
                    padding: 5,
                    textAlign: 'left',
                    border: {
                        width: 4,
                        radius: 3
                    },
                    tip: 'bottomLeft',
                    name: 'blue' // Inherit the rest of the attributes from the preset dark style
                },
                position: {
                    corner: {
                        target: 'topRight',
                        tooltip: 'bottomLeft'
                    }
                }
            });               
                
        });

    };

})(jQuery);
