var MailService = /** @class */ (function () {
    function MailService() {
        console.log("MailService nesnesi olu�turuldu.");
    }
    MailService.getInstance = function (key) {
        if (this.mailServices[key] == null)
            this.mailServices[key] = new MailService();
        var mailService = this.mailServices[key];
        return mailService;
    };
    Object.defineProperty(MailService.prototype, "mail", {
        get: function () {
            return this._mail;
        },
        set: function (value) {
            this._mail = value;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(MailService.prototype, "userName", {
        get: function () {
            return this._userName;
        },
        set: function (value) {
            this._userName = value;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(MailService.prototype, "password", {
        get: function () {
            return this._password;
        },
        set: function (value) {
            this._password = value;
        },
        enumerable: false,
        configurable: true
    });
    MailService.mailServices = {};
    return MailService;
}());
var gmail = MailService.getInstance("gmail");
var hotmail = MailService.getInstance("hotmail");
var yandex = MailService.getInstance("yandex");
gmail.mail = "...";
gmail.password = "...";
gmail.userName = "...";
var gmail2 = MailService.getInstance("gmail");
var hotmail2 = MailService.getInstance("hotmail");
var yandex2 = MailService.getInstance("yandex");
hotmail.mail = "...";
hotmail.password = "...";
hotmail.userName = "...";
