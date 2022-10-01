
enum YemekTipi {
    Sulu, Etli, Sebzeli
}
//Abstract Builder
interface IYemekBuilder {
    _yemek: Yemek;

    setYemekTipi(): IYemekBuilder;
    setYemekAdi(): IYemekBuilder;
    setTuzOrani(): IYemekBuilder;
}

//Concrete Builder
class SuluYemekBuilder implements IYemekBuilder {
    _yemek: Yemek = new Yemek();

    setYemekTipi(): IYemekBuilder {
        this._yemek.yemekTipi = YemekTipi.Sulu;
        return this;
    }
    setYemekAdi(): IYemekBuilder {
        this._yemek.yemekAdi = "Sulu yemek";
        return this;
    }
    setTuzOrani(): IYemekBuilder {
        this._yemek.tuzOrani = 3;
        return this;
    }
}
//Concrete Builder
class EtliYemekBuilder implements IYemekBuilder {
    _yemek: Yemek = new Yemek();

    setYemekTipi(): IYemekBuilder {
        this._yemek.yemekTipi = YemekTipi.Etli;
        return this;
    }
    setYemekAdi(): IYemekBuilder {
        this._yemek.yemekAdi = "Etli yemek";
        return this;
    }
    setTuzOrani(): IYemekBuilder {
        this._yemek.tuzOrani = 5;
        return this;
    }
}
//Concrete Builder
class SebzeliYemekBuilder implements IYemekBuilder {
    _yemek: Yemek = new Yemek();

    setYemekTipi(): IYemekBuilder {
        this._yemek.yemekTipi = YemekTipi.Sebzeli;
        return this;
    }
    setYemekAdi(): IYemekBuilder {
        this._yemek.yemekAdi = "Sebzeli yemek";
        return this;
    }
    setTuzOrani(): IYemekBuilder {
        this._yemek.tuzOrani = 1;
        return this;
    }
}

//Director

class YemekDirector {
    yemekYap(yemekBuilder: IYemekBuilder): Yemek {
        return yemekBuilder.setTuzOrani()
            .setYemekAdi()
            .setYemekTipi()
            ._yemek;
    }
}


//Product
class Yemek {
    yemekTipi: YemekTipi;
    yemekAdi: string;
    tuzOrani: number;

    tarifiGoster() {
        console.log(`Yemek Tipi : ${this.yemekTipi} -> Yemek Adý : ${this.yemekAdi} -> Tuz Oraný : ${this.tuzOrani}`)
    }
}

const director: YemekDirector = new YemekDirector();
const sulu = director.yemekYap(new SuluYemekBuilder());
const etli = director.yemekYap(new EtliYemekBuilder());
const sebzeli = director.yemekYap(new SebzeliYemekBuilder());

sulu.tarifiGoster();
etli.tarifiGoster();
sebzeli.tarifiGoster();

//const sulu: Yemek = new Yemek();
//sulu.tuzOrani = 3;
//sulu.yemekAdi = "Çorba";
//sulu.yemekTipi = YemekTipi.Sulu;

//const etli: Yemek = new Yemek();
//etli.tuzOrani = 3;
//etli.yemekAdi = "Etli Pilav";
//etli.yemekTipi = YemekTipi.Etli;