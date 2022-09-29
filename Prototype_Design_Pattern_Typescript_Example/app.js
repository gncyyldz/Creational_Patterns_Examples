//Abstract Prototype
var XCloneable = /** @class */ (function () {
    function XCloneable() {
    }
    return XCloneable;
}());
//Concrete Prototype
var X = /** @class */ (function () {
    function X(a, b, c, d, y, z, w) {
        this._a = a;
        this._b = b;
        this._c = c;
        this._y = y;
        this._z = z;
        this._w = w;
    }
    Object.defineProperty(X.prototype, "a", {
        get: function () { return this._a; },
        set: function (value) { this._a = value; },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(X.prototype, "b", {
        get: function () { return this._b; },
        set: function (value) { this._b = value; },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(X.prototype, "c", {
        get: function () { return this._c; },
        set: function (value) { this._c = value; },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(X.prototype, "y", {
        get: function () { return this._y; },
        set: function (value) { this._y = value; },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(X.prototype, "z", {
        get: function () { return this._z; },
        set: function (value) { this._z = value; },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(X.prototype, "w", {
        get: function () { return this._w; },
        set: function (value) { this._w = value; },
        enumerable: false,
        configurable: true
    });
    X.prototype.clone = function () {
        return structuredClone(this);
    };
    return X;
}());
var Y = /** @class */ (function () {
    function Y() {
    }
    return Y;
}());
var Z = /** @class */ (function () {
    function Z() {
    }
    return Z;
}());
var W;
(function (W) {
    W[W["a"] = 0] = "a";
    W[W["b"] = 1] = "b";
    W[W["c"] = 2] = "c";
})(W || (W = {}));
var x1 = new X("example x-a", "example x-b", 1, 2, new Y(), new Z(), W.a);
console.log(x1);
var x2 = x1.clone();
x2.a = "example x2-a";
console.log(x2);
