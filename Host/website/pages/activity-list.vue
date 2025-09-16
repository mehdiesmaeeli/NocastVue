<template>
    <div id="wrapper">
        <div  v-if="currentDetail" id="content">
            <header class="default heade-sticky">
                <div class="un-title-page go-back">
                    <a @click="$router.back()" class="icon"><i class="ri-arrow-drop-right-line"></i></a>
                </div>
                <div class="un-block-right">
                    <div class="btn-like-click shape-box">
                        <div class="btnLike">
                            <input type="checkbox">
                            <span class="count-likes">{{currentDetail.task.todayCnt}}/{{currentDetail.task.giftCnt}}</span>
                            <div class="icon-inside">
                                <i class="ri-gift-line"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </header>
            <div class="space-sticky"></div>
            <section class="un-details-collectibles">

                <div class="head">
                    <div class="title-card-text d-flex align-items-center justify-content-between">
                        <div class="text">
                            <h1>{{currentDetail.task.detail.title}}</h1>
                        </div>
                        <span class="btn-xs-size bg-pink text-white rounded-pill">ورزشی</span>
                    </div>
                    <div class="txt-price-coundown d-flex justify-content-between">
                        <div class="price">
                            <h2>درآمد</h2>
                            <p>{{currentDetail.task.detail.price}}<span class="size-16">NoC</span></p>
                        </div>
                    </div>
                </div>
                <div class="body">
                    <div class="description">
                        <p>بر روی تنفس خود تمرکز کنید زیرا این آرامش به طور بی‌پایان باز و بسته می‌شود.</p>
                    </div>

                    <div class="tab-content content-custome-data" id="pills-tabContent">
                        <div class="tab-pane fade show active" id="pills-Info" role="tabpanel" aria-labelledby="pills-Info-tab">
                            <ul class="nav flex-column nav-users-profile margin-t-20">
                                <li class="nav-item">
                                    <div class="nav-link">
                                        <a href="page-creator-profile.html" class="item-user-img visited">
                                            <div class="wrapper-image">
                                                <picture>
                                                    <img class="avt-img" :src=currentDetail.task.avatar alt="">
                                                </picture>
                                                <div class="icon"><i class="ri-checkbox-circle-fill"></i></div>
                                            </div>
                                            <div class="txt-user">
                                                <h5>سازنده</h5>
                                                <p>{{currentDetail.task.detail.userName}}</p>
                                            </div>
                                        </a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="space-sticky-footer"></div>
                <div class="footer">
                    <div class="content">
                        <div class="links-item-pages">
                            <a @click="previousItem" class="icon-box prev"><i class="ri-arrow-right-line"></i></a>
                            <a @click="nextItem" class="icon-box next"><i class="ri-arrow-left-line"></i></a>
                        </div>
                        <a  v-if="!currentDetail.do" @click="markAsDo(currentDetail.id)" class="btn btn-bid-items">
                            <p>اقدام میکنم</p>
                            <div class="ico"><i class="ri-arrow-drop-left-line"></i></div>
                        </a>
                        <a v-else @click="cancelItem(currentDetail.id)" class="btn btn-bid-items bg-red" >
                            <p>منصرف شدم</p>
                            <div class="ico"><i class="ri-arrow-drop-left-line"></i></div>
                        </a>
                    </div>
                </div>
            </section>
        </div>
    </div>
    
</template>

<script setup>
    definePageMeta({
        layout: false,
    });
    import { ref, onMounted } from 'vue'
    import { useDataRemainTask } from "@/composables/useDataRemainTask";
    const task = ref({
        todayCnt : 0,
        giftCnt: 0,
        title: '',
        price: 0,
        url:''
    });
    const dataUri = ref('')
    

    const { data, currentDetail, currentIndex, nextItem, previousItem, markAsDo, cancelItem, reload } = useDataRemainTask(60);

    onMounted(async () => {
        await reload();
        

        //const { resp, error } = await call('/task', {
        //    method: 'GET'
        //})
        //if (!error && resp?.data) {
        //    task.value = resp?.data
        //}
    })
</script>