
class X {
    constructor() { console.log("X nesnesi üretildi...") }
    private _count: number = 0;
    get count(): number { return this._count; }
    set count(value: number) { this._count = value; }
    write() { console.log(this._count) }
}


class ObjectPool<T> {
    private _pool: Array<T> = new Array<T>();
    get(objectGenerator: () => T): T {
        const instance: T = this._pool.pop();
        return instance != null ? instance : objectGenerator();
    }
    return(instance: T) {
        this._pool.push(instance);
    }
}

const pool: ObjectPool<X> = new ObjectPool<X>();
const x1: X = pool.get(() => new X());
x1.count++;
x1.write();
pool.return(x1);

const x2: X = pool.get(() => new X());
x2.count++;
x2.write();
pool.return(x2);

const x3: X = pool.get(() => new X());
x3.count++;
x3.write();
pool.return(x3);