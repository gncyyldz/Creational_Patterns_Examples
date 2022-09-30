var X = /** @class */ (function () {
    function X() {
        this._count = 0;
        console.log("X nesnesi �retildi...");
    }
    Object.defineProperty(X.prototype, "count", {
        get: function () { return this._count; },
        set: function (value) { this._count = value; },
        enumerable: false,
        configurable: true
    });
    X.prototype.write = function () { console.log(this._count); };
    return X;
}());
var ObjectPool = /** @class */ (function () {
    function ObjectPool() {
        this._pool = new Array();
    }
    ObjectPool.prototype.get = function (objectGenerator) {
        var instance = this._pool.pop();
        return instance != null ? instance : objectGenerator();
    };
    ObjectPool.prototype["return"] = function (instance) {
        this._pool.push(instance);
    };
    return ObjectPool;
}());
var pool = new ObjectPool();
var x1 = pool.get(function () { return new X(); });
x1.count++;
x1.write();
pool["return"](x1);
var x2 = pool.get(function () { return new X(); });
x2.count++;
x2.write();
pool["return"](x2);
var x3 = pool.get(function () { return new X(); });
x3.count++;
x3.write();
pool["return"](x3);
