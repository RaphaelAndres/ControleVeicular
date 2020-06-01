import { Vehicle } from './Vehicle';
import { AdvertisementPhoto } from './AdvertisementPhoto';

export interface Advertisement {
    id: string;
    buyPrice: number;
    sellPrice?: number;
    fabricationYear?: number;
    modelYear?: number;
    color: string;
    fuelType: string;
    sellDate?: Date;
    driveTrain: string;
    transmissionType: string;
    vehicleId: string;
    adPhotos: AdvertisementPhoto[];
}
