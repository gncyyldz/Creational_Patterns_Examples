


class Page {
    title: string;

    header: IHeader;
    body: IBody;
    footer: IFooter;
}

//Abstract Product
interface IHeader { }

//Abstract Product
interface IBody { }

//Abstract Product
interface IFooter { }


//Concrete Product
class Header implements IHeader {
    constructor(text) { console.log(text) }
}

//Concrete Product
class Body implements IBody {
    constructor(text) { console.log(text) }
}

//Concrete Product
class Footer implements IFooter {
    constructor(text) { console.log(text) }
}

//Abstract Factory
interface IPageFactory {
    createHeader(): IHeader;
    createBody(): IBody;
    createFooter(): IFooter;
}

//Concrete Factory
class HomePageFactory implements IPageFactory {
    createHeader(): IHeader {
        return new Header("Home sayfasý için header oluþturuldu.");
    }
    createBody(): IBody {
        return new Body("Home sayfasý için body oluþturuldu.");
    }
    createFooter(): IFooter {
        return new Footer("Home sayfasý için footer oluþturuldu.");
    }
}

//Concrete Factory
class AboutPageFactory implements IPageFactory {
    createHeader(): IHeader {
        return new Header("About sayfasý için header oluþturuldu.");
    }
    createBody(): IBody {
        return new Body("About sayfasý için body oluþturuldu.");
    }
    createFooter(): IFooter {
        return new Footer("About sayfasý için footer oluþturuldu.");
    }
}

//Concrete Factory
class ContactPageFactory implements IPageFactory {
    createHeader(): IHeader {
        return new Header("Contact sayfasý için header oluþturuldu.");
    }
    createBody(): IBody {
        return new Body("Contact sayfasý için body oluþturuldu.");
    }
    createFooter(): IFooter {
        return new Footer("Contact sayfasý için footer oluþturuldu.");
    }
}

//Creator

class PageCreator {
    static create(pageFactory: IPageFactory): Page {
        const page: Page = new Page();
        page.body = pageFactory.createBody();
        page.footer = pageFactory.createFooter();
        page.header = pageFactory.createHeader();
        return page;
    }
}


const homePage: Page = PageCreator.create(new HomePageFactory());
homePage.title = "Home";

const aboutPage: Page = PageCreator.create(new AboutPageFactory());
aboutPage.title = "About";

const contact: Page = PageCreator.create(new ContactPageFactory());
contact.title = "Contact";