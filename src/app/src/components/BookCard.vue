<script setup lang="ts">
import type { Book } from '@/types'
import { defineProps } from 'vue'

const props = defineProps<{
  book: Book
}>()
</script>

<template>
  <div class="border rounded shadow p-4 flex flex-col">
    <img :src="book.image.thumbnail" alt="Book cover" class="mb-4 w-40 object-cover self-center" />
    <h2 class="text-xl font-semibold mb-2">{{ book.title }}</h2>
    <p class="text-sm text-gray-600 mb-2">by {{ book.author }}</p>
    <p class="text-gray-700 mb-4" v-if="book.description">
      {{ book.description }}
    </p>
    <p class="text-gray-700 mb-4" v-else>No description available.</p>
    <a :href="book.link" target="_blank" class="mt-auto text-blue-500 hover:underline">
      Read more
    </a>
  </div>
</template>
