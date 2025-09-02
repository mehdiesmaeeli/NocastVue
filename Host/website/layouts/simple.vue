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
            <slot />
            <div class="space-sticky-footer"></div>
            <footer class="footer-pages-forms">
                <div class="content">
                    <slot name="footer"></slot>
                </div>
            </footer>
        </div>
    </div>
</template>

