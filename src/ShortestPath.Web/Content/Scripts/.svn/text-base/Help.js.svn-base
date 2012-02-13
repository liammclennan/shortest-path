

var Help = Help || {};

Help.flashTimeout = 10000;

Help.getHelpIcon = function(tooltipText) {
    var iconHtml = "<img src='/Content/Images/help.png' alt='Help' />";
    return $(iconHtml).addClass("error_icon").spTip(tooltipText);
};

Help.clearIcons = function() {
    $('.error_icon').remove();
};

Help.flashSuccess = function(message) {
    $('.flash').addClass('flash_success').html(message).fadeIn('slow');
    setTimeout(function() { $('.flash').fadeOut('slow'); }, Help.flashTimeout);
};

Help.flashError = function(message) {
    $('.flash').addClass('flash_error').html(message).fadeIn('slow');
    setTimeout(function() { $('.flash').fadeOut('slow'); }, Help.flashTimeout);
};

Help.hideFlash = function() {
    $('.flash').hide();
};