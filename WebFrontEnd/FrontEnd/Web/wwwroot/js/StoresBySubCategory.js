function loadPage(page) {
    $.ajax({
        type: 'GET',
        url: '/Store/GetStoresBySubCategory',
        data: {
            subCategoryId: subId,
            page: page,
            pageSize: 5,
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
