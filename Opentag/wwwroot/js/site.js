// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log('Loged hello');



GetLang();

function GetLang() {
    try {
        var CurrentLang = localStorage.getItem('DefaultLanguage');
        if (CurrentLang == "") throw "Empty";
        if (CurrentLang == null) throw "Empty2";
        alert(" ok");
    }
    catch (err) {
        alert(err);
        localStorage.setItem('DefaultLanguage', 'FA');
    }
    
}
var CurrentLang = localStorage.getItem('DefaultLanguage');




let SetLang = false;

//Common class for detecting Different page
let CurrenPage = document.querySelector('.CurrenPageTitle');

//Layout
    // Layout FA/EN
    const mainLayout = document.querySelector('.mainLayout');
    const LangButton = document.querySelector('.LangButton');
    const LangButtonText = document.querySelector('.LangButtonText');

    //Get Nav Header
    const navIndex = document.querySelector('.navIndex');
    const navServices = document.querySelector('.navServices');
    const navOrder = document.querySelector('.navOrder');
    const navAbout = document.querySelector('.navAbout');
    const navContact = document.querySelector('.navContact');

    //Get Nav Footer 
    //Footer Headers
    const footerSiteMap = document.querySelector('.footerSiteMap');
    const footerAbout = document.querySelector('.footerAbout');
    const footerContacts = document.querySelector('.footerContacts');
    //Footer Header Constent
    const footerPhone = document.querySelector('.footerPhone');
    const footerPhoneAtag = document.querySelector('.footerPhoneAtag');
    const footerEmail = document.querySelector('.footerEmail');
    const footerAddress = document.querySelector('.footerAddress');
    const FooterAboutUsMid1 = document.querySelector('.FooterAboutUsMid1');
    const FooterAboutUsMid2 = document.querySelector('.FooterAboutUsMid2');







switch (CurrenPage.textContent) {
    case "1":
        alert("MainPage");
        //Technologies
        var techHeader = document.querySelector('.techHeader');
        var EntityFrameworkBody = document.querySelector('.EntityFrameworkBody');
        var ASPCore = document.querySelector('.ASPCore');
        var MVCDesignpatternHeader = document.querySelector('.MVCDesignpatternHeader');
        var MVCDesignpatternBody = document.querySelector('.MVCDesignpatternBody');
        var BootstrapFramework = document.querySelector('.BootstrapFramework');
        var BootstrapHeader = document.querySelector('.BootstrapFrameworkHeader');
        //About
        var AboutSection = document.querySelector('.AboutSection');
        var AboutSection1 = document.querySelector('.AboutSection1');
        var AboutSection2 = document.querySelector('.AboutSection2');
        var AboutSection3 = document.querySelector('.AboutSection3');
        var AboutSection4 = document.querySelector('.AboutSection4');
        //Contact
        var ContactSection = document.querySelector('.ContactSection');
        var ContactSectionBody = document.querySelector('.ContactSectionBody');
        var ContactFormName = document.querySelector('.ContactFormName');
        var ContactFormEmail = document.querySelector('.ContactFormEmail');
        var ContactFormPhone = document.querySelector('.ContactFormPhone');
        var ContactFormSubject = document.querySelector('.ContactFormSubject');
        var ContactFormMessage = document.querySelector('.ContactFormMessage');
        var ContactFormBtn = document.querySelector('.ContactFormBtn');
        //Services
        var ServicesHeader = document.querySelector('.ServicesHeader');
        var ServicesSupportHeader = document.querySelector('.ServicesSupportHeader');
        var ServicesSupporBodyText01 = document.querySelector('.ServicesSupporBodyText01');
        var ServicesSupporBodyText02 = document.querySelector('.ServicesSupporBodyText02');
        var ServicesSupporBodyText03 = document.querySelector('.ServicesSupporBodyText03');

        var ServicesConsultationHeader = document.querySelector('.ServicesConsultationHeader');
        var ServicesConsultationBodyText01 = document.querySelector('.ServicesConsultationBodyText01');
        var ServicesConsultationBodyText02 = document.querySelector('.ServicesConsultationBodyText02');

        var ServicesSecurityHeader = document.querySelector('.ServicesSecurityHeader');
        var ServicesSecurityBodyText01 = document.querySelector('.ServicesSecurityBodyText01');
        var ServicesSecurityBodyText02 = document.querySelector('.ServicesSecurityBodyText02');
        var ServicesMore01 = document.querySelector('.ServicesMore01');
        var ServicesMore02 = document.querySelector('.ServicesMore02');
        var ServicesMore03 = document.querySelector('.ServicesMore03');

        var MembersHeader = document.querySelector('.MembersHeader');
        var Member01 = document.querySelector('.Member01');
        var Member02 = document.querySelector('.Member02');
        var Member03 = document.querySelector('.Member03');
        var Member04 = document.querySelector('.Member04');
        break;

    case "2":
        //Services page
        alert("2");
        var textall = document.querySelector(".textall")
        var Header = document.querySelector(".Header")
        var Slog = document.querySelector(".Slog")
        var Description = document.querySelector(".Description")
        var ConsultationHeader = document.querySelector(".ConsultationHeader")
        var ConsultationText = document.querySelector(".ConsultationText")
        var SupportHeader = document.querySelector(".SupportHeader")
        var SupportText = document.querySelector(".SupportText")
        var SecurityHeader = document.querySelector(".SecurityHeader")
        var SecurityText = document.querySelector(".SecurityText")



        break;
    case "3":
        //Oreder pafe
        alert("3");
        break;
    case "4":
        //About page
        alert("4");
        break;
    case "5":
        //Contact page
        alert("5");
        break;
    case "6":
        //Oreder pafe
        alert("6");
        break;
    case "7":
        //Oreder pafe
        alert("7");
        break;
    case "8":
        //Oreder pafe
        alert("8");
        break;
    default:
        alert("Default");

}









UpdateLayoutFunc();
UpdateLangFunc();














function UpdateLayoutFunc()
{
    if (CurrentLang == "EN") {

        //EN
        //mainLayout
        mainLayout.classList.remove('myFarsiClass');
        //NavHeader
        LangButtonText.textContent = "FA";
        navIndex.textContent = 'Home';
        navServices.textContent = 'Service';
        navOrder.textContent = 'Order';
        navAbout.textContent = 'About';
        navContact.textContent = 'Contact';
    }
    else if (CurrentLang == "FA") {
        //FA
        //mainLayout
        mainLayout.classList.add('myFarsiClass');
        //NavHeader
        LangButtonText.textContent = "EN";
        navIndex.textContent = 'خانه';
        navServices.textContent = 'سرویس ها';
        navOrder.textContent = 'سفارش';
        navAbout.textContent = 'درباره ما';
        navContact.textContent = 'ارتباط با ما';
    }
}









    
function UpdateLangFunc() {
    if (CurrentLang == "EN"  ) {
        //EN
        //NavFooter
        footerSiteMap.textContent = 'Site Map';
        footerAbout.textContent = 'About';
        footerContacts.textContent = 'Contacts';
        //Footer Header Constent
        footerEmail.textContent = 'Email: info@Vira_DevGroup.ir';
        footerAddress.innerHTML = "Address:<br />Iran<br />Qom<br />Shohada St<br />Commercial Complex Ganjine";
        footerPhoneAtag.textContent = ": Phone";
        /*footerPhone.setAttribute("style", "direction:rtl !important;");*/
        footerEmail.textContent = 'Email : info@Vira_DevGroup.ir';
        FooterAboutUsMid1.textContent = "Our team is interested about builing web apps, mobile apps and game developing over Microsoft practical and usefull Frawmeworks.";
        FooterAboutUsMid2.textContent = "If you are going to help or support programming communities, please follow us.";


        switch (CurrenPage.textContent) {
            case "1":
                alert("EN MainPage");
                //Technologies
                techHeader.textContent = 'Technologies';
                EntityFrameworkBody.textContent = 'Is a technology to support server side codes and bring a powerful secure environment for your web apps.';
                ASPCore.textContent = 'Vira workspace use DotNet Core framework to build and develop cross platform applications over Microsoft technologies.';
                MVCDesignpatternHeader.textContent = 'MVC Design pattern';

                MVCDesignpatternBody.textContent = "Our projects is divided in three separated smart sections, which are related to each other and make programming easier.";
                BootstrapHeader.textContent = "Bootstrap framework";
                BootstrapFramework.textContent = "Frontend developers in Vira team setup views based on Bootstrap framework and many selfmade libraries.";
                //AboutSection
                AboutSection.textContent = "About";
                AboutSection1.textContent = "Our team is interested about building web apps, mobile apps and game developing over Microsoft practical and useful frameworks.";
                AboutSection2.textContent = "If you like to help or support programming communities, please follow us to make world a better place.";
                AboutSection3.textContent = "This is our duty to refer different services to our customers. This will show how much we care about people who care about us.";
                AboutSection4.textContent = "Read more";
                //ContactSection
                ContactSection.textContent = "Contact";
                ContactSectionBody.textContent = "Send us your reviews. It'll help us in development.";
                ContactSectionBody.setAttribute("style", "text-Align: left!important;");
                ContactFormName.setAttribute("placeholder", "Full name");
                ContactFormEmail.setAttribute("placeholder", "Email address");
                ContactFormPhone.setAttribute("placeholder", "Phone number");
                ContactFormSubject.setAttribute("placeholder", "Subject");
                ContactFormMessage.setAttribute("placeholder", "Message");
                ContactFormBtn.textContent = "Send";
                //Services
                ServicesHeader.textContent = "Services";
                ServicesSupportHeader.textContent = "Support";
                ServicesSupporBodyText01.textContent = "It is our responsibility to provide support for products, we developed.";
                ServicesSupporBodyText02.textContent = "We will support our products which produced by our team.";
                ServicesSupporBodyText03.textContent = "Depend on product you have, there is 6 months to 1 year of problem solution support for each plan of web apps designing.";
                ServicesConsultationHeader.textContent = "Free consultation";
                ServicesConsultationBodyText01.textContent = "Different development plans of web applications will be provided to client’s depends on their requirements and purposes.";
                ServicesConsultationBodyText02.textContent = "Due to importance of user experiences deigning of apps, there is a Free consultation of your required goal features to products you need.";

                ServicesSecurityHeader.textContent = "Security";
                ServicesSecurityBodyText01.textContent = "We take care of your information through components dedicated to securing applications products are protected by anti-fishing components of Asp.net core framework.";
                ServicesSecurityBodyText02.textContent = "In addition, there is a secure authentication for web apps which are produced by Microsoft Identity.";

                ServicesMore01.textContent = "Read more";
                ServicesMore02.textContent = "Read more";
                ServicesMore03.textContent = "Read more";

                MembersHeader.textContent = "Members";
                Member01.textContent = "Mohammad javad Najafi";
                Member02.textContent = "Amir hossein Khazaeli";
                Member03.textContent = "Amir hossein sahifi";
                Member04.textContent = "Mohammad javad Zackerian";
                break;

            case "2":
                //Services page
                alert("EN 2");
                textall.setAttribute("style", "text-align: left !important;")
                Header.classList.add('myFarsiClass');
                Header.setAttribute("style", "direction:ltr !important;");
                Header.textContent ="Services";
                Slog.textContent = "Checkout our Services";
                Description.textContent = " Our team is interested about building web apps, mobile apps and game developing over Microsoft practical and useful frameworks.If you like to help or support programming communities, please follow us to make world a better place.This is our duty to refer different services to our customers.This will show how much we care about people who care about us.";
                ConsultationHeader.textContent = "Services";
                ConsultationText.textContent = "This is a sample text for this technology,it's abou it's benefits or how it works.This kind of article shoul be larger then technologies article and also articles image in these kind of article.We should add a read more link to another page,for display more information about the article";
                SupportHeader.textContent = "Support";
                SupportText.textContent = "This is a sample text for this technology,it's abou it's benefits or how it works.This kind of article shoul be larger then technologies article and also articles image in these kind of article.We should add a read more link to another page,for display more information about the article";
                SecurityHeader.textContent = "Free consultation";
                SecurityText.textContent = "This is a sample text for this technology,it's abou it's benefits or how it works.This kind of article shoul be larger then technologies article and also articles image in these kind of article.We should add a read more link to another page,for display more information about the article";

                break;
            case "3":
                //Oreder pafe
                alert("EN 3");
                break;
            case "4":
                //About page
                alert("EN 4");
                break;
            case "5":
                //Contact page
                alert("EN 5");
                break;
            case "6":
                //Oreder pafe
                alert("EN 6");
                break;
            case "7":
                //Oreder pafe
                alert("EN 7");
                break;
            case "8":
                //Oreder pafe
                alert("EN 8");
                break;
            default:
                alert("EN Default");

        }

    }
    else if (CurrentLang == "FA" ) {
        //FA
        //NavFooter
        footerSiteMap.textContent = 'نقشه سایت';
        footerAbout.textContent = 'درباره ما';
        footerContacts.textContent = 'ارتباط با ما';
        //Footer Header Constent
        footerPhoneAtag.textContent = ": شماره تماس";
        footerPhone.setAttribute("style", "direction:ltr !important;");
        footerEmail.textContent = ' پست الکترونیک  : info@Vira_DevGroup.ir ';
        footerAddress.innerHTML = `<a> آدرس :</a></br><a> ایران</a></br><a> قم</a></br><a> خیابان شهدا</a></br><a>مجتمع تجاری گنجینه</a>`;
        FooterAboutUsMid1.textContent = "تیم ما علاقه مند به ساخت برنامه های وب، برنامه های تلفن همراه و توسعه بازی از طریق فریم ورک های کاربردی و مفید مایکروسافت است.";
        FooterAboutUsMid2.textContent = "اگر قصد کمک یا حمایت از جوامع برنامه نویسی را دارید، لطفاً ما را دنبال کنید.";




        switch (CurrenPage.textContent) {
            case "1":
                alert("FA MainPage");
                //Technologies
                techHeader.textContent = 'تکنولوژی';
                EntityFrameworkBody.textContent = 'یک فناوری برای پشتیبانی از کدهای سمت سرور و ایجاد یک محیط امن قدرتمند برای برنامه های وب شما است.';
                ASPCore.textContent = 'فضای کاری Vira از چارچوب DotNet Core برای ساخت و توسعه برنامه های کاربردی متقابل پلتفرم بر روی فناوری های مایکروسافت استفاده می کند.';
                MVCDesignpatternHeader.textContent = 'الگوی طراحی MVC';

                MVCDesignpatternBody.textContent = "پروژه های ما به سه بخش هوشمند مجزا تقسیم می شوند که به یکدیگر مرتبط هستند و برنامه نویسی را آسان می کنند.";
                BootstrapHeader.textContent = "فریم ورک Bootstrap";
                BootstrapFramework.textContent = "توسعه دهندگان فرانت اند در تیم Vira نماها را بر اساس چارچوب بوت استرپ و بسیاری از کتابخانه های خودساخته تنظیم می کنند.";
                //AboutSection
                AboutSection.textContent = "درباره ما";
                AboutSection1.textContent = "تیم ما علاقه مند به ساخت برنامه های وب، برنامه های موبایل و توسعه بازی در چارچوب های کاربردی و مفید مایکروسافت است.";
                AboutSection2.textContent = "اگر دوست دارید به جوامع برنامه نویسی کمک کنید یا از آنها حمایت کنید، لطفا ما را دنبال کنید تا دنیا را به مکانی بهتر تبدیل کنیم.";
                AboutSection3.textContent = "این وظیفه ماست که خدمات مختلف را به مشتریان خود ارجاع دهیم. این نشان می دهد که چقدر به افرادی که به ما اهمیت می دهند اهمیت می دهیم.";
                AboutSection4.textContent = "بیشتر...";
                //ContactSection
                ContactSection.textContent = "تماس با ما";
                ContactSectionBody.textContent = "نظرات خود را برای ما ارسال کنید این به ما در توسعه کمک خواهد کرد.";
                ContactSectionBody.setAttribute("style", "text-Align: right!important;");
                ContactFormName.setAttribute("placeholder", "نام خانوادگی");
                ContactFormEmail.setAttribute("placeholder", "پست الکترونیک");
                ContactFormPhone.setAttribute("placeholder", "شماره تلفن");
                ContactFormSubject.setAttribute("placeholder", "موضوع");
                ContactFormMessage.setAttribute("placeholder", "متن");
                ContactFormBtn.textContent = "ارسال";
                //Services
                ServicesHeader.textContent = "سرویس ها";
                ServicesSupportHeader.textContent = "پشتیبانی";
                ServicesSupporBodyText01.textContent = "این مسئولیت ما است که برای محصولاتی که توسعه داده ایم، پشتیبانی ارائه دهیم.";
                ServicesSupporBodyText02.textContent = "ما از محصولات خود که توسط تیم ما تولید می شود حمایت خواهیم کرد.";
                ServicesSupporBodyText03.textContent = "بسته به محصولی که دارید، 6 ماه تا 1 سال پشتیبانی حل مشکل برای هر طرح طراحی اپلیکیشن های وب وجود دارد.";
                ServicesConsultationHeader.textContent = "مشاوره رایگان";
                ServicesConsultationBodyText01.textContent = "برنامه های مختلف توسعه برنامه های کاربردی تحت وب بسته به نیازها و اهداف آنها به مشتریان ارائه می شود.";
                ServicesConsultationBodyText02.textContent = "با توجه به اهمیت تجربه کاربری در طراحی اپلیکیشن ها، مشاوره رایگان از ویژگی های هدف مورد نیاز شما برای محصولات مورد نیاز شما وجود دارد.";

                ServicesSecurityHeader.textContent = "امنیت";
                ServicesSecurityBodyText01.textContent = "ما از اطلاعات شما از طریق اجزای اختصاص داده شده برای ایمن سازی برنامه ها مراقبت می کنیم. محصولات با اجزای ضد ماهیگیری چارچوب اصلی Asp.net محافظت می شوند.";
                ServicesSecurityBodyText02.textContent = "علاوه بر این، یک احراز هویت امن برای برنامه های وب که توسط Microsoft Identity تولید می شوند وجود دارد.";

                ServicesMore01.textContent = "بیشتر...";
                ServicesMore02.textContent = "بیشتر...";
                ServicesMore03.textContent = "بیشتر...";
                MembersHeader.textContent = "اعضا";
                Member01.textContent = "محمد جواد نجفی";
                Member02.textContent = "امیرحسین خزائلی پور";
                Member03.textContent = "امیرحسین صحیفی";
                Member04.textContent = "محمد جواد ذاکریان";
                break;

            case "2":
                //Services page
                alert("FA 2");
                alert("EN 2");
                textall.setAttribute("style", "text-align: right !important;")
                Header.classList.remove('myFarsiClass');
                Header.setAttribute("style", "direction:rtl !important;");
                Header.textContent = "خدمات";
                Slog.textContent = "خدمات ما را بررسی کنید";
                Description.textContent = " تیم ما علاقه مند به ساخت برنامه های وب، برنامه های تلفن همراه و توسعه بازی در چارچوب های کاربردی و مفید مایکروسافت است.اگر دوست دارید به جوامع برنامه نویسی کمک کنید یا از آنها حمایت کنید، لطفا ما را دنبال کنید تا دنیا را به مکانی بهتر تبدیل کنیم.این وظیفه ماست که خدمات مختلف را به مشتریان خود ارجاع دهیم.این نشان می دهد که چقدر به افرادی که به ما اهمیت می دهند اهمیت می دهیم.";
                ConsultationHeader.textContent = "خدمات";
                ConsultationText.textContent = "این یک متن نمونه برای این فناوری است، در مورد مزایا یا نحوه عملکرد آن است. این نوع مقاله باید بزرگتر از مقاله فناوری و همچنین تصویر مقاله در این نوع مقاله باشد. ما باید یک پیوند خواندن بیشتر به صفحه دیگری اضافه کنیم. نمایش اطلاعات بیشتر در مورد مقاله";
                SupportHeader.textContent = "پشتیبانی";
                SupportText.textContent = "این یک متن نمونه برای این فناوری است، در مورد مزایا یا نحوه عملکرد آن است. این نوع مقاله باید بزرگتر از مقاله فناوری و همچنین تصویر مقاله در این نوع مقاله باشد. ما باید یک پیوند خواندن بیشتر به صفحه دیگری اضافه کنیم. نمایش اطلاعات بیشتر در مورد مقاله";
                SecurityHeader.textContent = "مشاوره رایگان";
                SecurityText.textContent = "این یک متن نمونه برای این فناوری است، در مورد مزایا یا نحوه عملکرد آن است. این نوع مقاله باید بزرگتر از مقاله فناوری و همچنین تصویر مقاله در این نوع مقاله باشد. ما باید یک پیوند خواندن بیشتر به صفحه دیگری اضافه کنیم. نمایش اطلاعات بیشتر در مورد مقاله";

                break;
            case "3":
                //Oreder pafe
                alert("FA 3");
                break;
            case "4":
                //About page
                alert("FA 4");
                break;
            case "5":
                //Contact page
                alert("FA 5");
                break;
            case "6":
                //Oreder pafe
                alert("FA 6");
                break;
            case "7":
                //Oreder pafe
                alert("FA 7");
                break;
            case "8":
                //Oreder pafe
                alert("FA 8");
                break;
            default:
                alert("FA Default");
        }

    }
}






LangButton.addEventListener
    (
        'click',
        () => {
            if (LangButtonText.textContent == "FA") {
                //Change to farsi
                /*alert('EN');*/
                LangButtonText.textContent = "EN";
                localStorage.setItem('DefaultLanguage', 'FA');
                 CurrentLang = localStorage.getItem('DefaultLanguage');
                UpdateLayoutFunc();
                UpdateLangFunc();
            }
            else if (LangButtonText.textContent == "EN") {
                //Change to english
                /*alert('FA');*/
                LangButtonText.textContent = "FA";
                localStorage.setItem('DefaultLanguage', 'EN');
                 CurrentLang = localStorage.getItem('DefaultLanguage');
                UpdateLayoutFunc();
                UpdateLangFunc();


            }
        }

    );





