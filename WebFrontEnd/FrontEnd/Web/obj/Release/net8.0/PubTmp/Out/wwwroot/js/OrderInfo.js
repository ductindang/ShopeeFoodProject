// Define the function outside of event listeners
function loadOrderInfo() {
    // Send AJAX request to the server
    $.ajax({
        url: '/Order/AddAddress', // Update with your controller and action
        type: 'POST',
        data: {
            // Add any data you need to send to the server
        },
        success: function (partialViewHtml) {
            // Replace the content of the checkout modal with the received PartialView
            document.getElementById('address-content').innerHTML = partialViewHtml;

            // Show modal and overlay
            document.getElementById('address-modal').style.display = 'flex';
            document.getElementById('overlay').style.display = 'block';
        },
        error: function () {
            alert('An error occured when loading the order infomation. Please do it again.');
        }
    });
}

// Event listener for the adding-address button
document.getElementById('adding-address').addEventListener('click', function () {
    loadOrderInfo();
});

// Event listener for the Order button
function AddAddress() {
    document.getElementById('address-modal').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
};

// Existing event listener for the Close button
function CloseAddress() {
    // Hide modal and overlay
    document.getElementById('address-modal').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
};










// ---------------------------------- ADD ADDRESS ------------------------------------
function ChangeProvince() {
    var provinceSelect = document.getElementById('provinceSel');
    if (!provinceSelect) {
        console.error("Cannot find element with ID 'provinceSel'");
        return;
    }

    var province = document.getElementById("provinceSel");
    var provinceError = document.getElementById("province-error");

    if (province.value === "-1") {
        isValid = false;
        province.style.borderColor = "red";
        provinceError.textContent = "Please select a province/city.";
    } else {
        province.style.borderColor = "black";
        provinceError.textContent = "";
    }

    var provinceId = provinceSelect.value;
    console.log(provinceId);

    if (provinceId !== "-1") {
        $.ajax({
            url: '/District/GetDistrictByProvince', // Updated URL to match controller method
            type: 'GET',
            data: {
                provinceId: provinceId // Fixed data format
            },
            success: function (districts) {
                var districtSelect = $('#district-sel');
                districtSelect.empty();
                districtSelect.append('<option value="-1">Choose District</option>');

                $.each(districts, function (index, district) {
                    districtSelect.append('<option value="' + district.id + '">' + district.name + '</option>');
                });
            },
            error: function () {
                alert('Error fetching districts.');
            }
        });
    } else {
        // Reset district select when no valid province is selected
        $('#district-sel').empty().append('<option value="-1">Choose District</option>');
    }

    ChangeDistrict();
}



function ChangeDistrict() {
    var districtSelect = document.getElementById('district-sel');
    if (!districtSelect) {
        console.error("Cannot find element with ID 'district-select'");
        return;
    }
    
    var district = document.getElementById("district-sel");
    var districtError = document.getElementById("district-error");
    

    if (district.value === "-1") {
        isValid = false;
        district.style.borderColor = "red";
        districtError.textContent = "Please select a district.";
    } else {
        district.style.borderColor = "black";
        districtError.textContent = "";
    }

    var districtId = districtSelect.value;
    console.log(districtId);

    if (districtId !== "-1") {
        $.ajax({
            url: '/Ward/GetWardsByDistrict',
            type: 'GET',
            data: {
                districtId: districtId
            },
            success: function (wards) {
                var wardSelect = $('#ward-sel'); // Make sure this ID matches your actual select element ID
                wardSelect.empty();
                wardSelect.append('<option value="-1">Choose Ward</option>');

                $.each(wards, function (index, ward) {
                    wardSelect.append('<option value="' + ward.id + '">' + ward.name + '</option>');
                });
            },
            error: function () {
                alert('Error fetching wards.');
            }
        });
    } else {
        // Reset ward select when no valid district is selected
        $('#ward-sel').empty().append('<option value="-1">Choose Ward</option>');
    }
}

function ChangeWard() {
    var ward = document.getElementById("ward-sel");
    var wardError = document.getElementById("ward-error");
    if (ward.value === "-1") {
        isValid = false;
        ward.style.borderColor = "red";
        wardError.textContent = "Please select a ward.";
    } else {
        ward.style.borderColor = "black";
        wardError.textContent = "";
    }
}

function validateForm() {
    var isValid = true;

    var province = document.getElementById("provinceSel");
    var district = document.getElementById("district-sel");
    var ward = document.getElementById("ward-sel");

    var provinceError = document.getElementById("province-error");
    var districtError = document.getElementById("district-error");
    var wardError = document.getElementById("ward-error");

    var phoneNumber = document.getElementById("phoneInput");
    if (!validatePhoneNumber()) {
        isValid = false;
        phoneNumber.focus();
        return false;
    }

    if (province.value === "-1") {
        isValid = false;
        province.style.borderColor = "red";
        provinceError.textContent = "Please select a province/city.";
    } else {
        province.style.borderColor = "black";
        provinceError.textContent = "";
    }

    if (district.value === "-1") {
        isValid = false;
        district.style.borderColor = "red";
        districtError.textContent = "Please select a district";
    } else {
        district.style.borderColor = "black";
        districtError.textContent = "";
    }

    if (ward.value === "-1") {
        isValid = false;
        ward.style.borderColor = "red";
        wardError.textContent = "Please select a ward.";
    } else {
        ward.style.borderColor = "black";
        wardError.textContent = "";
    }

    return isValid; // Prevent form submission if false
}

function validatePhoneNumber() {
    const phoneNumber = document.getElementById("phoneInput").value;
    const phoneNumberError = document.getElementById("phone-number-error");
    const phoneRegex = /^0\d{9}$/;

    if (phoneNumber.length > 0) {
        if (!phoneRegex.test(phoneNumber)) {
            phoneNumberError.textContent = 'Phone number must be 10 digits and start with 0.';
            return false;
        }
        phoneNumberError.textContent = '';
        return true;
    } else {
        phoneNumberError.textContent = 'Phone number cannot be empty.';
        return false;
    }
}


