<template>
    <NuxtLayout name="auth">
        <section class="account-section padding-20">
            <div class="display-title">
                <span class="name_step">مرحله 2 از 2</span>
                <h1>حساب خود را فعال کنید!</h1>
                <p>لطفاً کد موقتی که به موبایل شما ارسال شده است را وارد کنید <span class="text-dark weight-500">{{phone}}</span></p>
            </div>
            <div class="content__form margin-t-40">
                <form class="form-verification-code avtivate-ltr">
                    <div class="form-group">
                        <div class="input_group">
                            <input v-model="otp[0]" type="tel" maxlength="1" pattern="[0-9]" class="form-control" placeholder="-">
                            <input v-model="otp[1]" type="tel" maxlength="1" pattern="[0-9]" class="form-control" placeholder="-">
                            <input v-model="otp[2]" type="tel" maxlength="1" pattern="[0-9]" class="form-control" placeholder="-">
                            <input v-model="otp[3]" type="tel" maxlength="1" pattern="[0-9]" class="form-control" placeholder="-">
                        </div>
                    </div>
                    <div class="countdown_code">

                        <div v-if="timeLeft > 0">
                            زمان باقی مانده {{ timeLeft }} ثانیه
                        </div>
                        <div v-else>
                            <button type="button" class="btn btn-resend" @click="resetTimer">
                                ارسال مجدد کد
                            </button>
                        </div>

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

import { ref,onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import { useApi } from '@/composables/useApi';


const { call } = useApi();

const route = useRoute();
const router = useRouter();
const otp = ref(["", "", "", ""]);
const timeLeft = ref(60)



// گرفتن شماره از مسیر
const phone = route.query.phone;
const token = route.query.token;


let timer = null

const startTimer = () => {
  timer = setInterval(() => {
    if (timeLeft.value > 0) {
      timeLeft.value--
    } else {
      clearInterval(timer)
    }
  }, 1000)
}


const resetTimer = () => {
  timeLeft.value = 60
  startTimer()
}

onMounted(() => {
  startTimer()
})
const login = async () => {
const { resp, error } = await call('/auth/verify-otp', {
    method: 'POST',
    body: {
        phone: phone,
        otp: otp.value.join(''),
        token: token
    }
});

router.push({ path: `/index`});

}
</script>
<style>
    .avtivate-ltr{direction:ltr}
</style>