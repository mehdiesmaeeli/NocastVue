<template>
    <!-- ===================================
      START LODAER PAGE
    ==================================== -->
    <!--<section class="loader-page" id="loaderPage">
        <div class="spinner_flash"></div>
    </section>-->
    <!-- START WRAPPER -->
    <div id="wrapper">
        <!-- START CONTENT -->
        <div id="content">
            <!-- ===================================
              START THE HEADER
            ==================================== -->
            <header class="default heade-sticky">
                <div class="un-item-logo">
                    <a href="index.html">
                        <img class="logo-img" src="/images/logo_b.svg" alt="">
                    </a>
                </div>
                <div class="un-block-right">

                    <!-- menu-sidebar -->
                    <div class="menu-sidebar">
                        <button type="button" name="sidebarMenu" aria-label="sidebarMenu" class="btn"
                                data-bs-toggle="modal" data-bs-target="#mdllSidebar-guest">
                            <svg xmlns="http://www.w3.org/2000/svg" width="19" height="9.3" viewBox="0 0 19 9.3">
                                <g id="Group_8081" data-name="Group 8081" transform="translate(-329 -37)">
                                    <rect id="Rectangle_3986" data-name="Rectangle 3986" width="19" height="2.3"
                                          rx="1.15" transform="translate(329 37)" fill="#222032" />
                                    <rect id="Rectangle_3987" data-name="Rectangle 3987" width="19" height="2.3"
                                          rx="1.15" transform="translate(329 44)" fill="#222032" />
                                </g>
                            </svg>
                        </button>
                    </div>
                </div>
            </header>
            <!-- ===================================
              START THE SPACE STICKY
            ==================================== -->
            <div class="space-sticky">
            </div>

            <!-- ===================================
             MAIN CONTENT
            ==================================== -->
            <slot />

            <!-- ===================================
              START THE COPYRIGHT MARK
            ==================================== -->
            <section class="copyright-mark">
                <div class="content">
                    <img class="logo-gray" src="/images/logo-gray.svg" alt="image">
                    <p>حق نشر © Unic 2022</p>
                </div>
            </section>
        </div>
    </div>
    <!-- ===================================
      START THE FILTER MODAL
    ==================================== -->
    <div class="modal sidebarMenu -left--fullScreen modal-filter fade" id="mdllFilter" tabindex="-1"
         aria-labelledby="sidebarMenuLabel3" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="title-modal">فیلترها</h1>
                    <button type="button" class="btn btn-clear">- بازنشانی فیلتر</button>
                    <button type="button" class="btn btnClose" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ri-close-fill"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="slider-range-price">
                        <div class="content-slider">
                            <div class="header">
                                <h2>محدوده قیمت</h2>
                                <div class="auto-price">
                                    <div class="input-text-price min">
                                        <input type="text" class="input-with-keypress-0" id="input-with-keypress-0">
                                        <span>ETH</span>
                                    </div>
                                    <span class="mx-1 color-text">-</span>
                                    <div class="input-text-price max">
                                        <input type="text" class="input-with-keypress-1" id="input-with-keypress-1">
                                        <span>ETH</span>
                                    </div>
                                </div>
                            </div>
                            <div class="steps-slider" id="steps-slider"></div>
                            <div class="price-under-line">
                                <span>0.01 ETH</span>
                                <span>100 ETH</span>
                            </div>
                        </div>
                    </div>
                    <div class="form-filter-checkbox">
                        <h2 class="title-form">دسته ها</h2>
                        <ul class="nav flex-column nav-checkbox">
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
                                        <label class="form-check-label" for="flexCheckDefault">
                                            همه NFT ها
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(15)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" checked type="checkbox" value=""
                                               id="flexCheckDefault2">
                                        <label class="form-check-label" for="flexCheckDefault2">
                                            بازی
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(9)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault3">
                                        <label class="form-check-label" for="flexCheckDefault3">
                                            Art
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(6)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault4">
                                        <label class="form-check-label" for="flexCheckDefault4">
                                            ورزشی
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(3)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault5">
                                        <label class="form-check-label" for="flexCheckDefault5">
                                            جهان های مجازی
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(9)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault6">
                                        <label class="form-check-label" for="flexCheckDefault6">
                                            موسیقی
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(3)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault7">
                                        <label class="form-check-label" for="flexCheckDefault7">
                                            کلکسیونی ها
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(7)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault8">
                                        <label class="form-check-label" for="flexCheckDefault8">
                                            نام های دامنه
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(5)</span>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>

                    <div class="form-filter-checkbox">
                        <h2 class="title-form">وضعیت</h2>
                        <ul class="nav flex-column nav-checkbox">
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value=""
                                               id="statusCheckDefault">
                                        <label class="form-check-label" for="statusCheckDefault">
                                            هم اکنون خریداری کنید
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(15)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" checked type="checkbox" value=""
                                               id="statusCheckDefault2">
                                        <label class="form-check-label" for="statusCheckDefault2">
                                            در حراج
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(9)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value=""
                                               id="statusCheckDefault3">
                                        <label class="form-check-label" for="statusCheckDefault3">
                                            جدید
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(6)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" checked type="checkbox" value=""
                                               id="statusCheckDefault4">
                                        <label class="form-check-label" for="statusCheckDefault4">
                                            دارای پیشنهادات
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(3)</span>
                                    </div>
                                </div>
                            </li>

                        </ul>
                    </div>

                    <div class="form-filter-checkbox">
                        <h2 class="title-form">Colors</h2>
                        <ul class="nav flex-column nav-checkbox">
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value=""
                                               id="colorsCheckDefault">
                                        <label class="form-check-label" for="colorsCheckDefault">
                                            رنگ صورتی
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(15)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" checked type="checkbox" value=""
                                               id="colorsCheckDefault2">
                                        <label class="form-check-label" for="colorsCheckDefault2">
                                            آبی
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(9)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value=""
                                               id="colorsCheckDefault3">
                                        <label class="form-check-label" for="colorsCheckDefault3">
                                            قرمز
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(6)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value=""
                                               id="colorsCheckDefault4">
                                        <label class="form-check-label" for="colorsCheckDefault4">
                                            نارنجی
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(3)</span>
                                    </div>
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="item-checkbox-filter">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value=""
                                               id="colorsCheckDefault5">
                                        <label class="form-check-label" for="colorsCheckDefault5">
                                            زرد
                                        </label>
                                    </div>
                                    <div class="number-category">
                                        <span>(3)</span>
                                    </div>
                                </div>
                            </li>

                        </ul>
                    </div>

                </div>
                <div class="modal-footer justify-content-center border-0 pt-2">
                    <a href="page-search-random.html" class="btn btn-apply-filter">
                        <p>اعمال <span>(5)</span></p>
                        <div class="ico">
                            <i class="ri-arrow-drop-left-line"></i>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <!-- ===================================
      START THE NFT DETAILS MODAL
    ==================================== -->
    <div class="modal -left --fullScreen modal-collectibles fade" id="mdllCollectibles" tabindex="-1"
         aria-labelledby="modalFilterLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="">
                        <h1>سمت تاریک من</h1>
                        <p>12 نسخه صادر شد</p>
                    </div>
                    <button type="button" class="btn btnClose" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ri-close-fill"></i>
                    </button>
                </div>
                <div class="modal-body p-0">

                    <div class="un-details-collectibles">
                        <!-- head -->
                        <div class="head">
                            <div class="cover-main-img mt-0">
                                <picture>
                                    <source srcset="/images/other/11.webp" type="image/webp">
                                    <img class="img-full" src="/images/other/11.jpg" alt="">
                                </picture>
                                <span class="btn-xs-size bg-dark text-white rounded-pill item-category">
                                    دیجیتال
                                    هنر
                                </span>
                                <div class="action-sticky">
                                    <button type="button" class="btn btn-fullScreen">
                                        <i class="ri-fullscreen-fill"></i>
                                    </button>
                                    <button type="button" class="btn btn-share" data-bs-dismiss="model"
                                            data-bs-toggle="modal" data-bs-target="#mdllShareCollectibles">
                                        <i class="ri-share-forward-line"></i>
                                    </button>
                                </div>
                            </div>

                            <div class="title-card-text d-flex align-items-center justify-content-between">
                                <a href="page-creator-profile.html" class="item-profile-creator visited">
                                    <div class="wrapper-image">
                                        <picture>
                                            <source srcset="/images/avatar/14.webp" type="image/webp">
                                            <img class="avt-img" src="/images/avatar/14.jpg" alt="image">
                                        </picture>
                                        <div class="icon"><i class="ri-checkbox-circle-fill"></i></div>
                                    </div>
                                    <div class="txt-user">
                                        <h5>خالق</h5>
                                        <p>ویلای شلی</p>
                                    </div>
                                </a>
                                <div class="btn-like-click shape-box">
                                    <div class="btnLike">
                                        <input type="checkbox">
                                        <span class="count-likes">3,62 K</span>
                                        <div class="icon-inside">
                                            <i class="ri-heart-3-line"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <di class="txt-price-coundown d-flex justify-content-between">
                                <div class="price">
                                    <h2> پیشنهاد اولیه</h2>
                                    <p>2.3 <span class="size-16">ETH</span> <span class="dollar">(8,350)</span></p>
                                </div>
                                <!-- <div class="coundown">
                                    <h3>Auction Ends In</h3>
                                    <span>08H 38M 16S</span>
                                </div> -->
                            </di>
                        </div>
                        <!-- body -->
                        <div class="body">
                            <div class="description">
                                <p>
                                    روی نفس خود تمرکز کنید زیرا این آرامش بی وقفه باز و بسته می شود.
                                </p>
                            </div>
                            <ul class="nav nav-pills nav-pilled-tab" id="pills-tab" role="tablist">
                                <li class="nav-item" role="presentation">
                                    <button class="nav-link active" id="pills-Owner-tab" data-bs-toggle="pill"
                                            data-bs-target="#pills-Owner" type="button" role="tab"
                                            aria-controls="pills-Owner" aria-selected="true">
                                        مالک
                                    </button>
                                </li>
                                <li class="nav-item" role="presentation">
                                    <button class="nav-link" id="pills-History-tab" data-bs-toggle="pill"
                                            data-bs-target="#pills-History" type="button" role="tab"
                                            aria-controls="pills-History" aria-selected="false">
                                        تاریخچه
                                    </button>
                                </li>
                                <li class="nav-item" role="presentation">
                                    <button class="nav-link" id="pills-Bids-tab" data-bs-toggle="pill"
                                            data-bs-target="#pills-Bids" type="button" role="tab" aria-controls="pills-Bids"
                                            aria-selected="false">
                                        مناقصه
                                    </button>
                                </li>
                            </ul>

                            <div class="tab-content content-custome-data" id="pills-tabContent">
                                <div class="tab-pane fade show active" id="pills-Info" role="tabpanel"
                                     aria-labelledby="pills-Info-tab">
                                    <ul class="nav flex-column nav-users-profile margin-t-20">
                                        <li class="nav-item">
                                            <div class="nav-link">
                                                <a href="page-creator-profile.html" class="item-user-img visited">
                                                    <div class="wrapper-image">
                                                        <picture>
                                                            <source srcset="/images/avatar/14.webp" type="image/webp">
                                                            <img class="avt-img" src="/images/avatar/14.jpg" alt="">
                                                        </picture>

                                                        <div class="icon"><i class="ri-checkbox-circle-fill"></i></div>
                                                    </div>
                                                    <div class="txt-user">
                                                        <h5>خالق</h5>
                                                        <p>ویلای شلی</p>
                                                    </div>
                                                </a>
                                            </div>
                                        </li>
                                        <li class="nav-item">
                                            <div class="nav-link">
                                                <a href="page-creator-profile.html" class="item-user-img visited">
                                                    <div class="wrapper-image">
                                                        <picture>
                                                            <source srcset="/images/avatar/13.webp" type="image/webp">
                                                            <img class="avt-img" src="/images/avatar/13.jpg" alt="">
                                                        </picture>
                                                        <div class="icon"><i class="ri-checkbox-circle-fill"></i></div>
                                                    </div>
                                                    <div class="txt-user">
                                                        <h5>مالک</h5>
                                                        <p>مستاجر</p>
                                                    </div>
                                                </a>
                                                <div class="other-option">
                                                    <button type="button" class="btn btn-copy-address">
                                                        <input type="checkbox">
                                                        <span>0xe388...e162</span>
                                                        <div class="icon-box">
                                                            <i class="ri-file-copy-2-line"></i>
                                                        </div>
                                                    </button>
                                                </div>
                                            </div>
                                        </li>

                                    </ul>
                                </div>
                                <div class="tab-pane fade" id="pills-Owner" role="tabpanel"
                                     aria-labelledby="pills-Owner-tab">

                                    <ul class="nav flex-column nav-users-profile margin-t-20">
                                        <li class="nav-item">
                                            <div class="nav-link">
                                                <a href="page-creator-profile.html" class="item-user-img visited">
                                                    <div class="wrapper-image">
                                                        <picture>
                                                            <source srcset="/images/avatar/13.webp" type="image/webp">
                                                            <img class="avt-img" src="/images/avatar/13.jpg" alt="">
                                                        </picture>
                                                        <div class="icon"><i class="ri-checkbox-circle-fill"></i></div>
                                                    </div>
                                                    <div class="txt-user">
                                                        <h5>مالک</h5>
                                                        <p>مستاجر</p>
                                                    </div>
                                                </a>
                                                <div class="other-option">
                                                    <button type="button" class="btn btn-copy-address">
                                                        <input type="checkbox">
                                                        <span>0xe388...e162</span>
                                                        <div class="icon-box">
                                                            <i class="ri-file-copy-2-line"></i>
                                                        </div>
                                                    </button>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <div class="tab-pane fade" id="pills-History" role="tabpanel"
                                     aria-labelledby="pills-History-tab">
                                    <ul class="nav flex-column nav-users-profile margin-t-20">
                                        <li class="nav-item">
                                            <div class="nav-link">
                                                <a href="page-creator-profile.html" class="item-user-img visited">
                                                    <div class="wrapper-image">
                                                        <picture>
                                                            <source srcset="/images/avatar/8.webp" type="image/webp">
                                                            <img class="avt-img" src="/images/avatar/8.png" alt="">
                                                        </picture>
                                                    </div>
                                                    <div class="txt-user">
                                                        <h5>16 روز قبل</h5>
                                                        <p class="weight-400 size-14">
                                                            <span class="color-text">
                                                                خرید شده
                                                                توسط
                                                            </span>
                                                            کوچک <span class="color-text">برای</span> <span class="color-green">300,000 تومان</span>
                                                        </p>
                                                    </div>
                                                </a>
                                            </div>
                                        </li>
                                        <li class="nav-item">
                                            <div class="nav-link">
                                                <a href="page-creator-profile.html" class="item-user-img visited">
                                                    <div class="wrapper-image">
                                                        <picture>
                                                            <source srcset="/images/avatar/17.webp" type="image/webp">
                                                            <img class="avt-img" src="/images/avatar/17.jpg" alt="">
                                                        </picture>
                                                    </div>
                                                    <div class="txt-user">
                                                        <h5>24 روز قبل</h5>
                                                        <p class="weight-400 size-14">
                                                            <span class="color-text">
                                                                پیشنهاد ارائه شده توسط
                                                            </span> Pingu
                                                            <span class="color-text">برای</span> <span class="color-green">150,000 تومان</span>
                                                        </p>
                                                    </div>
                                                </a>
                                            </div>
                                        </li>
                                        <li class="nav-item">
                                            <div class="nav-link">
                                                <a href="page-creator-profile.html" class="item-user-img visited">
                                                    <div class="wrapper-image">
                                                        <picture>
                                                            <source srcset="/images/avatar/18.webp" type="image/webp">
                                                            <img class="avt-img" src="/images/avatar/18.jpg" alt="">
                                                        </picture>
                                                    </div>
                                                    <div class="txt-user">
                                                        <h5>26 روز قبل</h5>
                                                        <p class="weight-400 size-14">
                                                            <span class="color-text">
                                                                پیشنهاد ارائه شده توسط
                                                            </span> وینیسیوس
                                                            <span class="color-text">برای</span> <span class="color-green">250,000 تومان</span>
                                                        </p>
                                                    </div>
                                                </a>
                                            </div>
                                        </li>

                                    </ul>
                                </div>
                                <div class="tab-pane fade" id="pills-Bids" role="tabpanel"
                                     aria-labelledby="pills-Bids-tab">
                                    <ul class="nav flex-column nav-users-profile margin-t-20">

                                        <li class="nav-item">
                                            <div class="nav-link">
                                                <a href="page-creator-profile.html" class="item-user-img visited">
                                                    <div class="wrapper-image">
                                                        <picture>
                                                            <source srcset="/images/avatar/12.webp" type="image/webp">
                                                            <img class="avt-img" src="/images/avatar/12.png" alt="">
                                                        </picture>
                                                    </div>
                                                    <div class="txt-user">
                                                        <h5>24 روز قبل</h5>
                                                        <p class="weight-400 size-14">
                                                            پینگو
                                                            <span class="color-text">
                                                                پیشنهاد برای
                                                            </span>
                                                            <span class="color-green">300,000 تومان</span>
                                                        </p>
                                                    </div>
                                                </a>
                                            </div>
                                        </li>
                                        <li class="nav-item">
                                            <div class="nav-link">
                                                <a href="page-creator-profile.html" class="item-user-img visited">
                                                    <div class="wrapper-image">
                                                        <picture>
                                                            <source srcset="/images/avatar/7.webp" type="image/webp">
                                                            <img class="avt-img" src="/images/avatar/7.jpg" alt="">
                                                        </picture>
                                                    </div>
                                                    <div class="txt-user">
                                                        <h5>24 روز قبل</h5>
                                                        <p class="weight-400 size-14">
                                                            پینگو
                                                            <span class="color-text">
                                                                پیشنهاد برای
                                                            </span>
                                                            <span class="color-green">300,000 تومان</span>
                                                        </p>
                                                    </div>
                                                </a>
                                            </div>
                                        </li>

                                    </ul>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
                <div class="modal-footer d-block border-0 pt-2">
                    <div class="content-modal-footer">
                        <div class="links-item-pages">
                            <a href="page-collectibles-details.html" class="icon-box prev">
                                <i class="ri-arrow-left-line"></i>
                            </a>
                            <a href="page-collectibles-details.html" class="icon-box next">
                                <i class="ri-arrow-right-line"></i>
                            </a>
                        </div>
                        <a href="javascript: void(0)" class="btn btn-bid-items">
                            <p>خرید برای <span class="size-13">(2.3ETH)</span></p>
                            <div class="ico">
                                <i class="ri-arrow-drop-right-line"></i>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ===================================
      START THE SHARE PROFILE MODAL
    ==================================== -->
    <div class="modal transition-bottom screenFull defaultModal mdlladd__rate fade" id="mdllShareProfile" tabindex="-1"
         aria-labelledby="modalShareProfile" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="item-shared">
                        <div class="image-items">
                            <picture>
                                <source srcset="/images/avatar/22.webp" type="image/webp">
                                <img class="user-img" src="/images/avatar/22.jpg" alt="">
                            </picture>
                        </div>
                        <div class="txt">
                            <h1>زهرا حبیبی</h1>
                            <p>unic.com</p>
                        </div>
                    </div>
                    <button type="button" class="btn btnClose" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ri-close-fill"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="content-share-socials">

                        <div class="un-navMenu-default p-0">

                            <ul class="nav flex-column">
                                <li class="nav-item">
                                    <button type="button" class="btn nav-link bg-snow">
                                        <div class="item-content-link">
                                            <h3 class="link-title">کپی</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-file-copy-2-line"></i>
                                            </div>
                                        </div>
                                    </button>
                                </li>
                            </ul>

                            <div class="sub-title-pkg">
                                <h2>شبکه های اجتماعی</h2>
                            </div>

                            <ul class="nav flex-column">
                                <li class="nav-item">
                                    <a class="nav-link facebook" href="javascript: void(0)">
                                        <div class="item-content-link">
                                            <div class="icon-svg">
                                                <img src="/images/icons/facebook.svg" alt="">
                                            </div>
                                            <h3 class="link-title">فیس بوک</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-arrow-drop-left-line"></i>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link twitter" href="javascript: void(0)">
                                        <div class="item-content-link">
                                            <div class="icon-svg">
                                                <img src="/images/icons/twitter.svg" alt="">
                                            </div>
                                            <h3 class="link-title">تویتر</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-arrow-drop-left-line"></i>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link instrgrame" href="javascript: void(0)">
                                        <div class="item-content-link">
                                            <div class="icon-svg">
                                                <img src="/images/icons/instagram.svg" alt="">
                                            </div>
                                            <h3 class="link-title">اینستاگرام</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-arrow-drop-left-line"></i>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link whatsapp" href="javascript: void(0)">
                                        <div class="item-content-link">
                                            <div class="icon-svg">
                                                <img src="/images/icons/whatsapp.svg" alt="">
                                            </div>
                                            <h3 class="link-title">واتس اپ</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-arrow-drop-left-line"></i>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                            </ul>
                        </div>

                    </div>

                </div>
                <div class="modal-footer border-0">
                    <div class="env-pb"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- ===================================
      START THE SHARE NFT MODAL
    ==================================== -->
    <div class="modal transition-bottom screenFull defaultModal mdlladd__rate fade" id="mdllShareCollectibles"
         tabindex="-1" aria-labelledby="modalShareCollectibles" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="item-shared">
                        <div class="image-items">
                            <picture>
                                <source srcset="/images/other/1.webp" type="image/webp">
                                <img class="user-img" src="/images/other/1.jpg" alt="">
                            </picture>
                        </div>
                        <div class="txt">
                            <h1>کهکشان روی زمین</h1>
                            <p>unic.com</p>
                        </div>
                    </div>
                    <button type="button" class="btn btnClose" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ri-close-fill"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="content-share-socials">

                        <div class="un-navMenu-default p-0">

                            <ul class="nav flex-column">
                                <li class="nav-item">
                                    <button type="button" class="btn nav-link bg-snow ">
                                        <div class="item-content-link">
                                            <h3 class="link-title">کپی</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-file-copy-2-line"></i>
                                            </div>
                                        </div>
                                    </button>
                                </li>
                            </ul>

                            <div class="sub-title-pkg">
                                <h2>شبکه های اجتماعی</h2>
                            </div>

                            <ul class="nav flex-column">
                                <li class="nav-item">
                                    <a class="nav-link facebook" href="javascript: void(0)">
                                        <div class="item-content-link">
                                            <div class="icon-svg">
                                                <img src="/images/icons/facebook.svg" alt="">
                                            </div>
                                            <h3 class="link-title">فیس بوک</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-arrow-drop-left-line"></i>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link twitter" href="javascript: void(0)">
                                        <div class="item-content-link">
                                            <div class="icon-svg">
                                                <img src="/images/icons/twitter.svg" alt="">
                                            </div>
                                            <h3 class="link-title">تویتر</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-arrow-drop-left-line"></i>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link instrgrame" href="javascript: void(0)">
                                        <div class="item-content-link">
                                            <div class="icon-svg">
                                                <img src="/images/icons/instagram.svg" alt="">
                                            </div>
                                            <h3 class="link-title">اینستاگرام</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-arrow-drop-left-line"></i>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link whatsapp" href="javascript: void(0)">
                                        <div class="item-content-link">
                                            <div class="icon-svg">
                                                <img src="/images/icons/whatsapp.svg" alt="">
                                            </div>
                                            <h3 class="link-title">واتس اپ</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-arrow-drop-left-line"></i>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                            </ul>
                        </div>

                    </div>

                </div>
                <div class="modal-footer border-0">
                    <div class="env-pb"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- ===================================
      START THE BIO DETAILS MODAL
    ==================================== -->
    <div class="modal transition-bottom screenFull defaultModal mdlladd__rate fade" id="mdllBioDetails" tabindex="-1"
         aria-labelledby="modalBioDetails" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="icon-socialNetworks">
                        <a href="javascript: void(0)" class="btn btn-social">
                            <img src="/images/icons/facebook.svg" alt="">
                        </a>
                        <a href="javascript: void(0)" class="btn btn-social">
                            <img src="/images/icons/instagram.svg" alt="">
                        </a>
                        <a href="javascript: void(0)" class="btn btn-social">
                            <img src="/images/icons/twitter.svg" alt="">
                        </a>
                    </div>
                    <button type="button" class="btn btnClose" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ri-close-fill"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="content-upload-item">
                        <h2 class="size-16 weight-500 text-dark margin-b-10">بیوگرافی</h2>
                        <p>
                            کامیلو در ونکوور، بریتیش کلمبیا زندگی می کند. وقتی وقتش را صرف دویدن نمی کند
                            او احتمالاً سرش را به صفحه چسبانده است و سعی می کند یکی از ایده های وحشی خود را خلق کند
                            در سرش می دوند کریستین یک هنرمند دیجیتال سورئالیست است که بدنه ای از
                            کار با تکیه بر تکنیک های شبیه سازی او از کارهای انتزاعی، علمی تخیلی و
                            طبیعت او که به عنوان یک نقاش و هنرمند موشن گرافیک آموزش دیده، وارد عرصه دیجیتال شده است
                            جایی که او می تواند هر چیزی را که به ذهنش می رسد خلق کند.
                        </p>

                    </div>

                </div>
                <div class="modal-footer border-0">
                    <div class="env-pb"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- ===================================
      START THE UPLOAD MODAL
    ==================================== -->
    <div class="modal transition-bottom screenFull defaultModal mdlladd__rate fade" id="mdllUploadItem" tabindex="-1"
         aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="title-modal">آپلود مورد</h1>
                    <button type="button" class="btn btnClose" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ri-close-fill"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="content-upload-item text-center">
                        <p>
                            اگر می خواهید کلکسیون شما در نوع خود بی نظیر باشد، <span>"Single"</span> را انتخاب کنید
                            <span>"چند"</span>
                            اگر می خواهید
                            برای فروش چندین بار یک مجموعه
                        </p>
                        <div class="grid_buttonUpload">
                            <a href="page-create-single.html" class="btn btn-create bg-primary text-white margin-b-20">
                                ایجاد تک
                            </a>
                            <a href="page-create-multi.html"
                               class="btn btn-create bg-white border-solid border-snow text-dark">
                                چندگانه ایجاد کنید
                            </a>
                        </div>
                    </div>

                </div>
                <div class="modal-footer border-0">
                    <div class="env-pb"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- ===================================
      START THE ADD ETH MODAL
    ==================================== -->
    <div class="modal transition-bottom screenFull defaultModal mdlladd__rate fade" id="mdllAddETH" tabindex="-1"
         aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="title-modal">ETH را به کیف پول خود اضافه کنید</h1>
                    <button type="button" class="btn btnClose" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ri-close-fill"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="content-upload-item">
                        <p class="text-center">
                            یکی از گزینه ها را برای واریز <br> ETH به کیف پول خود انتخاب کنید
                        </p>
                        <div class="un-navMenu-default margin-t-30 p-0">
                            <ul class="nav flex-column">
                                <li class="nav-item mb-3">
                                    <a class="nav-link effect-click" href="javascript: void(0)">
                                        <div class="item-content-link">
                                            <div class="icon color-text w-auto">
                                                <i class="ri-exchange-box-line"></i>
                                            </div>
                                            <h3 class="link-title">واریز از صرافی</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-arrow-drop-left-line"></i>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li class="nav-item mb-0">
                                    <a class="nav-link effect-click" href="javascript: void(0)">
                                        <div class="item-content-link">
                                            <div class="icon color-text w-auto">
                                                <i class="ri-bank-card-line"></i>
                                            </div>
                                            <h3 class="link-title">با کارت بخرید</h3>
                                        </div>
                                        <div class="other-cc">
                                            <span class="badge-text"></span>
                                            <div class="icon-arrow">
                                                <i class="ri-arrow-drop-left-line"></i>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                            </ul>
                        </div>

                    </div>

                </div>
                <div class="modal-footer border-0">
                    <div class="env-pb"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- ===================================
      START THE SIDEBAR MENU - CONNECTED MODAL
    ==================================== -->
    <div class="modal sidebarMenu -left fade" id="mdllSidebar-connected" tabindex="-1"
         aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header d-block pb-1">

                    <!-- un-user-profile -->
                    <div class="un-user-profile">
                        <div class="image_user">
                            <picture>
                                <source srcset="/images/avatar/11.webp" type="image/webp">
                                <img src="/images/avatar/11.jpg" alt="image">
                            </picture>
                        </div>
                        <div class="text-user">
                            <h3>زهرا حبیبی</h3>
                            <p>0xe3oowe0b88...E162</p>
                        </div>
                    </div>

                    <button type="button" class="btn btnClose" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ri-close-fill"></i>
                    </button>

                    <!-- cover-balance -->
                    <div class="cover-balance">
                        <div class="un-balance">
                            <div class="content-balance">
                                <div class="head-balance">
                                    <h4>موجودی من</h4>
                                    <a class="btn link-addBalance" data-bs-toggle="modal" data-bs-dismiss="modal"
                                       data-bs-target="#mdllAddETH">
                                        <i class="ri-add-fill"></i>
                                    </a>
                                </div>
                                <p class="no-balance">3,650 ETH</p>
                            </div>
                        </div>
                        <button type="button" class="btn btn-sm-size bg-white text-dark rounded-pill"
                                data-bs-toggle="modal" data-bs-dismiss="modal" data-bs-target="#mdllUploadItem">
                            ايجاد كردن
                        </button>
                    </div>


                </div>
                <div class="modal-body">
                    <ul class="nav flex-column -active-links">
                        <li class="nav-item">
                            <a class="nav-link" href="homepage.html">
                                <div class="icon_current">
                                    <i class="ri-compass-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-compass-fill"></i>
                                </div>
                                <span class="title_link">کشف</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="app-homes.html">
                                <div class="icon_current">
                                    <i class="ri-home-5-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-home-5-fill"></i>
                                </div>
                                <span class="title_link">سبک‌های خانه</span>

                                <span class="xs-badge">8</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="app-pages.html">
                                <div class="icon_current">
                                    <i class="ri-pages-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-pages-fill"></i>
                                </div>
                                <span class="title_link">بسته‌های صفحه</span>

                                <div class="badge-circle">
                                    <span class="doted_item"></span>
                                </div>
                            </a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link" href="app-components.html">
                                <div class="icon_current">
                                    <i class="ri-layout-2-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-layout-2-fill"></i>
                                </div>
                                <span class="title_link">اجزا</span>

                            </a>
                        </li>

                        <label class="title__label">سایر</label>

                        <li class="nav-item">
                            <a class="nav-link" href="page-help.html">
                                <div class="icon_current">
                                    <i class="ri-questionnaire-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-questionnaire-fill"></i>
                                </div>
                                <span class="title_link">مرکز راهنمایی</span>
                            </a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link" href="page-about.html">
                                <div class="icon_current">
                                    <i class="ri-file-info-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-file-info-fill"></i>
                                </div>
                                <span class="title_link">درباره Unic.</span>
                            </a>
                        </li>

                        <li class="nav-item">
                            <a href="homepage.html" class="nav-link">
                                <div class="icon_current">
                                    <i class="ri-logout-box-r-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-logout-box-r-fill"></i>
                                </div>
                                <span class="title_link">خروج از سیستم</span>
                            </a>
                        </li>

                    </ul>
                </div>
                <div class="modal-footer">
                    <div class="em_darkMode_menu">
                        <label class="text" for="switchDark">
                            <h3>حالت تاریک</h3>
                            <p>مرور در حالت شب</p>
                        </label>
                        <label class="switch_toggle toggle_lg theme-switch" for="switchDark">
                            <input type="checkbox" class="switchDarkMode theme-switch" id="switchDark"
                                   aria-describedby="switchDark">
                            <span class="handle"></span>
                        </label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ===================================
      START THE SIDEBAR MENU - guest MODAL
    ==================================== -->
    <div class="modal sidebarMenu -left -guest fade" id="mdllSidebar-guest" tabindex="-1"
         aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="welcome_em">
                        <h2>به Unic<span>.</span> خوش آمدید</h2>
                        <p>
                            کیف پول خود را وصل کنید تا بتوانید مرور کنید، خرید و فروش کنید و آیتم‌های NFT بسازید.
                        </p>
                        <a href="page-connect-wallet.html" class="btn btn-md-size bg-primary text-white rounded-pill">
                            وصل کردن کیف پول
                        </a>
                    </div>
                    <button type="button" class="btn btnClose" data-bs-dismiss="modal" aria-label="بستن">
                        <i class="ri-close-fill"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <ul class="nav flex-column -active-links">
                        <li class="nav-item">
                            <a class="nav-link" href="homepage.html">
                                <div class="icon_current">
                                    <i class="ri-compass-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-compass-fill"></i>
                                </div>
                                <span class="title_link">کشف</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="app-homes.html">
                                <div class="icon_current">
                                    <i class="ri-home-5-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-home-5-fill"></i>
                                </div>
                                <span class="title_link">سبک‌های صفحه اصلی</span>

                                <span class="xs-badge">8</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="app-pages.html">
                                <div class="icon_current">
                                    <i class="ri-pages-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-pages-fill"></i>
                                </div>
                                <span class="title_link">پکیج‌های صفحه</span>

                                <div class="badge-circle">
                                    <span class="doted_item"></span>
                                </div>
                            </a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link" href="app-components.html">
                                <div class="icon_current">
                                    <i class="ri-layout-2-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-layout-2-fill"></i>
                                </div>
                                <span class="title_link">کامپوننت‌ها</span>

                            </a>
                        </li>

                        <label class="title__label">سایر</label>

                        <li class="nav-item">
                            <a class="nav-link" href="page-help.html">
                                <div class="icon_current">
                                    <i class="ri-questionnaire-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-questionnaire-fill"></i>
                                </div>
                                <span class="title_link">مرکز کمک</span>
                            </a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link" href="page-about.html">
                                <div class="icon_current">
                                    <i class="ri-file-info-line"></i>
                                </div>
                                <div class="icon_active">
                                    <i class="ri-file-info-fill"></i>
                                </div>
                                <span class="title_link">درباره Unic.</span>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="modal-footer">
                    <div class="em_darkMode_menu">
                        <label class="text" for="switchDark2">
                            <h3>حالت تاریک</h3>
                            <p>مرور در حالت شب</p>
                        </label>
                        <label class="switch_toggle toggle_lg theme-switch" for="switchDark2">
                            <input type="checkbox" class="switchDarkMode theme-switch" id="switchDark2"
                                   aria-describedby="switchDark2">
                            <span class="handle"></span>
                        </label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ===================================
      START STATUS CONNECTION
    ==================================== -->
    <div class="d-flex justify-content-center">
        <div class="toast status-connection" role="alert" aria-live="assertive" aria-atomic="true"></div>
    </div>



</template>

<script setup>
    const title = ref('Unic – قالب موبایل PWA بازار NFT')
    const description = ref('Unic – قالب موبایل PWA بازار NFT')
        
</script>
