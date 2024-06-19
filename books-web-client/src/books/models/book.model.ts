
type IdType={
    $oid:string;
}

export interface Book{
    
    id: string;
    title:string;
    author:string;
    price:number;
    rating:number;
    coverPhoto:string;
    description:string;   
    
    
    //optional properties
    tags?:string|string[];
    votes?:number;
    _id?: IdType;
    isbn?:string;
    reviews?:any[];
    series?:string;
    seriesIndex?: number|string;
    pages?:number|string;
}