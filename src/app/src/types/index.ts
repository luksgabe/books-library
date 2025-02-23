export interface Image {
    thumbnail: string;
    smallThumbnail: string;
}

export interface Book {
    title: string;
    author: string;
    description: string | null;
    category: string;
    link: string;
    image: Image;
}

export interface ApiResponse {
    items: Book[];
    totalItems: number;
    totalPages: number;
    currentPage: number;
    pageSize: number;
}