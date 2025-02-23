<script setup lang="ts">
import { defineProps, defineEmits } from 'vue'

const props = defineProps<{
  currentPage: number
  totalPages: number
}>()

const emit = defineEmits<{
  (e: 'page-changed', page: number): void
}>()

function changePage(page: number) {
  emit('page-changed', page)
}
</script>

<template>
  <div class="flex justify-center items-center mt-4 space-x-2">
    <button
      :disabled="currentPage === 1"
      @click="changePage(currentPage - 1)"
      class="px-3 py-1 bg-gray-200 rounded disabled:opacity-50"
    >
      Prev
    </button>
    <span>Page {{ currentPage }} of {{ totalPages }}</span>
    <button
      :disabled="currentPage === totalPages"
      @click="changePage(currentPage + 1)"
      class="px-3 py-1 bg-gray-200 rounded disabled:opacity-50"
    >
      Next
    </button>
  </div>
</template>
