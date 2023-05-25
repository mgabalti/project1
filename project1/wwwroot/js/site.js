moment.locale("ur");
const i = (a) => {
    var id = document.querySelector(a)
    return id
}
const a = (a) => {
    var all = document.querySelectorAll(a)
    return all
}
function urduDate() {
    var alldate = a('.dateInUr');
    for (let i = 0; i < alldate.length; i++) {
       let rawDate = alldate[i].innerText;
       let engDate = new Date(rawDate);
       var urmonth =  moment(engDate).format("MMMM");
       var uryear =  moment(engDate).format("YY");
       var urday = moment(engDate).format("Do");
        var NewURday = `<span><span class="english">${urday}</span><span class="px-1 fs-6">${urmonth}</span><span class="english">${uryear}</span></span>`
       alldate[i].innerHTML = NewURday;
    }
}
urduDate();

const AppColorThief = () => {
    
    const colorThief = new ColorThief();
    var img = a('.dynamicColor');
    var Apply = a('.colorApplication');
    for (let i = 0; i < img.length; i++) {
        var color = colorThief.getColor(img[i]) + "," + '36%';
        Apply[i].style.backgroundColor = `rgb(${color})`
    }
}

AppColorThief()

$(document).ready(function () {

$('.CustomUpload').dropify();
    $('.summernote').summernote({
        placeholder: 'تفصیل',
        tabsize: 2,
        height: 120,
        toolbar: [
            ['style', ['style']],
            ['font', ['bold', 'underline', 'clear']],
            ['color', ['color']],
            ['fontname', ['fontname','Jameel Noori Nastaleeq']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['table', ['table']],
            ['insert', ['link', 'picture']],
            ['view', ['fullscreen', 'codeview', 'help']]
        ],
        height: 300,                 // set editor height
        minHeight: null,             // set minimum height of editor
        maxHeight: null,             // set maximum height of editor
        focus: true  
    });

});