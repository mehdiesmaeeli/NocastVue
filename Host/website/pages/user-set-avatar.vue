<template>
    <NuxtLayout name="auth">
        <section class="un-page-components">

            <div class="content-comp p-0">
                <div class="space-items"></div>
                <div class="bg-white padding-y-16">
                    <div class="display-stories">
                        <div class="swiper myStories">
                            <div class="swiper-wrapper wrapper-stories" id="stories">
                                <div class="avatar-grid">
                                    <div v-for="(avatar, index) in avatars"
                                         :key="index"
                                         class="avatar-item"
                                         :class="{ selected: selectedAvatar === avatar.seed }"
                                         @click="selectAvatar(avatar.seed)" v-html="avatar.svg">

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <a @click="shuffleAvatars" class="btn effect-click w-100 btn-md-size border border-solid border-snow color-text rounded-pill">
                <p>تصاویر جدید</p>
            </a>
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
    import { micah } from '@dicebear/collection';
    import { createAvatar } from '@dicebear/core';

    const avatars = ref([]);
    const selectedAvatar = ref(null);
    const { call } = useApi();

    // تولید ۹ آواتار رندوم با DiceBear (نسخه async)
    const getRandomAvatars = async () => {
        const list = [];
        for (let i = 0; i < 9; i++) {
            const seed = Math.random().toString(36).substring(2, 8); // seed رندوم
            const svg = createAvatar(micah, { seed }).toString();
            list.push({ svg, seed });
        }
        return list;
    };

    // مقداردهی اولیه
    onMounted(async () => {
        avatars.value = await getRandomAvatars();
    });

    const selectAvatar = (avatar) => {
        selectedAvatar.value = avatar;
    };

    const shuffleAvatars = async () => {
        avatars.value = await getRandomAvatars();
        selectedAvatar.value = null;
    };

    const updateAvatar = async () => {
        if (!selectedAvatar.value) return;

        const { resp, error } = await call('/user/set-avatar', {
            method: 'POST',
            body: { avatar: selectedAvatar.value },
        });
        var toastElList = [].slice.call(document.querySelectorAll('#liveToastTwo'))
        var toastList = toastElList.map(function (toastEl) {
            return new bootstrap.Toast(toastEl)
        });

        if (error) {
            toastList.forEach(toast => toast.show());
            return;
        }

        toastList.forEach(toast => toast.show());
    };
</script>


<style scoped>
    .avatar-grid {
        display: grid;
        grid-template-columns: repeat(3, auto); /* سه ستون */
        grid-gap: 10px;
        margin-bottom: 20px;
        gap: 20px;
        justify-content: center; /* وسط‌چین افقی */
        align-content: center; /* وسط‌چین عمودی */
    }

    .avatar-item {
        width: 100px;
        height: 100px;
        border: 2px solid transparent;
        cursor: pointer;
        border-radius: 10px;
        overflow: hidden;
    }

        .avatar-item.selected {
            border-color: #4caf50;
        }

        .avatar-item img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }

    button {
        margin-right: 10px;
        padding: 5px 15px;
    }
</style>
