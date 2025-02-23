/* eslint-disable @typescript-eslint/no-explicit-any */
// src/api.ts
import type { ApiResponse } from '@/types';
import axios from 'axios';

const BASE_URL = 'https://localhost:7208/api/book'; // Replace with your real API endpoint

// Create an axios instance with a base URL
const apiClient = axios.create({
    baseURL: BASE_URL,
    timeout: 5000,
});

// Function to fetch books using the search parameters
export const fetchBooks = async (
    searchParam: string,
    page: number,
    size: number
): Promise<ApiResponse> => {
    try {
        const response = await apiClient.get('', {
            params: { searchParam, page, size },
        });
        return response.data as ApiResponse;
    } catch (error: any) {
        // You can enhance error handling as needed
        throw new Error(error.response?.data?.message || 'Error fetching books');
    }
};
