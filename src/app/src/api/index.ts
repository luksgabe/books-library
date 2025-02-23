/* eslint-disable @typescript-eslint/no-explicit-any */
import type { ApiResponse } from '@/types';
import axios from 'axios';

const BASE_URL = import.meta.env.VITE_API_BASE_URL;;

const apiClient = axios.create({
    baseURL: BASE_URL as string,
    timeout: 5000,
});

export const fetchBooks = async (
    searchParam: string,
    page: number,
    size: number
): Promise<ApiResponse> => {
    try {
        const response = await apiClient.get('/book', {
            params: { searchParam, page, size },
        });
        return response.data as ApiResponse;
    } catch (error: any) {
        throw new Error(error.response?.data?.message || 'Error fetching books');
    }
};
