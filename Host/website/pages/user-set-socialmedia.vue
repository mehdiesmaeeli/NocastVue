<template>
    <NuxtLayout name="auth">
        <section class="account-section padding-20">
            <div class="display-title">
                <h1>اکانت اینستاگرام خود را وارد کنید</h1>
                <p>برای ادامه، اطلاعات خود را وارد کنید</p>
            </div>
            <!--<div class="display_user_account">
                <picture>
                    <source srcset='/images/avatar/11.webp' type='image/webp'>
                    <img class="img_user" src='/images/avatar/11.jpg' alt=''>
                </picture>
                <div class="display-text">
                    <h2>حساب شخصی</h2>
                    <p>johndoe_942@gmail.com</p>
                </div>
            </div>-->
            <div class="content__form margin-t-24">
                <form>
                    <div class="form-group with_icon">
                        <label>اینستاگرام</label>
                        <div class="input_group">
                            <input type="text" v-model="account" class="form-control" :class="[error ? 'is-invalid' : '']" placeholder="@instagram username">
                            <div class="icon"><i class="ri-instagram-fill"></i></div>
                        </div>
                        <div class="size-11 color-red form-text">{{error_str}}</div>
                    </div>
                </form>
            </div>
        </section>
        <template #footer>
            <div class="display-actions">

                <a @click="setSocialAccount" class="btn btn-sm-arrow bg-primary">
                    <p>ارسال</p>
                    <div class="ico">
                        <i class="ri-arrow-drop-left-line"></i>
                    </div>
                </a>
            </div>
        </template>
    </NuxtLayout>
</template>

<script setup>
    definePageMeta({
        layout: false,
    });
    import { ref, onMounted } from 'vue';
    import { useApi } from '~/composables/useApi';
    import { useRoute, useRouter } from "vue-router";
    const error_str = ref('');
    const { call } = useApi();
    const route = useRoute();
    const error = route.query.error;
    const account = ref('')
    // مقداردهی اولیه
    onMounted(async () => {
        if (error == "has-not")
            error_str.value = "متاسفانه شما اکانت فعال یا اکانتی برای ثبت درخواست ندارید"
    });

    const setSocialAccount = async () => {
        const { resp, error } = await call('/socialAccount', {
            method: 'POST',
            body: {
                profileName: account.value, platform : 0
            }
        });
    };
</script>


<style scoped>

</style>
