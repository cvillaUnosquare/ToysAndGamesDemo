export interface Product {
    id: number | 0,
    name: string,
    description: string,
    ageRestriction: number,
    company: string,
    price: number
}

export interface ServiceResponseProduct{
    hasError: boolean,
    error: string,
    excepcionMessage: string,
    entity: Product
}