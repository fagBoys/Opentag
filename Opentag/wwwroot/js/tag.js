const tagsRow = document.querySelector('.tagsRow');
const addTag = document.querySelector('.addTag');
const tagInput = document.querySelector('.tagInput');


let tagCounter = 1;

// // //

addTag.addEventListener('click', e => {

    e.preventDefault();
    const tag = document.createElement('div');
    const toast = document.createElement('div');
    const row = document.createElement('div');
    const toastBody = document.createElement('div');
    const button = document.createElement('button');
    const span = document.createElement('span');
    const input = document.createElement('input');

    input.classList.add('d-none');

    tag.classList.add('col-md-3');
    tag.classList.add('mt-3');
    tag.classList.add('d-flex');
    tag.classList.add('justify-content-between');
    tag.id = tag;

    toast.classList.add('toast');
    toast.classList.add('align-items-center');
    toast.classList.add('text-bg-primary');
    toast.classList.add('border-0');
    toast.classList.add('w-100');
    toast.classList.add('fade');
    toast.classList.add('show');
    toast.classList.add('m-0');
    toast.setAttribute('role', 'alert');
    toast.setAttribute('aria-live', 'assertive');
    toast.setAttribute('aria-atomic', 'true');

    toastBody.textContent = 'Hello';
    toastBody.classList.add('toast-body');
    toastBody.classList.add('p-2');
    toastBody.classList.add('w-100');

    button.setAttribute('type', 'button');
    button.setAttribute('data-dismiss', 'toast');
    button.setAttribute('aria-label', 'Close');
    button.classList.add('mx-2');
    button.classList.add('mx-2');
    button.classList.add('close');

    button.addEventListener('click', e => {
        if(e.target.classList.contains('close'))
        {
            e.target.parentElement.parentElement.parentElement.parentElement.remove();
        }
    });

    span.innerHTML = '&times;';
    span.setAttribute('aria-hidden', 'true');
    span.classList.add('close');


    input.value = tagInput.value;
    input.setAttribute('name', 'NewArticle.Tags');
    toastBody.textContent = tagInput.value;
    button.append(span);
    toastBody.append(button);
    toast.append(toastBody);
    //toast.append(button);
    tag.append(toast);
    tag.append(input);
    tagsRow.append(tag);

    tagCounter++;
    //GetLang()

});

//let closeBtn = document.querySelectorAll('button');

//closeBtn.forEach.addEventListener('click', e => {
//    if (e.target.classList.Contains('close'))
//    {
//        e.target.parentElement.parentElement.remove();
//    }
//});

function GetLang() {
    try {
        let closeBtn = document.querySelector('.close');
        alert(" ok");
        closeBtn.addEventListener('click', e => {
            console.log(e.target);
            alert('hello');
            const m = e.target.parentElement;
            m.remove();
        });
    }
    catch (err) {
        alert(err);
    }

}








//closeBtn.addEventListener('click', e => {
//    console.log(e.target);
//    if (e.target == '.close')
//    {
//        e.ParentElement.ParentElement.remove();
//    }
//});