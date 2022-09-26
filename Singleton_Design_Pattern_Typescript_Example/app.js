var Database = /** @class */ (function () {
    function Database() {
        this.count = 1;
        console.log("Nesne �retildi");
    }
    Object.defineProperty(Database, "getInstance", {
        get: function () {
            if (this._database == null)
                this._database = new Database();
            return this._database;
        },
        enumerable: false,
        configurable: true
    });
    Database.prototype.connection = function () {
        console.log("Connected");
        console.log(this.count++);
    };
    return Database;
}());
var d1 = Database.getInstance;
d1.connection();
var d2 = Database.getInstance;
d2.connection();
var d3 = Database.getInstance;
d3.connection();
var d4 = Database.getInstance;
d4.connection();
