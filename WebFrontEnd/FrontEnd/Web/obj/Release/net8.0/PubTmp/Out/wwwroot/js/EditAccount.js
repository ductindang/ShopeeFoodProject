
$(document).ready(function () {
    function loadAccountInfo() {
        $("#accountUpdateLink").addClass("active");
        $.ajax({
            type: "GET", // Change to GET if you are fetching data without modifying
            url: "/User/UpdateAccount", // Adjust the URL to match your route
            success: function (response) {
                // Load the partial view content into the main-panel
                $(".main-panel").html(response);
            },
            error: function (xhr, status, error) {
                console.error("An error occurred while loading the account update info:", error);
            }
        });
    }

    // Attach click event to the Account update link
    $("#accountUpdateLink").on("click", function () {
        // Remove active class from all panel links
        $(".panel-link").removeClass("active");

        // Load the account update info
        loadAccountInfo();
    });
    loadAccountInfo();

    function loadOrderInfo() {
        $("#orderInfoLink").addClass("active");

        $.ajax({
            type: "GET", // Change to GET if you are fetching data without modifying
            url: "/Order/OrderInfo", // Adjust the URL to match your route
            success: function (response) {
                // Load the partial view content into the main-panel
                $(".main-panel").html(response);
            },
            error: function (xhr, status, error) {
                console.error("An error occurred while loading the account update info:", error);
            }
        });
    }

    // Attach click event to the Account update link
    $("#orderInfoLink").on("click", function () {
        // Remove active class from all panel links
        $(".panel-link").removeClass("active");

        loadOrderInfo();
    });
});

