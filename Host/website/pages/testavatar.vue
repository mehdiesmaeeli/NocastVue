<template>
    <div>
        <h2>انتخاب آواتار</h2>
        <div class="grid grid-cols-3 gap-4">
            <AvatarOption v-for="(opt, i) in avatarOptions"
                          :key="i"
                          :seed="userSeed"
                          :options="opt"
                          :selected="selectedIndex === i"
                          @select="selectAvatar(opt, i)" />
        </div>

        <button @click="submit">ثبت نام</button>
    </div>
</template>

<script setup>
    import { ref } from 'vue'
    import AvatarOption from '@/components/AvatarOption.vue'
    import axios from 'axios'

    // یه seed دترمینستیک (مثلا username یا email) برای تکرارپذیری
    const userSeed = '1231231'

    // آرایه‌ای از تنظیمات مختلف
    const avatarOptions = [
        { mouth: ['smile'], hair: ['dannyPhantom'], clothingColor: ['#FFCC00'] },
        { mouth: ['frown'], hair: ['mrClean'], clothingColor: ['#00CCFF'] },
        { mouth: ['laughing'], hair: ['dougFunny'], clothingColor: ['#FF99CC'] },
        { mouth: ['smile'], hair: ['fonze'], clothingColor: ['#99FF99'] },
        { mouth: ['sad'], hair: ['full'], clothingColor: ['#6666FF'] },
        { mouth: ['smirk'], hair: ['pixie'], clothingColor: ['#FF9966'] }
    ]

    const selectedIndex = ref(null)
    const selectedOptions = ref(null)

    function selectAvatar(opt, i) {
        selectedIndex.value = i
        selectedOptions.value = opt
    }

    async function submit() {
        if (!selectedOptions.value) {
            alert('لطفا یک آواتار انتخاب کنید')
            return
        }

        // ارسال تنظیمات انتخاب‌شده به بک‌اند
        await axios.post('/api/register', {
            username: 'newUser',
            email: 'test@test.com',
            avatarSeed: userSeed,
            avatarOptions: selectedOptions.value
        })

        alert('ثبت نام موفق بود!')
    }
</script>
