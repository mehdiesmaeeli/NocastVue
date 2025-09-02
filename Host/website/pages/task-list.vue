<template>
    <NuxtLayout name="simple">
        <template #header>
            <h1>آیتم های من</h1>
        </template>
        <section class="un-myItem-list">
            <nav class="nav flex-column">
                <div v-for="item in taskList" :key="item.id" class="nav-link" >
                    <div class="cover_img">

                        <div class="txt" @click="$router.push('/task-activity')">

                            <h2>{{ item.name }}</h2>
                            <h3>{{ TASK_TYPES.find(x => x.id === item.type)?.label }}</h3>
                            <p>{{ item.id }}</p>
                        </div>
                    </div>
                    <div class="other-side">
                        <router-link :to="{ name: 'task-edit', params: { id: item.id } }" class="out-link-edit">
                            <i class="ri-pencil-line"></i>
                        </router-link>
                    </div>
                </div>
            </nav>
        </section>
        <div class="d-flex justify-content-center buttonSticky_add">
            <div class="item-add-NFTs-plus">
                <a @click="$router.push('task-create')">
                    <i class="ri-add-fill"></i>
                </a>
            </div>
        </div>
    </NuxtLayout>
</template>

<script setup>
    definePageMeta({
        layout: false,
    });
    import { TASK_TYPES } from "@/constants/list.js";
    import { ref, onMounted } from 'vue'
    import { useApi } from '@/composables/useApi';
    const { call } = useApi();
    const taskList = ref('')
    onMounted(async () => {
        const { resp, error } = await call('/task/list', {
            method: 'GET'
        });
        if (!error && resp?.data) {
            taskList.value = resp.data;
        } else {
            // اینجا نهایتاً می‌تونی پیام خطا برای UI بزنی
            console.log("خطا در گرفتن لیست:", error);
        }

    })
</script>