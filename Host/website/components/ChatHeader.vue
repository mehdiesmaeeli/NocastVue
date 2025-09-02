<template>
    <div class="main-set">
        <div class="em_-xv5">
            <a class="btn-m6f bg-fnm rounded-ivi content-lbp" href="app-pages.html">
                <i class="tio-2w2"></i>
            </a>
        </div>
        <div class="item-jar ml-ola">
            <div class="media-hoy">
                <img class="img-nno" src="https://nepro.orinostudio.com/preview/assets/img/persons/16.png">
                <div class="media-2ms my-4kl">
                    <div class="ymxiv">
                        <h1>Virginia Wooten</h1>
                        <p class="col-6xt">Online</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="em_-xv5">
        </div>
    </div>
</template>

<script>
export default {
  props: {
    avatar: String,
    name: String,
    status: String,
  },
  methods: {
    goBack() {
      this.$router.push('/');
    },
  },
};
</script>

<style scoped>
    .main-set {
        display: flex;
        align-items: center;
        justify-content: space-between;
        min-height: 56px;
        background-color: var(--bg-white);
        padding: 0 20px;
        border-bottom: 1px solid transparent;
    }

    @media (min-width: 768px) {
        .main-set {
            min-height: 60px;
        }
    }

    .main-set {
        justify-content: flex-start;
    }

    *, :after, :before {
        box-sizing: border-box;
    }

    :selection {
        background-color: var(--color-secondary);
        color: var(--color-white);
    }

    .ml-ola {
        margin-left: 0 !important;
    }

    .item-jar {
        margin-left: 10px;
    }

    a {
        color: #007bff;
        text-decoration: none;
        background-color: transparent;
    }

    a {
        background-color: transparent;
    }

    .btn-m6f {
        display: inline-block;
        font-weight: 400;
        color: #212529;
        text-align: center;
        vertical-align: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
        background-color: transparent;
        border: 1px solid transparent;
        padding: .375rem .75rem;
        font-size: 1rem;
        line-height: 1.5;
        border-radius: .25rem;
        transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
    }

    .bg-fnm {
        background-color: transparent !important;
    }

    .rounded-ivi {
        border-radius: 50% !important;
    }

    .content-lbp {
        -ms-flex-pack: start !important;
        justify-content: flex-start !important;
    }

    .bg-fnm {
        background-color: transparent;
    }

    .btn-m6f:not(:disabled):not(.disabled) {
        cursor: pointer;
    }

    .main-set .em_-xv5 .btn-m6f {
        width: 35px;
        height: 35px;
        display: inline-flex;
        align-items: center;
        justify-content: flex-end;
        padding: 0;
    }

    a:hover {
        color: #0056b3;
        text-decoration: underline;
    }

    .btn-m6f:hover {
        color: #212529;
        text-decoration: none;
    }

    .media-hoy {
        display: -ms-flexbox;
        display: flex;
        -ms-flex-align: start;
        align-items: flex-start;
    }

    i {
        display: inline-block;
    }

    [class^="tio-"] {
        font-family: "The-Icon-of" !important;
        speak: none;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
        line-height: 1;
        letter-spacing: 0;
        -webkit-font-feature-settings: "liga";
        -moz-font-feature-settings: "liga";
        -ms-font-feature-settings: "liga" 1;
        font-feature-settings: "liga";
        -webkit-font-variant-ligatures: discretionary-ligatures;
        font-variant-ligatures: discretionary-ligatures;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    .main-set .em_-xv5 .btn-m6f i {
        font-size: 22px;
        color: var(--color-text);
        -webkit-transition: 0.3s;
        -moz-transition: 0.3s;
        -o-transition: 0.3s;
        -ms-transition: 0.3s;
        transition: 0.3s;
    }

    .tio-2w2:before {
        content: "\e9b2";
    }

    img {
        vertical-align: middle;
        border-style: none;
    }

    img {
        user-select: none;
        -webkit-user-select: none;
        -moz-user-select: none;
        -o-user-select: none;
        -ms-user-select: none;
    }

    img {
        border-style: none;
    }

    .item-jar .img-nno {
        width: 35px;
        height: 35px;
        border-radius: 50%;
        object-fit: cover;
        margin-right: 15px;
    }

    .media-2ms {
        -ms-flex: 1;
        flex: 1;
    }

    .my-4kl {
        margin-top: auto !important;
    }

    .my-4kl {
        margin-bottom: auto !important;
    }

    h1 {
        margin-top: 0;
        margin-bottom: .5rem;
    }

    h1 {
        margin-bottom: .5rem;
        font-weight: 500;
        line-height: 1.2;
    }

    h1 {
        font-size: 2.5rem;
    }

    h1 {
        font-size: 2em;
        margin: 0.67em 0;
    }

    .item-jar .ymxiv h1 {
        margin-top: 0;
        font-size: 14px;
        font-weight: 500;
        color: var(--color-secondary);
        margin-bottom: 2px;
    }

    p {
        margin-top: 0;
        margin-bottom: 1rem;
    }

    .col-6xt {
        color: var(--color-green);
    }

    .item-jar .ymxiv p {
        margin: 0;
        font-size: 12px;
    } 



</style>
