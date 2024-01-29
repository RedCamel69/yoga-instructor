export function onPageScroll(interval) {
    let selectHeader = document.getElementById('header');
    let selectBackToTop = document.getElementById('back-to-top');
    window.addEventListener('scroll', function (e) {

        if (selectHeader) {
            if (window.scrollY > 100) {
                selectHeader.classList.add('header-scrolled');
                selectBackToTop.classList.add('active');
            } else {
                selectHeader.classList.remove('header-scrolled');
                selectBackToTop.classList.remove('active');
            }
        }
    }, interval);
}


