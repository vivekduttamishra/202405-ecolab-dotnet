function sum(...numbers){
    var result=0
    for(var x of numbers)
        result+=x;
    return result;
}

console.log('sum(1,2,3,4)',sum(1,2,3,4));
console.log('sum(1,2,3,4,5)',sum(1,2,3,4,5));
