<script setup lang="ts">
import { ref, onMounted } from 'vue'
import BookCard from './BookCard.vue'
import Pagination from './PaginationList.vue'
import { fetchBooks as apiFetchBooks } from '@/api'
import type { Book } from '@/types'

const searchParam = ref<string>('')
const currentPage = ref<number>(1)
const pageSize = ref<number>(10)
const totalPages = ref<number>(0)
const books = ref<Book[]>([])
const loading = ref<boolean>(false)
const error = ref<string | null>(null)

async function fetchBooks() {
  loading.value = true
  error.value = null
  try {
    const data = await apiFetchBooks(searchParam.value, currentPage.value, pageSize.value)
    books.value = data.items
    totalPages.value = data.totalPages
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
  } catch (err: any) {
    error.value = err.message || 'Unknown error'
  } finally {
    loading.value = false
  }
}

function handlePageChange(page: number) {
  currentPage.value = page
  fetchBooks()
}

onMounted(() => {
  fetchBooks()
})
</script>

<template>
  <div class="max-w-5xl mx-auto px-4 py-8">
    <!-- Search Section -->
    <div class="flex flex-col sm:flex-row items-center mb-8 gap-4">
      <input
        v-model="searchParam"
        @keyup.enter="fetchBooks"
        type="text"
        placeholder="Search for books..."
        class="w-full sm:flex-1 border border-gray-300 rounded-lg p-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
      />
      <button
        @click="fetchBooks"
        class="w-full sm:w-auto bg-blue-600 text-white px-6 py-3 rounded-lg hover:bg-blue-700 transition"
      >
        Search
      </button>
    </div>

    <!-- Loading and Error States -->
    <div v-if="loading" class="text-center text-lg text-gray-600">Loading...</div>
    <div v-if="error" class="text-center text-red-600 font-semibold">
      {{ error }}
    </div>
    <div v-if="!loading && books.length === 0" class="text-center text-gray-500">
      No books found.
    </div>

    <!-- Books Grid -->
    <div v-if="books.length" class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      <BookCard v-for="book in books" :key="book.title" :book="book" />
    </div>

    <!-- Pagination -->
    <Pagination
      v-if="totalPages > 1"
      :currentPage="currentPage"
      :totalPages="totalPages"
      @page-changed="handlePageChange"
    />
  </div>
</template>
