

function choose() {
    alert("chon");
}


document.addEventListener('click', function (event) {
    const searchInput = document.getElementById('search-input');
    const storeContainer = document.getElementById('store-container');

    // Check if click is outside of search input and store container
    if (!searchInput.contains(event.target) && !storeContainer.contains(event.target)) {
        // Clear store container when focus is lost from input and its container
        storeContainer.innerHTML = '';
    }
});

document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.getElementById('search-input');
    const storeContainer = document.getElementById('store-container');

    // Debounce function
    function debounce(fn, delay) {
        let timeout;
        return function (...args) {
            clearTimeout(timeout);
            timeout = setTimeout(() => fn.apply(this, args), delay);
        };
    }

    // Function to show loading spinner
    function showLoading() {
        storeContainer.innerHTML = '<div class="spinner" style="background-color: white; margin: 10px auto; text-align: center;"></div>';
    }

    // Function to hide loading spinner
    function hideLoading() {
        storeContainer.innerHTML = '';
    }

    // Function to display stores
    function displayStores(stores) {
        storeContainer.innerHTML = '';

        if (stores && stores.length > 0) {
            stores.forEach(store => {
                const storeElement = document.createElement('div');
                storeElement.classList.add('store-item');
                storeElement.dataset.id = store.storeId;
                storeElement.style.margin = '10px 0';
                storeElement.style.width = '100%';
                storeElement.style.display = 'flex';
                storeElement.style.paddingLeft = '7px';
                storeElement.style.cursor = 'pointer';

                const imageElement = document.createElement('img');
                imageElement.src = store.storeImage;
                imageElement.alt = store.storeName;
                imageElement.style.minWidth = '50px';
                imageElement.style.height = '30px';
                imageElement.style.margin = 'auto 7px';

                const storeInfoElement = document.createElement('div');
                storeInfoElement.classList.add('store-info');
                storeInfoElement.style.margin = 'auto';
                storeInfoElement.style.width = '100%';
                storeInfoElement.style.overflow = 'hidden';
                storeInfoElement.style.padding = 'auto 7px';

                const nameElement = document.createElement('div');
                nameElement.textContent = store.storeName;
                nameElement.style.whiteSpace = 'nowrap';
                nameElement.style.overflow = 'hidden';
                nameElement.style.textOverflow = 'ellipsis';
                nameElement.style.width = '80%';
                nameElement.style.fontSize = '14px';
                nameElement.style.fontWeight = '700';

                const addressElement = document.createElement('div');
                addressElement.textContent = `${store.streetName}, ${store.wardName}, ${store.districtName}, ${store.provinceName}`;
                addressElement.style.whiteSpace = 'nowrap';
                addressElement.style.overflow = 'hidden';
                addressElement.style.textOverflow = 'ellipsis';
                addressElement.style.width = '80%';
                addressElement.style.fontSize = '12px';
                addressElement.style.opacity = '0.6';

                const timeElement = document.createElement('div');
                const now = new Date();
                const currentHours = now.getHours();

                const [openHours] = store.storeOpenTime.split(':').map(Number);
                const [closeHours] = store.storeCloseTime.split(':').map(Number);

                if (currentHours < openHours || currentHours > closeHours) {
                    timeElement.textContent = 'Closed';
                    timeElement.style.color = 'red';
                } else {
                    timeElement.textContent = 'Open';
                    timeElement.style.color = 'green';
                }
                timeElement.style.fontSize = '12px';
                timeElement.style.padding = '10px 30px 0 0';

                storeInfoElement.appendChild(nameElement);
                storeInfoElement.appendChild(addressElement);
                storeElement.appendChild(imageElement);
                storeElement.appendChild(storeInfoElement);
                storeElement.appendChild(timeElement);
                storeContainer.appendChild(storeElement);
            });
        } else {
            const noResultElement = document.createElement('div');
            noResultElement.textContent = "Cannot find any store";
            noResultElement.style.margin = '10px 0';
            noResultElement.style.width = '100%';
            noResultElement.style.display = 'flex';
            noResultElement.style.paddingLeft = '7px';
            noResultElement.style.fontSize = '14px';
            noResultElement.style.fontWeight = '700';
            noResultElement.style.color = 'red';
            noResultElement.style.textAlign = 'center';
            noResultElement.style.padding = '10px';
            noResultElement.style.margin = 'auto';

            storeContainer.appendChild(noResultElement);
        }

        document.querySelectorAll('.store-item').forEach(item => {
            item.addEventListener('click', function () {
                const storeId = this.dataset.id;
                window.location.href = `/Store/Details/${storeId}`;
            });
        });
    }

    searchInput.addEventListener('input', debounce(async function () {
        const query = this.value.trim();

        if (query.length < 1) {
            storeContainer.innerHTML = '';
            return;
        }

        showLoading();

        try {
            const response = await fetch(`/Store/SearchStoresByName?name=${encodeURIComponent(query)}`);
            if (!response.ok) throw new Error('Network response was not ok');
            const stores = await response.json();

            const storeDetails = await Promise.all(
                stores.map(async (store) => {
                    const response2 = await fetch(`/Store/GetStoreWithDetailAddress/${store.id}`);
                    return response2.json();
                })
            );

            hideLoading();
            displayStores(storeDetails);
        } catch (error) {
            console.error('Error fetching stores:', error);
            storeContainer.innerHTML = '<div style="color: red; text-align: center;">Error loading stores.</div>';
        }
    }, 500));
});


$(document).ready(async function () {
    let currentPage = 1;
    const pageSize = 9;
    const allStores = stos;

    function showSpinner() {
        $('#overlay').show();
        $('#loading-store-spinner').show();
    }

    function hideSpinner() {
        setTimeout(() => {
            $('#loading-store-spinner').hide();
            $('#overlay').hide();
        }, 100); // Delay spinner hide for smoother transition
    }

    async function loadStores(page) {
        const container = $('.sub-list-deal');
        const start = (page - 1) * pageSize;
        const end = start + pageSize;
        const storesToShow = allStores.slice(start, end);

        if (storesToShow.length > 0) {
            showSpinner();
            const storeDetailsPromises = storesToShow.map(async store => {
                const response = await fetch(`/Store/GetStoreWithDetailAddress/${store.Id}`);
                return response.json();
            });

            try {
                const storeDetails = await Promise.all(storeDetailsPromises);

                storeDetails.forEach((searchStore, index) => {
                    const storeHtml = `
                        <div class="store-item" data-id="${searchStore.storeId}">
                            <img class="store-image" src="${searchStore.storeImage}" />
                            <div class="store-info">
                                <div style="white-space: nowrap; overflow: hidden;text-overflow: ellipsis;"><strong class="store-name" title="${searchStore.storeName}">${searchStore.storeName}</strong></div>
                                <div class="address-res" title="${searchStore.streetName}, ${searchStore.wardName}, ${searchStore.districtName}, ${searchStore.provinceName}">
                                    ${searchStore.streetName}, ${searchStore.wardName}, ${searchStore.districtName}, ${searchStore.provinceName}
                                </div>
                            </div>
                            <div class="store-discount">
                                <span><i class="fas fa-tag"></i> Item discount</span>
                            </div>
                        </div>
                    `;
                    container.append(storeHtml);
                });

            } catch (error) {
                console.error("Lỗi khi lấy chi tiết cửa hàng:", error);
            } finally {
                hideSpinner();
            }
        } else {
            $('.list-deal').append('<p style="color: black">No more stores to load.</p>');
            $('.list-deal button').hide();
        }
    }

    await loadStores(currentPage);

    $('.sub-list-deal').on('click', '.store-item', function () {
        const storeId = $(this).data('id');
        window.location.href = `/Store/Details/${storeId}`;
    });

    $('.list-deal button').on('click', async function () {
        currentPage++;
        await loadStores(currentPage);
    });
});









//$(document).ready(function () {
//    let currentPage = 1;
//    const pageSize = 9;


//    async function loadDiscounts(page) {
//        try {
//            const response = await fetch(`/Discount/GetDiscounts?categoryId=${cateId}&page=${page}&pageSize=${pageSize}`);
//            if (!response.ok) {
//                throw new Error(`Network response was not ok: ${response.status}`);
//            }

//            const discounts = await response.json();

//            if (discounts.length > 0) {
//                discounts.forEach(discount => {
//                    const discountHtml = `
//                        <div style="width: 30%; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); cursor: pointer;" class="discount-item" data-id="${discount.id}">
//                            <img style="width: 100%; border-radius: 10px" src="${discount.imageUrl}" alt="${discount.name}" />
//                            <div style="color: black; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="${discount.name}">
//                                <strong>${discount.name}</strong>
//                            </div>
//                            <div style="color: #0288d1; font-size: 13px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="${discount.productCount}">
//                                ${discount.productCount} locations
//                            </div>
//                        </div>
//                    `;
//                    $('#discount-container').append(discountHtml);
//                });

//                // Add click event for each discount item
//                $('.discount-item').on('click', function () {
//                    const discountId = $(this).data('id');
//                    window.location.href = `/Product`;
//                });
//            } else {
//                $('#load-more-discounts').hide();
//                $('#discount-container').append('<p>No more discounts to load.</p>');
//            }
//        } catch (error) {
//            console.error('Error fetching discounts:', error);
//        }
//    }

//    // Initial load
//    loadDiscounts(currentPage);
//});


document.addEventListener('DOMContentLoaded', function () {
    let currentPage = 1;
    const pageSize = 5; // Define the number of stores per page

    async function loadStoresByDistrict(districtId, page) {
        const storeContainer = document.getElementById('store-by-district-container');
        const loadMoreButton = document.querySelector('.load-more-district-button');

        if (!districtId || districtId === '-1') return;

        try {
            loadMoreButton.style.display = 'block';
            const response = await fetch(`/Store/GetStoresByDistrict?districtId=${districtId}&page=${page}&pageSize=${pageSize}`);

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }

            const stores = await response.json();
            if (page === 1) {
                storeContainer.innerHTML = ''; // Clear the container only if it's the first page
            }

            if (stores.length > 0) {
                const storeHtml = stores.map(store => `
                    <div class="store-item" data-id="${store.storeId}" style="display: flex; width: 100%; justify-content: center; cursor: pointer;">
                        <div style="display: flex; max-width: 144px;">
                            <img style="width: 100%; margin: auto;" src="${store.storeImage}" alt="Restaurant Image" />
                        </div>
                        <div style="width: 60%; margin-left: 5%;">
                            <div style="color: black; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; font-weight: bold; font-size: 16px;">
                                ${store.storeName}
                            </div>
                            <div style="color: black; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; font-size: 14px;">
                                ${store.streetName}, ${store.wardName}, ${store.districtName}, ${store.provinceName}
                            </div>
                            <div style="color: black; display: flex; gap: 10px; font-size: 14px; margin-top: 10px;">
                                <span><i class="bi bi-tags"></i> Minimum $${Math.round(store.storeMaxPrice / 10)}</span>
                                <span><i class="bi bi-coin"></i> Price $${Math.round(store.storeMaxPrice)}</span>
                            </div>
                        </div>
                    </div>
                `).join('');

                storeContainer.insertAdjacentHTML('beforeend', storeHtml);
            } else {
                loadMoreButton.style.display = 'none';
                storeContainer.insertAdjacentHTML('beforeend', '<p style="color:blue">No more stores to load.</p>');
            }
        } catch (error) {
            console.error('Error fetching stores:', error);
        }
    }

    const districtSelect = document.querySelector('#district-select'); // Use ID if available

    if (districtSelect) {
        districtSelect.addEventListener('change', function () {
            const districtId = this.value;
            currentPage = 1; // Reset page number when district changes
            loadStoresByDistrict(districtId, currentPage);
        });
    } else {
        console.error('Element with ID "district-select" not found.');
    }

    // Event listener for the "Load more" button
    document.querySelector('.load-more-district-button').addEventListener('click', function () {
        currentPage++;
        const districtId = districtSelect ? districtSelect.value : '-1';
        if (districtId !== '-1') {
            loadStoresByDistrict(districtId, currentPage);
        }
    });

    // Event delegation to handle click events for store items
    document.getElementById('store-by-district-container').addEventListener('click', function (event) {
        const storeItem = event.target.closest('.store-item');
        if (storeItem) {
            const storeId = storeItem.getAttribute('data-id');
            window.location.href = `/Store/Details/${storeId}`;
        }
    });

    // Initial load
    const districtId = districtSelect ? districtSelect.value : '-1';
    if (districtId !== '-1') {
        loadStoresByDistrict(districtId, currentPage);
    }
});










