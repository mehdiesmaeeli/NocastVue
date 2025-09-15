import { ref } from "vue";
import { useApi } from './useApi';

import { createAvatar } from '@dicebear/core'
import { micah } from '@dicebear/collection'


const createCache = (data, ttlM) => ({
    data,
    expireAt: Date.now() + (ttlM * 60000)
});
const listUrl = '/task/remain';
const detailUrl = '/task/';
export function useDataRemainTask(ttlM = 30) {
    const cache = ref(null);
    const currentIndex = ref(-1);   // اندیس آیتم فعلی
    const currentDetail = ref(null); // دیتیل آیتم فعلی
    const { call } = useApi();
    const loadData = async () => {
        const { resp, error } = await call(listUrl, {
            method: 'GET'
        });
        if (resp?.data) {
            cache.value = createCache(resp.data, ttlM);
            // بعد از گرفتن لیست، اولین آیتم رو لود کن
            if (cache.value.data.length > 0) {
                currentIndex.value = 0;
                await loadDetail(cache.value.data[0].id);
            }
        }
    };

    const loadDetail = async (id) => {
        const { resp, error } = await call(detailUrl + id, {
            method: 'GET'
        });
        if (resp?.data) {
            const svg = createAvatar(micah, {
                seed: resp?.data.userAvatar,
                size: 180
            }).toString();

            const svgBase64 = btoa(unescape(encodeURIComponent(svg))); // تبدیل به base64
            resp.data.avatar = `data:image/svg+xml;base64,${svgBase64}`;

            currentDetail.value = resp.data;
            var item = cache.value.data.find(x => x.id == id);
            item.detail = resp.data
        }
    };
    const getData = () => {
        if (!cache.value) return [];
        return cache.value.data;
    };

    const nextItem = async () => {
        if (!cache.value) return;
        currentIndex.value++;
        if (cache.value.data[currentIndex.value].detail) { 
            currentDetail.value = cache.value.data[currentIndex.value].detail;
        }
        else if (currentIndex.value < cache.value.data.length) {
            
            await loadDetail(cache.value.data[currentIndex.value].id);
        }
    }

    const previousItem = async () => {
        if (!cache.value) return;
        if (currentIndex.value > 0) {
            currentIndex.value--;
            currentDetail.value = cache.value.data[currentIndex.value].detail;
        }
    }

    const markAsSeen = (id) => {
        if (!cache.value) return;

        const item = cache.value.data.filter(x => x.id == id);
        item.seen = true;

        if (cache.value.data.all(x=> x.seen)) {
            // همه آیتم‌ها دیده شدن → از سرور دوباره میاره
            loadData();
        } 
    };

    const markAsDo = (id) => {
        if (!cache.value) return;
        const item = cache.value.data.filter(x => x.id == id);
        item.do = true;
    };

    const cancelItem = (id) => {
        if (!cache.value) return;
        const item = cache.value.data.filter(x => x.id == id);
        item.do = false;
    };

    return {
        data: getData,
        currentDetail,       // دیتیل آیتم انتخابی
        currentIndex,        // اندیس آیتم انتخابی
        nextItem,
        previousItem,
        markAsDo,
        cancelItem,
        reload: loadData
    };
}
