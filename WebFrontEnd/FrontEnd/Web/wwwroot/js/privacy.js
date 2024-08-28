

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
    //let typingTimer;
    //const doneTypingInterval = 2000; 

    // Debounce function
    function debounce(fn, delay) {
        let timeout;
        return function () {
            const context = this;
            const args = arguments;
            clearTimeout(timeout);
            timeout = setTimeout(() => fn.apply(context, args), delay);
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

                const name2Element = document.createElement('div');
                name2Element.textContent = `${store.streetName}, ${store.wardName}, ${store.districtName}, ${store.provinceName}`;
                name2Element.style.whiteSpace = 'nowrap';
                name2Element.style.overflow = 'hidden';
                name2Element.style.textOverflow = 'ellipsis';
                name2Element.style.width = '80%';
                name2Element.style.fontSize = '12px';
                name2Element.style.opacity = '0.6';


                const timeElement = document.createElement('div');
                const now = new Date();
                const currentHours = now.getHours();

                const openTime = store.storeOpenTime.split(':');
                const closeTime = store.storeCloseTime.split(':');

                const openHours = parseInt(openTime[0]);
                const closeHours = parseInt(closeTime[0]);

                if (currentHours < openHours || currentHours > closeHours) {
                    timeElement.textContent = 'Close';
                    timeElement.style.color = 'rgb(255, 0, 0)';
                } else {
                    timeElement.textContent = 'Open';
                    timeElement.style.color = 'rgb(35, 152, 57)';
                }
                timeElement.style.fontSize = '12px';
                timeElement.style.padding = '10px 30px 0 0';


                storeInfoElement.appendChild(nameElement);
                storeInfoElement.appendChild(name2Element);
                storeElement.appendChild(imageElement);
                storeElement.appendChild(storeInfoElement);
                storeElement.appendChild(timeElement);
                storeContainer.appendChild(storeElement);
            });
        }
        else {
            const storeElement = document.createElement('div');
            //storeElement.style.border = '1px solid lightgray';
            storeElement.style.margin = '10px 0';
            storeElement.style.width = '100%';
            storeElement.style.display = 'flex';
            storeElement.style.paddingLeft = '7px';

            //const storeInfoElement = document.createElement('div');
            //storeInfoElement.classList.add('store-info');
            //storeInfoElement.style.margin = 'auto';
            //storeInfoElement.style.width = '100%';
            //storeInfoElement.style.overflow = 'hidden';
            //storeInfoElement.style.padding = 'auto 7px';
            //store

            const nameElement = document.createElement('div');
            nameElement.textContent = "Cannot find any store";
            nameElement.style.whiteSpace = 'nowrap';
            nameElement.style.overflow = 'hidden';
            nameElement.style.textOverflow = 'ellipsis';
            nameElement.style.width = '80%';
            nameElement.style.fontSize = '14px';
            nameElement.style.fontWeight = '700';
            nameElement.style.color = 'red';
            nameElement.style.textAlign = 'center';
            nameElement.style.padding = '10px';
            nameElement.style.margin = 'auto';

            //storeInfoElement.appendChild(nameElement);
            storeElement.appendChild(nameElement);
            storeContainer.appendChild(storeElement);
        }
        

        document.querySelectorAll('.store-item').forEach(item => {
            item.addEventListener('click', function () {
                const storeId = this.dataset.id;
                window.location.href = `/Store/Details/${storeId}`;
            });
        });

    }

    // Event listener for search input
    // Event listener for search input
    searchInput.addEventListener('input', debounce(async function () {

        hideLoading();
        const query = this.value;

        if (query.trim().length < 1) {
            storeContainer.innerHTML = '';
            return;
        }
        
        showLoading();

        const minLoadTime = 1000; // 1 second
        const startTime = Date.now();

        try {
            const response = await fetch(`/Store/SearchStoresByName?name=${encodeURIComponent(query)}`);
            if (!response.ok) {
                throw new Error(`Network response was not ok: ${response.status}`);
            }
            const stores = await response.json();
            let storeDetails = [];

            for (const store of stores) {
                const response2 = await fetch(`/Store/GetStoreWithDetailAddress/${store.id}`);
                const searchStore = await response2.json();
                searchStore.id = store.id;
                storeDetails.push(searchStore);
            }

            const elapsedTime = Date.now() - startTime;
            const remainingTime = minLoadTime - elapsedTime;

            if (remainingTime > 0) {
                await new Promise(resolve => setTimeout(resolve, remainingTime));
            }

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

    async function loadStores(page) {
        const container = $('.sub-list-deal');
        const start = (page - 1) * pageSize;
        const end = start + pageSize;
        const storesToShow = allStores.slice(start, end);

        if (storesToShow.length > 0) {
            const storeDetailsPromises = storesToShow.map(async store => {
                const response = await fetch(`/Store/GetStoreWithDetailAddress/${store.Id}`);
                return response.json();
            });

            try {
                const storeDetails = await Promise.all(storeDetailsPromises);

                storeDetails.forEach((searchStore, index) => {
                    const store = storesToShow[index];
                    const storeHtml = `
                            <div style="border: 1px solid gray; margin-left: 1%; width: 30%; border-radius: 10px; cursor: pointer; height: 100%" class="store-item" data-id="${searchStore.storeId}">
                                <img style="width: 100%; border-radius: 10px 10px 0 0; height: 100%" src="${searchStore.storeImage}" />
                                <div style="color: black; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; font-size: 14px; padding: 0 5px" title="${searchStore.storeName}">
                                    <strong>${searchStore.storeName}</strong>
                                </div>
                                <div class="address-res" style="color: black; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; font-size: 12px; opacity: 0.6; padding: 0 5px 10px 5px; border-bottom: 0.1px solid black" title="${searchStore.streetName}, ${searchStore.wardName}, ${searchStore.districtName}, ${searchStore.provinceName}">
                                    ${searchStore.streetName}, ${searchStore.wardName}, ${searchStore.districtName}, ${searchStore.provinceName}
                                </div>
                                <div style="color:#187caa; font-weight: bold;font-size: 15px; padding: 5px 10%">
                                    <span style="font-size: 13px"><i class="fas fa-tag" style="color: red !important; margin-right: 3px"></i> Item discount</span>
                                </div>
                            </div>
                        `;
                    container.append(storeHtml);
                });

            } catch (error) {
                console.error("Error fetching store details:", error);
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

        try {
            $('.load-more-district-button').show();
            const response = await fetch(`/Store/GetStoresByDistrict?districtId=${districtId}&page=${page}&pageSize=${pageSize}`);
            if (!response.ok) {
                storeContainer.innerHTML = '';
                return null;
            }

            const stores = await response.json();

            // Clear the container before appending new stores
            if (page === 1) {
                storeContainer.innerHTML = '';
            }

            if (stores.length > 0) {
                stores.forEach(store => {
                    const storeHtml = `
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
                    `;
                    storeContainer.insertAdjacentHTML('beforeend', storeHtml);
                });
            } else {
                $('.load-more-district-button').hide();
                storeContainer.insertAdjacentHTML('beforeend', '<p style="color:blue">No more stores to load.</p>');
            }
        } catch (error) {
            console.error('Error fetching stores:', error);
        }
    }

    const districtSelect = document.querySelector('#district-select'); // Sử dụng ID nếu có

    if (districtSelect) {
        districtSelect.addEventListener('change', function () {
            const districtId = this.value;
            currentPage = 1; // Reset số trang khi thay đổi quận
            console.log(districtId);
            if (districtId !== '-1') {
                loadStoresByDistrict(districtId, currentPage);
            }
        });
    } else {
        console.error('Element with ID "district-select" not found.');
    }

    

    // Event listener for the "Load more" button
    document.querySelector('.load-more-district-button').addEventListener('click', function () {
        currentPage++;
        const districtId = districtSelect.value;

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






