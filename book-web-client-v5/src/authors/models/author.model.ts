

// export default class Author{

//     constructor(
//         public id : string,
//         public name : string,
//         public biography: string,
//         public photograph: string
//     ){

//     }
// }

export interface Author{
    id: string;
    name:string;
    biography:string;
    photograph:string;
    birthDate: Date|string;    
}

