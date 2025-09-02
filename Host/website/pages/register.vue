<template>
    <NuxtLayout name="auth">
        <section class="account-section padding-20">
            <div class="display-title">
                <span class="name_step">مرحله 1 از 2</span>
                <h1>ورود</h1>
                <p>اطلاعات خود را وارد کنید تا ادامه دهید</p>
            </div>

            <div class="content__form margin-t-24">
                <form>
                    <div class="form-group icon-left">
                        <label>موبایل</label>
                        <div class="input_group">
                            <input v-model="phone" type="phone" class="form-control" placeholder='مثال: "09121234567"'
                                   required>
                            <div class="icon">
                                <i class="ri-phone-find-line"></i>
                            </div>
                        </div>
                    </div>

                </form>
            </div>
        </section>
        <template #footer>
            <div class="display-actions">
                <a @click="login" class="btn btn-sm-arrow bg-primary">
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
        layout:false,
    });
    import { ref } from 'vue'
    import { useRouter } from 'vue-router';
    import { useApi } from '@/composables/useApi';

    const { call } = useApi();
    const phone = ref('')
    const error = ref('')
    const router = useRouter();
    const login = async () => {

        const { resp, error } = await call('/auth/send-otp', {
            method: 'POST',
            body: {
                phone: phone.value,
                otp: "",
                token: ""
            }
        });
        router.push({ path: `/activate`, query: { phone: phone.value, token: resp.data.otpToken } });

    }
</script>
