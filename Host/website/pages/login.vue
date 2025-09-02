<template>
    <NuxtLayout name="auth">
        <section class="account-section padding-20">
            <div class="display-title">
                <h1>خوش آمدید!</h1>
                <p>برای ادامه شماره تلفن همراه را وارد کنید</p>
            </div>
            <div class="content__form margin-t-24">
                <form>
                    <div class="form-group icon-left">
                        <label> موبایل</label>
                        <div class="input_group">
                            <input v-model="phone" type="phone" class="form-control" placeholder='مثال: "09121234567"'
                                   required>
                            <div class="icon">
                                <i class="ri-mail-open-line"></i>
                            </div>
                        </div>
                    </div>
                    <div class="form-group icon-left">
                        <label>رمز عبور</label>
                        <div class="input_group">
                            <input v-model="password" type="password" class="form-control" placeholder='مثال: "John$99*04"' required>
                            <div class="icon">
                                <i class="ri-lock-password-line"></i>
                            </div>
                        </div>
                        <a href="page-reset-password.html" class="text-primary size-13 margin-t-14 d-block text-decoration-none weight-500">فراموشی رمز عبور؟</a>
                    </div>

                </form>
            </div>
        </section>

        <template #footer>
            <div class="display-actions">
                <a @click="login" class="btn btn-sm-arrow bg-primary">
                    <p>ورود</p>
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
    import { ref } from 'vue'

    const phone = ref('')
    const password = ref('')
    const error = ref('')

    const login = async () => {
        try {
            const { data, error } = await useFetch('http://localhost:5004/api/auth/login', {
                method: 'POST',
                body: {
                    phone: phone.value,
                    password: password.value
                }
            });
            if (error.value) throw error.value;

            localStorage.setItem('access_token', data.value.data);

        } catch (err) {
            error.value = 'Login failed. Please check your credentials.'
        }
    }
</script>