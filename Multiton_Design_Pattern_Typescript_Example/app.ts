


class MailService {
    private constructor() {
        console.log("MailService nesnesi oluþturuldu.")
    }

    private static mailServices: { [key: string]: MailService } = {}
    static getInstance(key: string) {
        if (this.mailServices[key] == null)
            this.mailServices[key] = new MailService();

        const mailService = this.mailServices[key];
        return mailService;
    }

    private _mail: string;
    get mail(): string {
        return this._mail
    }
    set mail(value: string) {
        this._mail = value;
    }

    private _userName: string;
    get userName(): string {
        return this._userName
    }
    set userName(value: string) {
        this._userName = value;
    }

    private _password: string;
    get password(): string {
        return this._password
    }
    set password(value: string) {
        this._password = value;
    }
}

const gmail: MailService = MailService.getInstance("gmail");
const hotmail: MailService = MailService.getInstance("hotmail");
const yandex: MailService = MailService.getInstance("yandex");

gmail.mail = "...";
gmail.password = "...";
gmail.userName = "...";

const gmail2: MailService = MailService.getInstance("gmail");
const hotmail2: MailService = MailService.getInstance("hotmail");
const yandex2: MailService = MailService.getInstance("yandex");

hotmail.mail = "...";
hotmail.password = "...";
hotmail.userName = "...";