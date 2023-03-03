var darkmode = localStorage.getItem('darkMode');
console.log(darkmode);
 
function execute() {
    if (darkmode == 'true') {
        var element = document.body;
        element.classList.toggle("dark");
        console.log("Darkmode set!")
    }
    else {
        console.log("Darkmode not set")
    }
};

function myFunction() {
    var element = document.body;
    element.classList.toggle("dark");

    darkmode = localStorage.getItem('darkMode')
    switch (darkmode) {
        case 'true':
            console.log('Darkmode is on | ' + localStorage.getItem('darkMode'));
            localStorage.setItem('darkMode', 'false')
            break;
        case 'false':
            console.log('Darkmode is off | ' + localStorage.getItem('darkMode'));
            localStorage.setItem('darkMode', 'true')
            break;
        default:
            console.log(localStorage.getItem('darkMode'));
            localStorage.setItem('darkMode', 'true')
            break;
    }
}