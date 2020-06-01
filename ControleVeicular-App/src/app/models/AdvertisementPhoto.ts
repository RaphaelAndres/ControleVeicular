import { Advertisement } from './Advertisement';

export interface AdvertisementPhoto {
    Id: string;
    AdvertisementId: string;
    Advertisement: Advertisement;
    PhotoURL: string;
}
