


$(document).ready(function () {
    $('#userDropdown').click(function () {
        $('#userMenu').toggle(); // Toggle visibility of the dropdown menu
    });

    // Optional: Hide the dropdown if clicking outside of it
    $(document).click(function (event) {
        if (!$(event.target).closest('#userDropdown, #userMenu').length) {
            $('#userMenu').hide();
        }
    });
});



document.addEventListener("DOMContentLoaded", function () {
    var selectElement = document.getElementById("provinceSelect");

    // Lấy các tham số từ URL
    const urlParams = new URLSearchParams(window.location.search);
    const provinceIdFromUrl = urlParams.get('provinceId');
    const selectedId = provinceIdFromUrl || sessionStorage.getItem("SelectedProvinceId") || "01";

    // Đặt giá trị cho dropdown
    selectElement.value = selectedId;
    updateSelectedText(selectElement);
    selectElement.addEventListener("change", function () {
        sessionStorage.setItem("SelectedProvinceId", this.value);
        updateSelectedText(this);
        OnProvinceChange(); // Gọi hàm này để điều hướng khi thay đổi tỉnh
    });

    $(document).on('click', '.category-link', function () {
        var id = $(this).data('index');
        handleHover(sessionStorage.getItem('SelectedProvinceId'), id);
    });
});


    //var userCheckJson = @Html.Raw(JsonConvert.SerializeObject(userCheckJson));
    //if (userCheckJson) {
    //    // Chuyển đổi userCheckJson thành đối tượng JavaScript và lưu vào localStorage
    //    var userCheck = JSON.parse(userCheckJson);
    //localStorage.setItem("userCheck", JSON.stringify(userCheck));
    //} else {
    //    // Xóa userCheck khỏi localStorage nếu không có dữ liệu
    //    localStorage.removeItem("userCheck");
    //}

function updateSelectedText(selectElement) {
    const selectedOption = selectElement.options[selectElement.selectedIndex];
    // Hiển thị chỉ tên của province trong dropdown
    selectedOption.text = selectedOption.getAttribute('data-name');
}

function handleHover(provinceId, categoryId) {
    if (provinceId && categoryId) {
        window.location.href = '/Home/Privacy?categoryId=' + categoryId + '&provinceId=' + provinceId;
    }
}

function OnProvinceChange() {
    var id = sessionStorage.getItem('selectedCategoryId');
    var selectedProvinceId = document.getElementById("provinceSelect").value;
    window.location.href = '/Home/Privacy?categoryId=' + id + '&provinceId=' + selectedProvinceId;
}

$(document).ready(function () {
    const urlParams = new URLSearchParams(window.location.search);
    const selectedIdFromUrl = urlParams.get('categoryId');
    const provinceIdFromUrl = urlParams.get('provinceId');

    if (selectedIdFromUrl) {
        sessionStorage.setItem('selectedCategoryId', selectedIdFromUrl);
        $('#item-' + selectedIdFromUrl).addClass('selected-category');
    } else {
        const selectedId = sessionStorage.getItem('selectedCategoryId');
        if (selectedId) {
            $('#item-' + selectedId).addClass('selected-category');
        }
    }

    if (provinceIdFromUrl) {
        sessionStorage.setItem('SelectedProvinceId', provinceIdFromUrl);
        var selectElement = document.getElementById("provinceSelect");
        selectElement.value = provinceIdFromUrl;
        updateSelectedText(selectElement);
    }

    $(document).on('click', '.category-link', function () {
        var id = $(this).data('index');
        var name = $(this).data('name');
        handleItemClick(id, name);
    });
});

function handleItemClick(id, name) {
    $('.category-link').removeClass('selected-category');
    $('#item-' + id).addClass('selected-category');

    sessionStorage.setItem('selectedCategoryId', id);
    sessionStorage.setItem('selectedCategoryName', name);

    var provinceId = sessionStorage.getItem('SelectedProvinceId') || '01';
    window.location.href = '/Home/Privacy?categoryId=' + id + '&provinceId=' + provinceId;
}
