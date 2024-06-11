
let a=20; //a is number because it is initalized.


let b:string="Hello World!"; // b is marked string and intialized

let c:string; //c is unitialized string.

c="Hi";

c=20;









function sum(...numbers){
    let result=0
    for(let number of numbers){
        result+=number;
    }
    return result;
}