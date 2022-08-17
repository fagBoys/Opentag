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
        var OrderCol = document.querySelector(".OrderCol")
        var OrderHeader = document.querySelector(".OrderHeader")
        var OrderHeader2 = document.querySelector(".OrderHeader2")
        var OrderDscription = document.querySelector(".OrderDscription")
        var PlantHeaderStandard = document.querySelector(".PlantHeaderStandard")
        var PlantPriceStandard = document.querySelector(".PlantPriceStandard")
        var PlantText1Standard = document.querySelector(".PlantText1Standard")
        var PlantText2Standard = document.querySelector(".PlantText2Standard")
        var PlantText3Standard = document.querySelector(".PlantText3Standard")
        var PlantText4Standard = document.querySelector(".PlantText4Standard")

        var PlantHeaderPremium = document.querySelector(".PlantHeaderPremium")
        var PlantPricePremium = document.querySelector(".PlantPricePremium")
        var PlantText1Premium = document.querySelector(".PlantText1Premium")
        var PlantText2Premium = document.querySelector(".PlantText2Premium")
        var PlantText3Premium = document.querySelector(".PlantText3Premium")
        var PlantText4Premium = document.querySelector(".PlantText4Premium")
        var PlantText5Premium = document.querySelector(".PlantText5Premium")
        var PlantText6Premium = document.querySelector(".PlantText6Premium")

        var PlantHeaderGold = document.querySelector(".PlantHeaderGold")
        var PlantPriceGold = document.querySelector(".PlantPriceGold")
        var PlantText1Gold = document.querySelector(".PlantText1Gold")
        var PlantText2Gold = document.querySelector(".PlantText2Gold")
        var PlantText3Gold = document.querySelector(".PlantText3Gold")
        var PlantText4Gold = document.querySelector(".PlantText4Gold")

        var Plan1 = document.querySelector(".Plan1")
        var Plan2 = document.querySelector(".Plan2")
        var Plan3 = document.querySelector(".Plan3")

        var Plan1Text1 = document.querySelector(".Plan1Text1")
        var Plan2Text1 = document.querySelector(".Plan2Text1")
        var Plan3Text1 = document.querySelector(".Plan3Text1")

        var Plan1Text2 = document.querySelector(".Plan1Text2")
        var Plan2Text2 = document.querySelector(".Plan2Text2")
        var Plan3Text2 = document.querySelector(".Plan3Text2")

        var Plan1Text3 = document.querySelector(".Plan1Text3")
        var Plan2Text3 = document.querySelector(".Plan2Text3")
        var Plan3Text3 = document.querySelector(".Plan3Text3")


        var Plan1Text4 = document.querySelector(".Plan1Text4")
        var Plan2Text4 = document.querySelector(".Plan2Text4")
        var Plan3Text4 = document.querySelector(".Plan3Text4")

        var Plan1Text5 = document.querySelector(".Plan1Text5")
        var Plan2Text5 = document.querySelector(".Plan2Text5")
        var Plan3Text5 = document.querySelector(".Plan3Text5")

        var Plan1Text6 = document.querySelector(".Plan1Text6")
        var Plan2Text6 = document.querySelector(".Plan2Text6")
        var Plan3Text6 = document.querySelector(".Plan3Text6")






        break;
    case "4":
        //About page
        alert("4");
        var AboutAll1 = document.querySelector(".AboutAll1");
        var AboutHeader = document.querySelector(".AboutHeader");
        var AboutDescription = document.querySelector(".AboutDescription");
        var AboutText1 = document.querySelector(".AboutText1");
        var AboutText2 = document.querySelector(".AboutText2");
        var AboutText3 = document.querySelector(".AboutText3");
        var AboutText4 = document.querySelector(".AboutText4");

        var AboutText51 = document.querySelector(".AboutText51");
        var AboutText52 = document.querySelector(".AboutText52");
        var AboutText53 = document.querySelector(".AboutText53");


        var AboutText61 = document.querySelector(".AboutText61");
        var AboutText62 = document.querySelector(".AboutText62");
        var AboutText63 = document.querySelector(".AboutText63");

        var AboutMember = document.querySelector(".AboutMember");
        var AboutMember1 = document.querySelector(".AboutMember1");
        var AboutMember2 = document.querySelector(".AboutMember2");
        var AboutMember3 = document.querySelector(".AboutMember3");
        var AboutMember4 = document.querySelector(".AboutMember4");






        


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
                ConsultationHeader.textContent = "Security";
                ConsultationText.textContent = "Another important task to implementation of web and mobile apps is providing the modern security services in order of system secure management. Imagination on the contrary, many companies failure to comply with the principles of development. However, our team with the interest of programming knowledge and using modern tools in system security field, provide a powerful software platform for your product.";
                SupportHeader.textContent = "Support";
                SupportText.textContent = "One of the most important services in the matter of production and development of software which should considered is the support services. Services such as support helps providing high product quality by developers  team. On the other side, lack of  software observation services during users interaction will be caused to bugs or problems on final product.";
                SecurityHeader.textContent = "Free consultation";
                SecurityText.textContent = "According to employers demands difference, free consultation services helps to better issue understanding and also offering proper suggestion according to required needs of employer and order easy decision making. Vira consultation services with offering suggested proposal, exclusive user interface designing, introducing development and production tools and system analysis tries to eliminating ambiguity of suggested product.";

                break;
            case "3":
                //Oreder page
                alert("EN 3");
                OrderCol.setAttribute("style", "text-align: left !important; margin-top: 150px;");
                OrderHeader.textContent = "Order";
                OrderHeader2.textContent = "Contact us through this form";
                OrderDscription.textContent = "We will provide different order plan for your business. It's our reponsibility to make our customers satisfied. At the time we have two order plans:";
                PlantHeaderStandard.textContent = "Standard";
                PlantPriceStandard.textContent = "599$";
                PlantText1Standard.textContent = "6 month support";
                PlantText2Standard.textContent = "UI/UX design";
                PlantText3Standard.textContent = "Logo designing";
                PlantText4Standard.textContent = "Administrator panel";

                PlantHeaderPremium.textContent = "Premium";
                PlantPricePremium.textContent = "999$";
                PlantText1Premium.textContent = "1 year support";
                PlantText2Premium.textContent = "UI/UX design (3 samples)";
                PlantText3Premium.textContent = "Logo designing";
                PlantText4Premium.textContent = "Administrator panel";
                PlantText5Premium.textContent = "Host & domain";
                PlantText6Premium.textContent = "Premium images";

                PlantHeaderGold.textContent = "GOLD";
                PlantPriceGold.textContent = "1499$";
                PlantText1Gold.textContent = "6 month support";
                PlantText2Gold.textContent = "UI/UX design";
                PlantText3Gold.textContent = "Logo designing";
                PlantText4Gold.textContent = "Administrator panel";

                Plan1.textContent = "Standard";
                Plan2.textContent = "Premium";
                Plan3.textContent = "GOLD";

                Plan1Text1.textContent = " 6 month support ";
                Plan2Text1.textContent = " 1 year support ";
                Plan3Text1.textContent = "1 year support";

                Plan1Text2.textContent = " UI/UX design	";
                Plan2Text2.textContent = "UI/UX design (3 samples)";
                Plan3Text2.textContent = "UI/UX design (3 samples)";

                Plan1Text3.textContent = " Logo designing ";
                Plan2Text3.textContent = " Logo designing ";
                Plan3Text3.textContent = " Logo designing ";

                Plan1Text4.textContent = "  Administrator panel  ";
                Plan2Text4.textContent = "  Administrator panel  ";
                Plan3Text4.textContent = "  Administrator panel  ";

                Plan1Text5.textContent = " Host & domain ";
                Plan2Text5.textContent = " Host & domain ";
                Plan3Text5.textContent = " Host & domain ";

                Plan1Text6.textContent = " Premium images ";
                Plan2Text6.textContent = " Premium images ";
                Plan3Text6.textContent = " Premium images ";

                break;
            case "4":
                //About page
                alert("EN 4");
                AboutAll1.setAttribute("style", "text-align: left !important; ");

                AboutHeader.textContent = "About";
                AboutDescription.textContent = "About our company";
                AboutText1.textContent = "Our team is interested about building web apps, mobile apps and game developing over Microsoft practical and useful frameworks.";
                AboutText2.textContent = "If you like to help or support programming communities, please follow us to make world a better place.";
                AboutText3.textContent = "This is our duty to refer different services to our customers. This will show how much we care about people who care about us.";
                AboutText4.textContent = "Read more";

                AboutText51.textContent = "For read more about our";
                AboutText52.textContent = "Services";
                AboutText53.textContent = "press this link.";


                AboutText61.textContent = "For more Information";
                AboutText62.textContent = " contact us";
                AboutText63.textContent = "and we will response soon.";

                AboutMember.textContent = "Members";
                AboutMember1.textContent = "Mohammad javad Najafi";
                AboutMember2.textContent = "Amir hossein Khazaeli";
                AboutMember3.textContent = "Amir hossein sahifi";
                AboutMember4.textContent = "Mohammad javad Zackerian";



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
                ConsultationHeader.textContent = "امنیت";
                ConsultationText.textContent = "یکی دیگر از وظایف مهم پیاده سازی اپلیکیشن های تحت وب و موبایل، ارائه خدمات امنیتی مدرن به منظور مدیریت ایمن سیستم است. بر خلاف تصور، بسیاری از شرکت ها در رعایت این اصول شکست می خورند. اما تیم ما با علاقه به دانش برنامه نویسی و استفاده از ابزارهای مدرن در زمینه امنیت سیستم، بستر نرم افزاری قدرتمندی را برای محصول شما فراهم می کند.";
                SupportHeader.textContent = "پشتیبانی";
                SupportText.textContent = "یکی از مهمترین خدمات در امر تولید و توسعه نرم افزار که باید مورد توجه قرار گیرد خدمات پشتیبانی می باشد. خدماتی مانند پشتیبانی به ارائه کیفیت بالای محصول توسط تیم توسعه دهندگان کمک می کند. از سوی دیگر، عدم وجود سرویس‌های مشاهده نرم‌افزاری در هنگام تعامل با کاربران، باعث ایجاد باگ یا مشکلاتی در محصول نهایی می‌شود.";
                SecurityHeader.textContent = "مشاوره رایگان";
                SecurityText.textContent = "با توجه به تفاوت خواسته های کارفرمایان، خدمات مشاوره رایگان به درک بهتر موضوع و همچنین ارائه پیشنهاد مناسب با توجه به نیازهای مورد نیاز کارفرما و سفارش آسان تصمیم گیری کمک می کند. خدمات مشاوره ویرا با ارائه پروپوزال پیشنهادی، طراحی رابط کاربری انحصاری، معرفی ابزارهای توسعه و تولید و تحلیل سیستم سعی در رفع ابهام محصول پیشنهادی دارد.";

                break;
            case "3":
                //Oreder page
                alert("FA 3");
                OrderCol.setAttribute("style", "text-align: right !important; margin-top: 150px;");
                OrderHeader.textContent = "سفارش";
                OrderHeader2.textContent = "از طریق این فرم با ما تماس بگیرید";
                OrderDscription.textContent = "ما طرح سفارش متفاوتی را برای کسب و کار شما ارائه خواهیم کرد. این وظیفه ماست که مشتریان خود را راضی کنیم. در حال حاضر ما دو برنامه سفارش داریم:";
                PlantHeaderStandard.textContent = "استاندارد";
                PlantPriceStandard.textContent = "4,900,000 تومان"; 
                PlantText1Standard.textContent = "پشتیبانی 6 ماهه";
                PlantText2Standard.textContent = "طراحی UI/UX";
                PlantText3Standard.textContent = "طراحی لوگو";
                PlantText4Standard.textContent = "پنل مدیریت";

                PlantHeaderPremium.textContent = "نقره ای";
                PlantPricePremium.textContent = "7,900,000 تومان";
                PlantText1Premium.textContent = "پشتیبانی 1 ساله";
                PlantText2Premium.textContent = "طراحی UI/UX (3 نمونه)";
                PlantText3Premium.textContent = "طراحی لوگو";
                PlantText4Premium.textContent = "پنل مدیریت";
                PlantText5Premium.textContent = "هاست و دامنه";
                PlantText6Premium.textContent = "استفاده از عکس های اختصاصی";

                PlantHeaderGold.textContent = "طلایی";
                PlantPriceGold.textContent = "39,900,000 تومان";
                PlantText1Gold.textContent = "پشتیبانی 6 ماهه";
                PlantText2Gold.textContent = "طراحی UI/UX";
                PlantText3Gold.textContent = "طراحی لوگو";
                PlantText4Gold.textContent = "پنل مدیریت";

                Plan1.textContent = "استاندارد";
                Plan2.textContent = "نقره ای";
                Plan3.textContent = "طلایی";

                Plan1Text1.textContent = " پشتیبانی 6 ماهه ";
                Plan2Text1.textContent = " پشتیبانی 1 ساله ";
                Plan3Text1.textContent = "پشتیبانی 1 ساله";

                Plan1Text2.textContent = " طراحی UI/UX	";
                Plan2Text2.textContent = "طراحی UI/UX (3 نمونه)";
                Plan3Text2.textContent = "طراحی UI/UX (3 نمونه)";

                Plan1Text3.textContent = "طراحی لوگو";
                Plan2Text3.textContent = "طراحی لوگو";
                Plan3Text3.textContent = "طراحی لوگو";

                Plan1Text4.textContent = "  پنل مدریت  ";
                Plan2Text4.textContent = "  پنل مدریت   ";
                Plan3Text4.textContent = "  پنل مدریت   ";

                Plan1Text5.textContent = " هاست و دامنه ";
                Plan2Text5.textContent = " هاست و دامنه ";
                Plan3Text5.textContent = " هاست و دامنه ";

                Plan1Text6.textContent = "تصاویر ممتاز";
                Plan2Text6.textContent = "تصاویر ممتاز";
                Plan3Text6.textContent = "تصاویر ممتاز";


                break;
            case "4":
                //About page
                alert("FA 4");

                AboutAll1.setAttribute("style", "text-align: right !important; ");
                AboutHeader.textContent = "در باره ما";
                AboutDescription.textContent = "درباره شرکت ما";
                AboutText1.textContent = "تیم ما علاقه مند به ساخت برنامه های وب، برنامه های موبایل و توسعه بازی در چارچوب های کاربردی و مفید مایکروسافت است.";
                AboutText2.textContent = "اگر دوست دارید به جوامع برنامه نویسی کمک کنید یا از آنها حمایت کنید، لطفا ما را دنبال کنید تا دنیا را به مکانی بهتر تبدیل کنیم.";
                AboutText3.textContent = "این وظیفه ماست که خدمات مختلف را به مشتریان خود ارجاع دهیم. این نشان می دهد که چقدر به افرادی که به ما اهمیت می دهند اهمیت می دهیم.";
                AboutText4.textContent = "ادامه مطلب";

                AboutText51.textContent = "برای اطلاعات بیشتر در مورد ما";
                AboutText52.textContent = "خدمات";
                AboutText53.textContent = "این لینک را فشار دهید.";


                AboutText61.textContent = "برای اطلاعات بیشتر";
                AboutText62.textContent = " با ما تماس بگیرید";
                AboutText63.textContent = "و به زودی پاسخ خواهیم داد.";

                AboutMember.textContent = "اعضا";
                AboutMember1.textContent = "محمد جواد نجفی";
                AboutMember2.textContent = "امیرحسین خزائلی";
                AboutMember3.textContent = "امیرحسین صحیفی";
                AboutMember4.textContent = "محمد جواد ذاکریان";

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





