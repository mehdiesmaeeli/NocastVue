import { useRouter } from 'vue-router';
export const useApi = () => {
    const router = useRouter();
    const config = useRuntimeConfig();
    const baseUrl = config.public.apiBase;

    async function call(path: string, options: any ) {
        try {
            const token = localStorage.getItem('access_token');
            // ترکیب baseUrl و path
            const url = `${baseUrl}${path.startsWith('/') ? path : '/' + path}`;

            const res = await $fetch(url, {
                ...options,
                headers: {
                    ...(options as any).headers,
                    Authorization: `Bearer ${token}`
                }
            });
            return { resp: res, error: null };
        } catch (err: any) {
            console.error('API Error:', err);

            // هندل ارور و ریدایرکت
            if (err?.response?.status === 401) {
                router.push('/login');
            } else {
                router.push('/error');
            }

            return { resp: null, error: err };
        }
    }

    return { call };
};
