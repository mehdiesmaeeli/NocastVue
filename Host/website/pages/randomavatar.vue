<template>
    <div class="grid grid-cols-3 gap-4">
        <div v-for="(avatar, index) in avatars"
             :key="index"
             class="cursor-pointer border p-2 rounded"
             v-html="avatar" />
    </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { createAvatar } from '@dicebear/core'
import { micah } from '@dicebear/collection'

// اینجا آواتارها رو ذخیره می‌کنیم
const avatars = ref([])

onMounted(() => {
  const generated = []
  for (let i = 0; i < 9; i++) {
    // هر بار یه seed رندوم می‌سازیم
    const seed = Math.random().toString(36).substring(2, 10)

    // آواتار تصادفی
    const svg = createAvatar(micah, {
      seed,
      size: 180
    }).toString()

    generated.push(svg)
  }
  avatars.value = generated
})
</script>
