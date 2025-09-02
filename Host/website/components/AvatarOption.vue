<template>
    <div class="cursor-pointer border rounded p-2"
         :class="{ 'ring-2 ring-blue-500': selected }"
         @click="$emit('select', options)">
        <div v-html="svg" />
    </div>
</template>

<script setup>
import { ref, watchEffect } from 'vue'
import { createAvatar } from '@dicebear/core'
import { micah } from '@dicebear/collection'

const props = defineProps({
  seed: { type: String, required: true },
  options: { type: Object, required: true },
  size: { type: Number, default: 96 },
  selected: { type: Boolean, default: false }
})

const svg = ref('')
watchEffect(() => {
  svg.value = createAvatar(micah, {
    seed: props.seed,
    size: props.size,
    ...props.options
  }).toString()
})
</script>
