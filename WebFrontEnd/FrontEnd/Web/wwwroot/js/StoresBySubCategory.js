function loadPage(page, selectedDistricts = [], selectedSubCates = []) {
    $.ajax({
        type: 'GET',
        url: '/Store/GetStoresBySubCategory',
        traditional: true,
        data: {
            subCategoryId: subId,
            page: page,
            pageSize: 5,
            selectedDistricts: selectedDistricts,
            //Change the numbers to string
            selectedSubCates: selectedSubCates.map(String)
        },
        success: function (result) {
            $('#sub-list').html(result);
        }
    });

    // Event delegation for dynamically loaded product items
    $(document).on('click', '.sub-list-deal .store-item', function () {
        const storeId = $(this).data('id');
        window.location.href = `/Store/Details/${storeId}`;
    });

    // Event delegation for the pagination button
    $(document).on('click', '.list-deal button', function () {
        currentPage++;
        loadPage(currentPage);
    });
}
loadPage(1);
if (subId != 1) {
    var selectedSubCates = [];
    selectedSubCates.push(subId);
    document.getElementById('subCate-' + subId).checked = true;
    loadPage(1, getSelectedDistricts(), selectedSubCates);
}



document.querySelector('.dropbtn').addEventListener('click', function () {
    var dropdownBtn = document.querySelector('.dropbtn');
    dropdownBtn.style.backgroundColor = 'white';
    var dropdownContent = document.querySelector('.dropdown-content');
    if (dropdownContent.style.display === 'flex') {
        dropdownContent.style.display = 'none';
    } else {
        dropdownContent.style.display = 'flex';
    }
});

document.querySelector('.dropCatebtn').addEventListener('click', function () {
    var dropdownBtn = document.querySelector('.dropCatebtn');
    dropdownBtn.style.backgroundColor = 'white';
    var dropdownContent = document.querySelector('.dropdown-cate-content');
    if (dropdownContent.style.display === 'flex') {
        dropdownContent.style.display = 'none';
    } else {
        dropdownContent.style.display = 'flex';
    }
});

// Function to get selected district IDs
function getSelectedDistricts() {
    var selectedDistricts = [];
    var checkboxes = document.querySelectorAll('.district-checkbox:checked');
    checkboxes.forEach(function (checkbox) {
        selectedDistricts.push(checkbox.value);
    });
    return selectedDistricts;
}

function getSelectedCategories() {
    var selectedSubCategories = [];
    var checkboxes = document.querySelectorAll('.subCate-checkbox:checked');
    checkboxes.forEach(function (checkbox) {
        selectedSubCategories.push(checkbox.value);
    });
    return selectedSubCategories;
}

// Close the dropdown if the user clicks outside of it and process the selected data
window.onclick = function (event) {
    var dropdownContent = document.querySelector('.dropdown-content');
    var dropdownCateContent = document.querySelector('.dropdown-cate-content'); // Thêm dấu chấm cho class selector

    if (dropdownContent && !dropdownContent.contains(event.target) && !event.target.matches('.dropbtn')) {
        if (dropdownContent.style.display === 'flex') {
            var dropdownBtn = document.querySelector('.dropbtn');
            if (dropdownBtn) {
                dropdownBtn.style.backgroundColor = 'transparent';
            }
            dropdownContent.style.display = 'none';

            // Process the selected districts here
            var selectedDistricts = getSelectedDistricts();
            console.log("Selected District IDs:", selectedDistricts);
            var selectedSubCategories = getSelectedCategories();
            console.log("Selected Subcategory IDs:", selectedSubCategories);

            loadPage(1, selectedDistricts, selectedSubCategories);
        }
    }

    if (dropdownCateContent && !dropdownCateContent.contains(event.target) && !event.target.matches('.dropCatebtn')) {
        if (dropdownCateContent.style.display === 'flex') {
            var dropdownCateBtn = document.querySelector('.dropCatebtn');
            if (dropdownCateBtn) {
                dropdownCateBtn.style.backgroundColor = 'transparent';
            }
            dropdownCateContent.style.display = 'none';

            // Process the selected categories here
            var selectedDistricts = getSelectedDistricts();
            console.log("Selected District IDs:", selectedDistricts);
            var selectedSubCategories = getSelectedCategories();
            console.log("Selected Subcategory IDs:", selectedSubCategories);

            loadPage(1, selectedDistricts, selectedSubCategories);
        }
    }
};



function closeDistrictBtn() {
    var districtCheckboxes = document.querySelectorAll('.district-checkbox:checked');
    districtCheckboxes.forEach(function (checkbox) {
        checkbox.checked = false;
    });
    var selectedDistricts = getSelectedDistricts();
    console.log("Selected District IDs:", selectedDistricts);
    var selectedSubCategories = getSelectedCategories();
    console.log("Selected Subcategory IDs:", selectedSubCategories);
    loadPage(1, selectedDistricts, selectedSubCategories);
    var closeButton = document.querySelector('.numberDistrict');
    if (closeButton) {
        closeButton.remove();
    }
}


function closeSubCategoryBtn() {
    subId = 1;
    var subCateCheckboxes = document.querySelectorAll('.subCate-checkbox:checked');
    subCateCheckboxes.forEach(function (checkbox) {
        checkbox.checked = false;
    });
    var selectedDistricts = getSelectedDistricts();
    console.log("Selected District IDs:", selectedDistricts);
    var selectedSubCategories = getSelectedCategories();
    console.log("Selected Subcategory IDs:", selectedSubCategories);
    loadPage(1, selectedDistricts, selectedSubCategories);
    var numberSubCate = document.querySelector('.numberSubCate');
    if (numberSubCate) {
        numberSubCate.remove();
    }
}

