<template>
    <!-- START WRAPPER -->
    <div id="wrapper">
        <!-- START CONTENT -->
        <div id="content">
            <!-- ===================================
              شروع هدر
            ==================================== -->
            <header class="default heade-sticky">
                <div class="un-title-page go-back">
                    <a @click="$router.back()" class="icon">
                        <i class="ri-arrow-drop-right-line"></i>
                    </a>
                    <h1></h1>
                </div>
                <div class="un-block-right">
                    <a @click="$router.push('/')" class="btn nav-link text-primary size-14 weight-500 pe-0">خانه</a>
                </div>
            </header>
            <!-- ===================================
              شروع فضای چسبنده
            ==================================== -->
            <div class="space-sticky"></div>
            <!-- ===================================
              شروع فرم
            ==================================== -->
            <slot />
            <!-- ===================================
              شروع فوتر حساب
            ==================================== -->
            <div aria-live="polite" aria-atomic="true" class="d-flex justify-content-center place__top -full w-100">
                <!-- توست دوم -->
                <div id="liveToastTwo" class="toast --shadow fullscreen" role="alert" aria-live="assertive" aria-atomic="true" data-bs-autohide="true" data-bs-delay="5000">
                    <div class="toast-body">
                        <div class="icon color-orange"><i class="ri-alert-fill"></i></div>
                        <div class="content">
                            <div class="display__text">
                                <p>پروفایل خود را کامل کنید.</p>
                                <a href="page-edit-profile.html" class="display-link color-orange">برو به تنظیمات</a>
                            </div>
                        </div>
                        <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"><i class="ri-close-fill"></i></button>
                    </div>
                </div>
            </div>
            <footer class="footer-account">
                <div class="env-pb">
                    <slot name="footer"></slot>
                    <div class="dividar"></div>
                    <section class="copyright-mark-simple">
                        <div class="content">
                            <img class="logo-gray" src="/images/logo-gray.svg" alt="image">
                        </div>
                    </section>
                </div>
            </footer>
        </div>
    </div>
</template>

<script setup>

</script>

<style>
    .copyright-mark-simple {
        padding-top: 20px;
        padding-left:20px;
        direction:ltr;
    }
</style>
