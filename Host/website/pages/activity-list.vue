<template>
    <div id="wrapper">
        <div id="content">
            <header class="default heade-sticky">
                <div class="un-title-page go-back">
                    <a @click="$router.back()" class="icon"><i class="ri-arrow-drop-right-line"></i></a>
                    <slot name="header"></slot>

                </div>
            </header>
            <div class="space-sticky"></div>
            <section class="un-details-collectibles">

                <div class="head">
                    <div class="title-card-text d-flex align-items-center justify-content-between">
                        <div class="text">
                            <h1>کهکشان روی زمین</h1>
                            <p>12 نسخه های ضرب شده</p>
                        </div>
                        <span class="btn-xs-size bg-pink text-white rounded-pill">ورزشی</span>
                    </div>
                    <div class="txt-price-coundown d-flex justify-content-between">
                        <div class="price">
                            <h2>پیشنهاد اولیه</h2>
                            <p>2.3<span class="size-16">ETH</span><span class="dollar">(8,350)</span></p>
                        </div>
                    </div>
                </div>
                <div class="body">
                    <div class="description">
                        <p>بر روی تنفس خود تمرکز کنید زیرا این آرامش به طور بی‌پایان باز و بسته می‌شود.</p>
                    </div>

                    <div class="tab-content content-custome-data" id="pills-tabContent">
                        <div class="tab-pane fade show active" id="pills-Info" role="tabpanel" aria-labelledby="pills-Info-tab">
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
                                                <h5>سازنده</h5>
                                                <p>شلی ویلا</p>
                                            </div>
                                        </a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="space-sticky-footer"></div>
                <div class="footer">
                    <div class="content">
                        <div class="links-item-pages">
                            <a href="page-collectibles-details.html" class="icon-box prev"><i class="ri-arrow-right-line"></i></a>
                            <a href="page-collectibles-details.html" class="icon-box next"><i class="ri-arrow-left-line"></i></a>
                        </div>
                        <a href="javascript: void(0)" class="btn btn-bid-items">
                            <p>اقدام میکنم</p>
                            <div class="ico"><i class="ri-arrow-drop-left-line"></i></div>
                        </a>
                    </div>
                </div>
            </section>
        </div>
    </div>
    
</template>

<script setup>
    definePageMeta({
        layout: false,
    });
</script>