// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log('Loged hello');

// Layout FA/EN
const mainLayout = document.querySelector('.mainLayout');

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
const footerEmail = document.querySelector('.footerEmail');
const footerAddress = document.querySelector('.footerAddress');







//mainLyout
mainLayout.classList.remove('myFarsiClass');
mainLayout.classList.add('myFarsiClass');


//NavHeader
//EN
navIndex.textContent = 'Home';
navServices.textContent = 'Service';
navOrder.textContent = 'Order';
navAbout.textContent = 'About';
navContact.textContent = 'Contact';
//FA
navIndex.textContent = 'خانه';
navServices.textContent = 'سرویس ها';
navOrder.textContent = 'سفارش';
navAbout.textContent = 'درباره ما';
navContact.textContent = 'ارتباط با ما';


//NavFooter
    //EN
    footerSiteMap.textContent = 'Site Map';
    footerAbout.textContent = 'About';
    footerContacts.textContent = 'Contacts';
    //FA
    footerSiteMap.textContent = 'نقشه سایت';
    footerAbout.textContent = 'درباره ما';
    footerContacts.textContent = 'ارتباط با ما';

//Footer Header Constent
//EN
footerEmail.textContent = 'Email: N a m e@M a i l . c o m';
footerAddress.innerHTML = "Address:<br />Iran<br />Qom<br />Shohada St<br />Commercial Complex Ganjine";
//FA

footerEmail.textContent = 'ارتباط با ما';
footerAddress.textContent = 'ارتباط با ما';




                    
