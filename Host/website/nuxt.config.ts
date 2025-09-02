export default defineNuxtConfig({
    devtools: { enabled: true },
    runtimeConfig: {
        public: {
            apiBase: process.env.NUXT_PUBLIC_API_BASE || 'http://localhost:5004/api' // میتونی از .env هم بخونی
        }
    },
    postcss: {
        plugins: {
            tailwindcss: {},
            autoprefixer: {},
        },
    },
    css: [
        '~/public/css/style.css',
        '~/public/css/remixicon.min.css',
        '~/assets/css/tailwind.css',
        '~/public/vendors/swiper/swiper-bundle.min.css'
    ],
    app: {
        head: {
            htmlAttrs: { lang: 'fa', dir: 'rtl' },
            meta: [
                { charset: 'utf-8' },
                { name: 'viewport', content: 'width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=5, viewport-fit=cover' },
                { name: 'apple-mobile-web-app-capable', content: 'yes' },
                { name: 'apple-mobile-web-app-status-bar-style', content: 'default' },
                { name: 'format-detection', content: 'telephone=no' },
                { name: 'theme-color', content: '#ffffff', media: '(prefers-color-scheme: light)' },
                { name: 'theme-color', content: '#222032', media: '(prefers-color-scheme: dark)' },
                { name: 'description', content: 'Unic – قالب موبایل PWA بازار NFT' },
                { name: 'keywords', content: 'بوت‌استرپ ۵، قالب موبایل، کیف پول، ارز دیجیتال، بازار، PWA' }
            ],
            link: [
                { rel: 'icon', type: 'image/png', href: '/images/favicon/icon-32x32.png', sizes: '32x32' },
                { rel: 'apple-touch-icon', href: '/images/favicon/icon-96x96.png' },
                { rel: 'manifest', href: '/_manifest.json' }
            ],
            script: [
                { src: '/vendors/zuck_stories/zuck.min.js', defer: true },
                { src: '/vendors/smoothscroll/smoothscroll.min.js', defer: true },
                { src: '/vendors/swiper/swiper-bundle.min.js', defer: true },
                { src: '/vendors/nouislider/nouislider.min.js', defer: true },
                { src: '/vendors/nouislider/wNumb.min.js', defer: true },
                { src: '/js/bootstrap.bundle.min.js', defer: true },
                { src: '/js/custom.js', defer: true },
                { src: '/js/pwa-services.js', defer: true }
            ]
        }
    }
})