<template>
    <div class="item-1yh">
        <div class="media-cd6">
            <div class="media-lnc">
                <div class="content-bvw">
                    <p class="item-rae"> Hi, I need help !! </p>
                    <p class="item-rae"> Are u there? </p>
                    <div class="tim-kgp">09:32 AM</div>
                </div>
            </div>
        </div>
    </div>
    <div class="item-sod __m-p1s">
        <div class="media-97t">
            <div class="media-axg">
                <div class="content-c7s">
                    <p class="item-47r"> Hello, how can I help you ? </p>
                    <div class="tim-1ks">
                        <span>09:32 AM</span>
                        <div class="ml-9tw">
                            <i class="ri-check-double-li9 col-kdy size-y6o"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  props: {
    messages: Array,
  },
};
</script>

<style scoped>
    .btn:not(:disabled):not(.disabled) {
        cursor: pointer;
    }

    a:hover {
        color: #0056b3;
        text-decoration: underline;
    }

    .btn:hover {
        color: #212529;
        text-decoration: none;
    }
    .media-cd6 {
        display: -ms-flexbox;
        display: flex;
        -ms-flex-align: start;
        align-items: flex-start;
    }

    .item-1yh {
        padding: 15px 20px;
    }

    .media-lnc {
        -ms-flex: 1;
        flex: 1;
    }

    .tio-chevron_left:before {
        content: "\e9b2";
    }

    p {
        margin-top: 0;
        margin-bottom: 1rem;
    }

    .content-bvw .item-rae {
        font-size: 14px;
        color: var(--color-secondary);
        border-radius: 10px;
        padding: 10px 15px;
        background-color: var(--bg-snow);
        width: max-content;
        margin: 0;
        margin-bottom: 6px;
    }

    .content-bvw .tim-kgp {
        font-size: 12px;
        color: var(--color-text);
        display: flex;
        align-items: center;
    }


    .btn:not(:disabled):not(.disabled) {
        cursor: pointer;
    }

    a:hover {
        color: #0056b3;
        text-decoration: underline;
    }

    .btn:hover {
        color: #212529;
        text-decoration: none;
    }

    i {
        display: inline-block;
    }

    i {
        font-size: 22px;
        color: var(--color-text);
        -webkit-transition: 0.3s;
        -moz-transition: 0.3s;
        -o-transition: 0.3s;
        -ms-transition: 0.3s;
        transition: 0.3s;
    }

    .tio-chevron_left:before {
        content: "\e9b2";
    }

    .media-axg {
        -ms-flex: 1;
        flex: 1;
    }

    .media-97t {
        display: -ms-flexbox;
        display: flex;
        -ms-flex-align: start;
        align-items: flex-start;
    }

    .item-sod {
        padding: 15px 20px;
    }

        .item-sod.__m-p1s {
            display: flex;
            justify-content: flex-end;
        }

    p {
        margin-top: 0;
        margin-bottom: 1rem;
    }

    .content-c7s .item-47r {
        font-size: 14px;
        color: var(--color-secondary);
        border-radius: 10px;
        padding: 10px 15px;
        background-color: var(--bg-snow);
        width: max-content;
        margin: 0;
        margin-bottom: 6px;
    }

    .content-c7s .item-47r {
        color: var(--color-white);
        background-color: var(--bg-primary);
    }

    .content-c7s .tim-1ks {
        font-size: 12px;
        color: var(--color-text);
        display: flex;
        align-items: center;
    }

    .content-c7s .tim-1ks {
        font-size: 12px;
        color: var(--color-text);
    }

    .ml-9tw {
        margin-left: .25rem !important;
    }

    [class^="ri-"] {
        font-family: "remixicon" !important;
        font-style: normal;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    .size-y6o {
        font-size: 18px !important;
    }

    .col-kdy {
        color: var(--color-primary);
    }

    .ri-check-double-li9:before {
        content: "\eb79";
    } 
</style>
