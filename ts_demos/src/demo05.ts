

namespace demo05{

    interface Person{
        name:string,
        age:number,
        phone?:string, //optional        
    };


    var p:Person={
        name:'Vivek',
        age:30
    };

    console.log(p.name);

    console.log(p.age);

    p.phone='222'

    console.log(p.phone);


}