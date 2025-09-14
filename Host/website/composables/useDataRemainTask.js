import { ref } from "vue";

const createCache = (data, ttlM) => ({
    data,
    expireAt: Date.now() + (ttlM * 60000),
    seen: new Set()
});

export function useDataRemainTask(fetchFn, ttlM = 30) {
    const cache = ref(null);

    const loadData = async () => {
        const newData = await fetchFn();
        cache.value = createCache(newData, ttlM);
    };

    const getData = () => {
        if (!cache.value) return [];

        // اگر تایم انقضا گذشته
        if (Date.now() > cache.value.expireAt) {
            loadData();
            return [];
        }

        return cache.value.data;
    };

    const markAsSeen = (id) => {
        if (!cache.value) return;

        const newSeen = new Set(cache.value.seen);
        newSeen.add(id);

        if (newSeen.size === cache.value.data.length) {
            // همه آیتم‌ها دیده شدن → از سرور دوباره میاره
            loadData();
        } else {
            cache.value = { ...cache.value, seen: newSeen };
        }
    };

    return {
        data: getData,
        markAsSeen,
        reload: loadData
    };
}
