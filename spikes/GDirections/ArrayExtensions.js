
// predicate is a method that accepts one parameter and returns a boolean.
Array.prototype.where = function(predicate) {
    var derivedArray = [];
    for (i = 0; i < this.length; i += 1) {
        if (predicate(this[i])) {
            derivedArray.push(this[i]);
        }
    }
    return derivedArray;
}

// operation is a method that accepts one parameter and returns a value.
Array.prototype.collect = function(operation) {
    var derivedArray = [];
    for (i = 0; i < this.length; i += 1) {
        derivedArray.push(operation(this[i]));
    }
    return derivedArray;
}