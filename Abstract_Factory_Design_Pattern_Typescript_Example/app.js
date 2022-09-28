var Page = /** @class */ (function () {
    function Page() {
    }
    return Page;
}());
//Concrete Product
var Header = /** @class */ (function () {
    function Header(text) {
        console.log(text);
    }
    return Header;
}());
//Concrete Product
var Body = /** @class */ (function () {
    function Body(text) {
        console.log(text);
    }
    return Body;
}());
//Concrete Product
var Footer = /** @class */ (function () {
    function Footer(text) {
        console.log(text);
    }
    return Footer;
}());
//Concrete Factory
var HomePageFactory = /** @class */ (function () {
    function HomePageFactory() {
    }
    HomePageFactory.prototype.createHeader = function () {
        return new Header("Home sayfas� i�in header olu�turuldu.");
    };
    HomePageFactory.prototype.createBody = function () {
        return new Body("Home sayfas� i�in body olu�turuldu.");
    };
    HomePageFactory.prototype.createFooter = function () {
        return new Footer("Home sayfas� i�in footer olu�turuldu.");
    };
    return HomePageFactory;
}());
//Concrete Factory
var AboutPageFactory = /** @class */ (function () {
    function AboutPageFactory() {
    }
    AboutPageFactory.prototype.createHeader = function () {
        return new Header("About sayfas� i�in header olu�turuldu.");
    };
    AboutPageFactory.prototype.createBody = function () {
        return new Body("About sayfas� i�in body olu�turuldu.");
    };
    AboutPageFactory.prototype.createFooter = function () {
        return new Footer("About sayfas� i�in footer olu�turuldu.");
    };
    return AboutPageFactory;
}());
//Concrete Factory
var ContactPageFactory = /** @class */ (function () {
    function ContactPageFactory() {
    }
    ContactPageFactory.prototype.createHeader = function () {
        return new Header("Contact sayfas� i�in header olu�turuldu.");
    };
    ContactPageFactory.prototype.createBody = function () {
        return new Body("Contact sayfas� i�in body olu�turuldu.");
    };
    ContactPageFactory.prototype.createFooter = function () {
        return new Footer("Contact sayfas� i�in footer olu�turuldu.");
    };
    return ContactPageFactory;
}());
//Creator
var PageCreator = /** @class */ (function () {
    function PageCreator() {
    }
    PageCreator.create = function (pageFactory) {
        var page = new Page();
        page.body = pageFactory.createBody();
        page.footer = pageFactory.createFooter();
        page.header = pageFactory.createHeader();
        return page;
    };
    return PageCreator;
}());
var homePage = PageCreator.create(new HomePageFactory());
homePage.title = "Home";
var aboutPage = PageCreator.create(new AboutPageFactory());
aboutPage.title = "About";
var contact = PageCreator.create(new ContactPageFactory());
contact.title = "Contact";
