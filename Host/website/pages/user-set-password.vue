<template>
    <NuxtLayout name="auth">
        <section class="account-section padding-20">
            <div class="display-title">
                <!--<span class="name_step">مرحله 1 از 2</span>-->
                <h1>رمز عبور خود را وارد کنید</h1>
                <p>برای ورود در آینده میتوانید از پسورد ست شده در اینجا استفاده کنید</p>
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
                    <div class="form-group icon-left">
                        <label>رمز عبور</label>
                        <div class="input_group">
                            <input type="password" class="form-control" placeholder='مثال: "Xyz$99*04"' required>
                            <div class="icon">
                                <i class="ri-lock-password-line"></i>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </section>
        <template #footer>
            <div class="display-actions">

                <a @click="updateAvatar" class="btn btn-sm-arrow bg-primary">
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

    const { call } = useApi();

    // مقداردهی اولیه
    onMounted(async () => {

    });

    const selectAvatar = (avatar) => {
        selectedAvatar.value = avatar;
    };

    const shuffleAvatars = async () => {
        avatars.value = await getRandomAvatars();
        selectedAvatar.value = null;
    };

    const updatePassword = async () => {

    };
</script>


<style scoped>
</style>
