<template>
    <NuxtLayout name="simple">
        <template #header>
            <h1>فعالیت</h1>
        </template>
        <section class="margin-t-20 un-activity-page">
            <div class="content-activity">
                <div class="body">
                    <ul class="nav flex-column">
                        <li class="nav-item">
                            <a href="page-creator-profile.html" class="nav-link">
                                <div class="item-user-img">
                                    <div class="wrapper-image">
                                        <picture>
                                            <source srcset="//images/avatar/18.webp" type="image/webp">
                                            <img class="avt-img" src="//images/avatar/18.jpg" alt="">
                                        </picture>
                                    </div>
                                    <div class="txt-user">
                                        <h5>{{task.name}} <span class="color-text">دنبال کرد شما را</span></h5>
                                        <p>الان</p>
                                    </div>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
                <template v-for="([date, items], index) in Object.entries(task.list || {})" :key="index">
                    <div class="head">
                        <div class="title">{{date}}</div>
                    </div>
                    <div class="body">
                        <ul class="nav flex-column">

                            <li  v-for="item in items" :key="item.id" class="nav-item">
                                <a href="javascript: void(0)" class="nav-link">
                                    <div class="item-user-img">
                                        <div class="wrapper-image">
                                            <div class="icon-status bg-green-1 color-green"><i class="ri-file-add-fill"></i></div>
                                        </div>
                                        <div class="txt-user">
                                            <h5>{{item.id}}</h5>
                                            <h5 class="size-13 weight-600">0.03 ETH <span class="color-text">{{item.name}}</span></h5>
                                            <p>{{item.time}}</p>

                                        </div>
                                    </div>
                                    <div class="other-option">
                                        <div  v-if="item.isPay" class="icon"><i class="ri-checkbox-circle-fill"></i></div>
                                        <button v-else  type="button" class="btn btn-sm-size border text-dark rounded-pill">تایید</button>
                                    </div>
                                </a>
                            </li>
                        </ul>
                    </div>
                </template>
            </div>
            <div class="loader-items" style="direction:ltr">
                <div class="lds-spinner">
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                </div>
            </div>
        </section>
    </NuxtLayout>

</template>

<script setup>
    definePageMeta({
        layout: false,
    });
    import { ref, onMounted } from 'vue'
    import { useApi } from '@/composables/useApi';
    const { call } = useApi();
    const task = ref('')
    onMounted(async () => {
        const { resp, error } = await call('/task/activity', {
            method: 'GET'
        });
        if (!error && resp?.data) {
            task.value = resp.data;
        } else {
            // اینجا نهایتاً می‌تونی پیام خطا برای UI بزنی
            console.log("خطا در گرفتن لیست:", error);
        }
    })
</script>