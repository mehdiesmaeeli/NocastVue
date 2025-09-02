<template>
    <NuxtLayout name="simple">
        <template #header>
            <h1>ایجاد تکی</h1>
        </template>
        <section class="un-create-collectibles">
            <div class="form-group">
                <label>نوع</label>
                <select class="form-select form-control custom-select" aria-label="Default select example" v-model="selectedTaskType">
                    <option v-for="tt in TASK_TYPES" :key="tt.id" :value="tt.id">
                        {{ tt.label }}
                    </option>
                </select>
            </div>
            <div class="form-group">
                <label>نام آیتم</label>
                <input type="text" class="form-control" placeholder='مثال: "ریل بازار"'>
            </div>
            <div class="form-group">
                <label>لینک</label>
                <input type="text" class="form-control" placeholder='مثال: "sdWXfr34" , "https://instagram.com/p/"'>
            </div>
            <div class="form-group form-with-select">
                <label>قیمت</label>
                <div class="input_group">
                    <input type="text" class="form-control" placeholder='مثال: 1 یا 0.1'>
                </div>
            </div>
            <div class="form-group form-with-select">
                <label>تعداد</label>
                <div class="input_group">
                    <input type="text" class="form-control" placeholder='مثال:1000'>
                </div>
            </div>
        </section>
        <section class="un-activity-toggle">
            <nav class="nav flex-column">
                <div class="nav-link border-0 px-0 mb-0 pt-1">
                    <div class="text">
                        <h2>قرار دادن به عنوان آیتم اصل </h2>
                        <p>شما برای این آیتم همیشه از موجودی کیف پول استفاده میکنید و موجودیتون بلاک میشه</p>
                    </div>
                    <label class="switch_toggle toggle_lg" for="swithDefault">
                        <input type="checkbox" checked="checked" id="swithDefault">
                        <span class="handle"></span>
                    </label>
                </div>
               
            </nav>
        </section>
        <template #footer>
            <div class="update-auto">
                <div class="auto-saving">

                </div>
            </div>
            <a href="page-put-on-marketplace.html" class="btn btn-bid-items">
                <p>ایجاد آیتم</p>
                <div class="ico"><i class="ri-arrow-drop-left-line"></i></div>
            </a>
        </template>
    </NuxtLayout>
</template>

<script setup>
    import { TASK_TYPES } from "@/constants/list.js";
    definePageMeta({
        layout:false,
    });
    const selectedTaskType = 0;
</script>