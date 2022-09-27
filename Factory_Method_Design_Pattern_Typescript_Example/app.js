//Concrete Product
var ASecurity = /** @class */ (function () {
    function ASecurity() {
        console.log("ASecurity nesnesi olu\uFFFDturuldu.");
    }
    return ASecurity;
}());
//Concrete Product
var BSecurity = /** @class */ (function () {
    function BSecurity() {
        console.log("BSecurity nesnesi olu\uFFFDturuldu.");
    }
    return BSecurity;
}());
//Concrete Product
var CSecurity = /** @class */ (function () {
    function CSecurity() {
        console.log("CSecurity nesnesi olu\uFFFDturuldu.");
    }
    return CSecurity;
}());
//Concrete Factory
var ASecurityFactory = /** @class */ (function () {
    function ASecurityFactory() {
    }
    ASecurityFactory.prototype.createInstance = function () {
        return new ASecurity();
    };
    return ASecurityFactory;
}());
//Concrete Factory
var BSecurityFactory = /** @class */ (function () {
    function BSecurityFactory() {
    }
    BSecurityFactory.prototype.createInstance = function () {
        return new BSecurity();
    };
    return BSecurityFactory;
}());
//Concrete Factory
var CSecurityFactory = /** @class */ (function () {
    function CSecurityFactory() {
    }
    CSecurityFactory.prototype.createInstance = function () {
        return new CSecurity();
    };
    return CSecurityFactory;
}());
//Cretor
var SecurityCreator = /** @class */ (function () {
    function SecurityCreator() {
    }
    SecurityCreator.create = function (securityType) {
        var securityFactory = null;
        switch (securityType) {
            case SecurityType.A:
                securityFactory = new ASecurityFactory();
                break;
            case SecurityType.B:
                securityFactory = new BSecurityFactory();
                break;
            case SecurityType.C:
                securityFactory = new CSecurityFactory();
                break;
        }
        return securityFactory.createInstance();
    };
    return SecurityCreator;
}());
var SecurityType;
(function (SecurityType) {
    SecurityType[SecurityType["A"] = 0] = "A";
    SecurityType[SecurityType["B"] = 1] = "B";
    SecurityType[SecurityType["C"] = 2] = "C";
})(SecurityType || (SecurityType = {}));
var a1 = SecurityCreator.create(SecurityType.A);
var b1 = SecurityCreator.create(SecurityType.B);
var c1 = SecurityCreator.create(SecurityType.C);
