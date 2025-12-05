export interface WorkshopResponse {
    id: string;
    title?: string;
    description?: string;
    startAt: string;   // DateTimeOffset → string
    endAt: string;
    location?: string;
    capacity: number;
    isOnline: boolean;
}
