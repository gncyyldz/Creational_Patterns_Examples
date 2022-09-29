//Abstract Prototype
abstract class XCloneable {
    abstract clone(): X;
}

//Concrete Prototype
class X implements XCloneable {
    constructor(a: string, b: string, c: number, d: number, y: Y, z: Z, w: W) {
        this._a = a;
        this._b = b;
        this._c = c;
        this._y = y;
        this._z = z;
        this._w = w;
    }

    private _a: string;
    private _b: string;
    private _c: number;
    private _d: number;
    private _y: Y;
    private _z: Z;
    private _w: W;

    get a() { return this._a; }
    set a(value: string) { this._a = value; }

    get b() { return this._b; }
    set b(value: string) { this._b = value; }

    get c() { return this._c; }
    set c(value: number) { this._c = value; }

    get y() { return this._y; }
    set y(value: Y) { this._y = value; }

    get z() { return this._z; }
    set z(value: Z) { this._z = value; }

    get w() { return this._w; }
    set w(value: W) { this._w = value; }

    clone(): X {
        return structuredClone(this) as X;
    }
}


class Y { }
class Z { }
enum W { a, b, c }

const x1: X = new X("example x-a", "example x-b", 1, 2, new Y(), new Z(), W.a);
console.log(x1);

const x2: X = x1.clone();
x2.a = "example x2-a";
console.log(x2);