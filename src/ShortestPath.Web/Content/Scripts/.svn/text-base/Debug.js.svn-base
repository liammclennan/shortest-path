
var Debug = function() { };

Debug.Log = function(message) {
    if (window.console && window.console.log) {
        window.console.log(message);
    }
};

Debug.showMembers = function(obj) {
    for (name in obj) {
        Debug.Log(name);
    }
};