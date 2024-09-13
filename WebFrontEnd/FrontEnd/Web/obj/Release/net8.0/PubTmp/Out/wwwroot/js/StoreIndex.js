function loadPage(page, selectedDistricts = []) {
    $.ajax({
        type: 'GET',
        url: '/Store/LoadStore',
        traditional: true,
        data: {
            page: page,
            storePerPage: 5,
            selectedDistricts: selectedDistricts,
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

// Function to get selected district IDs
function getSelectedDistricts() {
    var selectedDistricts = [];
    var checkboxes = document.querySelectorAll('.district-checkbox:checked');
    checkboxes.forEach(function (checkbox) {
        selectedDistricts.push(checkbox.value);
    });
    return selectedDistricts;
}

// Close the dropdown if the user clicks outside of it and process the selected data
window.onclick = function (event) {
    var dropdownContent = document.querySelector('.dropdown-content');
    if (!dropdownContent.contains(event.target) && !event.target.matches('.dropbtn')) {
        if (dropdownContent.style.display === 'flex') {
            var dropdownBtn = document.querySelector('.dropbtn');
            dropdownBtn.style.backgroundColor = 'transparent';
            dropdownContent.style.display = 'none';

            // Process the selected districts here
            var selectedDistricts = getSelectedDistricts();
            console.log("Selected District IDs:", selectedDistricts);
            loadPage(1, selectedDistricts);
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
    loadPage(1, selectedDistricts);
    var closeButton = document.querySelector('.numberDistrict');
    if (closeButton) {
        closeButton.remove();
    }
}
//document.addEventListener("DOMContentLoaded", function () {
//    const closeBtn = document.querySelector('.numberDistrict .close-btn');
//    if (closeBtn) {
//        closeBtn.addEventListener('click', function () {
//            const numberDistrictDiv = document.querySelector('.numberDistrict');
//            if (numberDistrictDiv) {
//                numberDistrictDiv.remove();
//            }
//        });
//    }
//});




