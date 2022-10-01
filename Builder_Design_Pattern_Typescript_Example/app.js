var YemekTipi;
(function (YemekTipi) {
    YemekTipi[YemekTipi["Sulu"] = 0] = "Sulu";
    YemekTipi[YemekTipi["Etli"] = 1] = "Etli";
    YemekTipi[YemekTipi["Sebzeli"] = 2] = "Sebzeli";
})(YemekTipi || (YemekTipi = {}));
//Concrete Builder
var SuluYemekBuilder = /** @class */ (function () {
    function SuluYemekBuilder() {
        this._yemek = new Yemek();
    }
    SuluYemekBuilder.prototype.setYemekTipi = function () {
        this._yemek.yemekTipi = YemekTipi.Sulu;
        return this;
    };
    SuluYemekBuilder.prototype.setYemekAdi = function () {
        this._yemek.yemekAdi = "Sulu yemek";
        return this;
    };
    SuluYemekBuilder.prototype.setTuzOrani = function () {
        this._yemek.tuzOrani = 3;
        return this;
    };
    return SuluYemekBuilder;
}());
//Concrete Builder
var EtliYemekBuilder = /** @class */ (function () {
    function EtliYemekBuilder() {
        this._yemek = new Yemek();
    }
    EtliYemekBuilder.prototype.setYemekTipi = function () {
        this._yemek.yemekTipi = YemekTipi.Etli;
        return this;
    };
    EtliYemekBuilder.prototype.setYemekAdi = function () {
        this._yemek.yemekAdi = "Etli yemek";
        return this;
    };
    EtliYemekBuilder.prototype.setTuzOrani = function () {
        this._yemek.tuzOrani = 5;
        return this;
    };
    return EtliYemekBuilder;
}());
//Concrete Builder
var SebzeliYemekBuilder = /** @class */ (function () {
    function SebzeliYemekBuilder() {
        this._yemek = new Yemek();
    }
    SebzeliYemekBuilder.prototype.setYemekTipi = function () {
        this._yemek.yemekTipi = YemekTipi.Sebzeli;
        return this;
    };
    SebzeliYemekBuilder.prototype.setYemekAdi = function () {
        this._yemek.yemekAdi = "Sebzeli yemek";
        return this;
    };
    SebzeliYemekBuilder.prototype.setTuzOrani = function () {
        this._yemek.tuzOrani = 1;
        return this;
    };
    return SebzeliYemekBuilder;
}());
//Director
var YemekDirector = /** @class */ (function () {
    function YemekDirector() {
    }
    YemekDirector.prototype.yemekYap = function (yemekBuilder) {
        return yemekBuilder.setTuzOrani()
            .setYemekAdi()
            .setYemekTipi()
            ._yemek;
    };
    return YemekDirector;
}());
//Product
var Yemek = /** @class */ (function () {
    function Yemek() {
    }
    Yemek.prototype.tarifiGoster = function () {
        console.log("Yemek Tipi : ".concat(this.yemekTipi, " -> Yemek Ad\uFFFD : ").concat(this.yemekAdi, " -> Tuz Oran\uFFFD : ").concat(this.tuzOrani));
    };
    return Yemek;
}());
var director = new YemekDirector();
var sulu = director.yemekYap(new SuluYemekBuilder());
var etli = director.yemekYap(new EtliYemekBuilder());
var sebzeli = director.yemekYap(new SebzeliYemekBuilder());
sulu.tarifiGoster();
etli.tarifiGoster();
sebzeli.tarifiGoster();
//const sulu: Yemek = new Yemek();
//sulu.tuzOrani = 3;
//sulu.yemekAdi = "�orba";
//sulu.yemekTipi = YemekTipi.Sulu;
//const etli: Yemek = new Yemek();
//etli.tuzOrani = 3;
//etli.yemekAdi = "Etli Pilav";
//etli.yemekTipi = YemekTipi.Etli;
