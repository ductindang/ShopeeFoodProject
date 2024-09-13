
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


$(document).ready(function () {
    // Lấy storeId từ URL
    var storeId = getStoreIdFromUrl();

    // Load products cho từng menu khi trang tải
    menuIds.forEach(function (menuId) {
        loadProducts(menuId, storeId); // Truyền storeId vào
    });

    // Load cart từ localStorage và hiển thị nó
    loadCart();
});

function getStoreIdFromUrl() {
    // take Current url
    var url = window.location.href; 
    var segments = url.split('/');
    var storeId = segments[segments.length - 1];
    return storeId;
}

function loadProducts(menuId, storeId) {
    $.ajax({
        url: '/Menu/GetProductsByMenu',
        type: 'GET',
        data: { menuId: menuId },
        success: function (products) {
            $('#products-container-' + menuId).empty();
            var currencyFormatter = new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' });

            $.each(products, function (index, product) {
                var productHtml = `
                    <div class="product-item">
                        <img class="product-image" src="${product.image}" alt="${product.name}" />
                        <div class="product-details">
                            <div class="product-name" title="${product.name}">
                                ${product.name}
                            </div>
                            <div class="product-description">
                                ${product.description}
                            </div>
                            <div class="product-pricing">
                                <span class="discounted-price">
                                    ${currencyFormatter.format(product.price)}
                                </span>
                            </div>
                        </div>
                        <div class="btn-adding" data-id="${product.id}" data-name="${product.name}" data-price="${product.price}" data-image="${product.image}" data-store-id="${storeId}">
                            +
                        </div>
                    </div>
                    `;

                $('#products-container-' + menuId).append(productHtml);
            });

            // Attach the event listener using event delegation to avoid duplicate bindings
            $('#products-container-' + menuId).off('click', '.btn-adding').on('click', '.btn-adding', function () {
                var productId = $(this).data('id');
                var productName = $(this).data('name');
                var productPrice = $(this).data('price');
                var productImage = $(this).data('image');
                var productStoreId = $(this).data('store-id');

                addToCart(productId, productName, productPrice, productImage);
            });
        },
        error: function () {
            alert('Cannot load products.');
        }
    });
}


function addToCart(id, name, price, image) {
    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    let currentStoreId = getStoreIdFromUrl();

    let existingCart = cart.find(item => item.storeId === currentStoreId);

    if (existingCart) {
        let existingProduct = existingCart.items.find(item => item.id === id);
        if (!existingProduct) {
            existingCart.items.push({ id, name, price, image, quantity: 1 });
            //existingProduct.quantity += 1;
        }
        else {
            //existingCart.items.push({ id, name, price, image, quantity: 1 });
            existingProduct.quantity += 1;
        }
    } else {
        cart.push({
            storeId: currentStoreId,
            items: [{ id, name, price, image, quantity: 1 }]
        });
    }

    localStorage.setItem('cart', JSON.stringify(cart));

    loadCart();
}


// Example function to get shipping address, replace with your actual method
function getShippingAddress() {
    return {
        address: "123 Example Street, City, Country",
        postalCode: "123456",
        phone: "123-456-7890"
    };
}

function loadCart() {
    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    let currentStoreId = getStoreIdFromUrl(); // Lấy storeId từ URL
    let cartItemsContainer = $('#cart-items-container');
    var closeCart = document.getElementById("close-cart-btn");
    cartItemsContainer.empty();

    let totalPrice = 0;
    let currentStoreCart = cart.find(item => item.storeId === currentStoreId);

    if (currentStoreCart) {
        closeCart.style.display = 'flex';
        currentStoreCart.items.forEach(item => {
            let itemTotal = item.price * item.quantity;
            totalPrice += itemTotal;

            let cartItemHtml = `
                <div class="cart-item" style="justify-content: space-between; margin-bottom: 15px; align-items: center; padding-bottom: 10px; border-bottom: 1px solid #ddd;">
                    <div style="flex-grow: 1; justify-content: space-between; display: flex">
                        <div style="font-size: 16px;">${item.name}</div>
                        
                    </div>
                    <div style="display: flex; align-items: center; justify-content: end">
                        <button onclick="decreaseQuantity(${item.id})" style="border: none;">-</button>
                        <input id="quantity-${item.id}" type="text" value="${item.quantity}" style="width: 50px; text-align: center; margin: 0 5px; border: 1px solid #ccc; border-radius: 5px; padding: 5px; font-size: 14px;" />
                        <button onclick="increaseQuantity(${item.id})" style="border: none;">+</button>
                    </div>
                    <span style="display:flex; font-size: 16px; margin-right: 25px; justify-content: end">${itemTotal.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' })}</span>
                    <button onclick="removeFromCart(${item.id})" style="margin-left: 10px; border: none; background: none; color: red; font-size: 16px; cursor: pointer;">Remove</button>
                </div>`;

            cartItemsContainer.append(cartItemHtml);
        });

        // Update total price
        $('#cart-items-container').append(`
            <div style="border-top: 1px solid #ddd; padding-top: 20px; margin-top: 20px;">
                <div style="display: flex; justify-content: space-between; font-size: 18px;">
                    <strong>Total:</strong>
                    <strong>${totalPrice.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' })}</strong>
                </div>
            </div>
        `);
    } else {
        closeCart.style.display = 'none';

        // Nếu không có sản phẩm của cửa hàng hiện tại, hiển thị thông báo
        $('#cart-items-container').html('<p>The cart is empty or contains no products from the current store.</p>');
    }
}



function removeFromCart(id) {
    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    let currentStoreId = getStoreIdFromUrl();
    let existingCart = cart.find(item => item.storeId === currentStoreId);

    if (existingCart) {
        existingCart.items = existingCart.items.filter(item => parseInt(item.id) !== id);
        if (existingCart.items.length === 0) {
            cart = cart.filter(item => item.storeId !== currentStoreId);
        }
    }

    
    localStorage.setItem('cart', JSON.stringify(cart));
    loadCart();
}


function increaseQuantity(id) {
    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    let currentStoreId = getStoreIdFromUrl();

    // Find the store's cart
    let storeCart = cart.find(item => item.storeId === currentStoreId);

    if (storeCart) {
        let product = storeCart.items.find(item => item.id === id);
        if (product) {
            // Check if quantity is less than 3 before increasing
            //if (product.quantity < 3) {
                product.quantity += 1;
                localStorage.setItem('cart', JSON.stringify(cart));
                loadCart();
            //}
        }
    }
}

function decreaseQuantity(id) {
    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    let currentStoreId = getStoreIdFromUrl(); // Get storeId from URL

    // Find the store's cart
    let storeCart = cart.find(item => item.storeId === currentStoreId);

    if (storeCart) {
        let product = storeCart.items.find(item => item.id === id);
        if (product) {
            // Check if quantity is greater than 1 before decreasing
            if (product.quantity > 1) {
                product.quantity -= 1;
                localStorage.setItem('cart', JSON.stringify(cart));
                loadCart();
            } else if (product.quantity === 1) {
                // Remove the product if the quantity is 1
                storeCart.items = storeCart.items.filter(item => item.id !== id);

                // Remove the store's cart if it is empty
                if (storeCart.items.length === 0) {
                    cart = cart.filter(item => item.storeId !== currentStoreId);
                }

                localStorage.setItem('cart', JSON.stringify(cart));
                loadCart();
            }
        }
    }
}

document.getElementById('checkout-button').addEventListener('click', function () {
    if (!isLoggedIn()) {
        alert("You need to login before you order");
        var url = window.location.href; 
        localStorage.setItem('cartRedirect', url)
        //window.location.href = 'http://178.16.10.55:7235/User/Login';
        window.location.href = 'http://178.16.10.55:7235/User/Login';
        return;
    }

    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    let currentStoreId = getStoreIdFromUrl(); // Get storeId from URL
    let storeCart = cart.find(item => item.storeId === currentStoreId);
    let shippingAddress = getShippingAddress();

    if (storeCart) {
        // Send AJAX request to the server
        $.ajax({
            url: '/Order/Checkout', // Update with your controller and action
            type: 'POST',
            data: {
                storeId: currentStoreId,
                shippingAddress: shippingAddress,
                items: storeCart.items
            },
            success: function (partialViewHtml) {
                // Replace the content of the checkout modal with the received PartialView
                document.getElementById('checkout-content').innerHTML = partialViewHtml;

                // Show modal and overlay
                document.getElementById('checkout-modal').style.display = 'flex';
                document.getElementById('overlay').style.display = 'block';
            },
            error: function () {
                alert('An error occurred while loading payment information. Please try again.');
            }
        });
    } else {
        alert('The cart is empty or contains no products from the current store..');
    }
});




// ------------------------------------- Check out ------------------------------------------


function isLoggedIn() {
    return !!localStorage.getItem('userCheck'); 
}

// Function to handle placing the order
function placeOrder() {
    if (!isLoggedIn()) {
        alert("You need to login before you order");
        //window.location.href = 'https://localhost:7059/User/Login';
        window.location.href = loginUrl;
        return;
    }

    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    let currentStoreId = getStoreIdFromUrl();

    var selectAddress = document.getElementById("address-select");
    var addressError = document.getElementById("address-error");
    if (selectAddress.value === "-1") {
        addressError.textContent = "You need to choose an address to receive the product before you order";
        return;
    }

    let storeCart = cart.find(item => item.storeId === currentStoreId);

    if (!storeCart) {
        alert("The cart is empty or contains no products from the current store.");
        return;
    }
    

    $.ajax({
        //url: 'https://localhost:7059/Order/Order',
        url: orderUrl,
        type: "POST",
        data: {
            storeId: currentStoreId,
            addressId: selectAddress.value,
            items: storeCart.items
        },
        success: function (result) {
            // Filter out the cart items for the current store
            cart = cart.filter(item => item.storeId !== currentStoreId);

            // Save the updated cart back to localStorage
            localStorage.setItem('cart', JSON.stringify(cart));

            // Reload the cart display
            loadCart();
            // Close the modal
            document.getElementById('checkout-modal').style.display = 'none';
            document.getElementById('overlay').style.display = 'none';

            // Optionally, show a confirmation message or redirect to another page
            alert("Thank you for your order!");
        },
        error: function (xhr, status, error) {
            alert("An error occurred while placing the order. Please try again.");
        }
    });
}


document.getElementById('close-cart-btn').addEventListener('click', function () {
    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    let currentStoreId = getStoreIdFromUrl(); // Get storeId from URL

    // Filter out the cart items for the current store
    cart = cart.filter(item => item.storeId !== currentStoreId);

    // Save the updated cart back to localStorage
    localStorage.setItem('cart', JSON.stringify(cart));

    // Reload the cart display
    loadCart();
});

// Event listener for the Order button
document.getElementById('order-button').addEventListener('click', placeOrder);

// Existing event listener for the Close button
document.getElementById('close-modal').addEventListener('click', function () {
    // Hide modal and overlay
    document.getElementById('checkout-modal').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
});


function ChangeAddress() {
    // Get the selected option from the dropdown
    var select = document.getElementById("address-select");
    var selectedOption = select.options[select.selectedIndex];

    var selectAddress = document.getElementById("address-select");
    var addressError = document.getElementById("address-error");
    if (selectAddress.value === "-1") {
        addressError.textContent = "You have to choose a address to receive the product before you order";
    } else {
        addressError.textContent = "";
    }

    // Extract the data from the selected option
    var name = selectedOption.getAttribute("data-name");
    var address = selectedOption.getAttribute("data-address");
    var phone = selectedOption.getAttribute("data-phone");

    // Update the address content fields
    document.getElementById("name-info").textContent = name || "";
    document.getElementById("address-info").textContent = address || "";
    document.getElementById("phone-info").textContent = phone || "";
}




