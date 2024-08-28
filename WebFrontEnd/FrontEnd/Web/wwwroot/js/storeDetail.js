
window.onscroll = function () {
    var menu = document.getElementById("leftMenu");
    var detailSection = document.getElementById("detailSection");
    var content = document.querySelector(".content");

    // Đảm bảo các phần tử tồn tại
    if (!menu || !detailSection || !content) {
        console.error("Một hoặc nhiều phần tử không tồn tại.");
        return;
    }

    var sticky = menu.offsetTop;
    var detailTop = detailSection.offsetTop;
    var detailHeight = detailSection.offsetHeight;
    var menuHeight = menu.offsetHeight;
    var contentTop = content.offsetTop;
    var contentHeight = content.offsetHeight;
    var scrollTop = window.pageYOffset;
    var menuWidth = menu.offsetWidth;

    // Tính toán đáy của khu vực nội dung
    var contentBottom = contentTop + contentHeight;

    // console.log("ScrollTop:", scrollTop);
    // console.log("Sticky:", sticky);
    // console.log("DetailTop:", detailTop);
    // console.log("DetailHeight:", detailHeight);
    // console.log("MenuHeight:", menuHeight);
    // console.log("ContentBottom:", contentBottom);
    // console.log("MenuWidth:", menuWidth);

    if (scrollTop > sticky && scrollTop > detailTop + detailHeight && scrollTop < contentBottom - menuHeight) {
        menu.style.position = "fixed";
        menu.style.top = "65px";
        menu.style.width = menuWidth + "px";
        content.style.marginLeft = menuWidth + 40 + "px";

    } else if (scrollTop >= contentBottom - menuHeight) {
        menu.style.position = "relative";
        menu.style.top = (contentHeight - menuHeight + 5) + "px";
        content.style.marginLeft = "40px";
    } else {
        menu.style.position = "relative";
        menu.style.top = "auto";
        content.style.marginLeft = "40px";
    }
};

document.querySelectorAll('.left-menu a').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();

        const targetId = this.getAttribute('href').substring(1);
        const targetElement = document.getElementById(targetId);

        const offset = 100;
        const targetPosition = targetElement.getBoundingClientRect().top + window.pageYOffset - offset;

        window.scrollTo({
            top: targetPosition,
            behavior: 'smooth'
        });
    });
});