import { Brand } from './Brand';

export interface Vehicle {
    id: string;
    modelName: string;
    modelSpecification: string;
    engineDisplacement?: number;
    bodytype: string;
    engineSpecification: string;
    brandId: string;
}
