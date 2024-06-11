

namespace demo05{

    type Persson={
        name:string,
        age:number,
        phone?:string, //optional        
    };


    var p:any={
        name:'Vivek',
        age:30
    };

    console.log(p.name);

    console.log(p.age);

    p.phone = "123"

    console.log(p.phone);


}