function plus(x,y){
    return x+y;
}

console.log('typeof(plus)',typeof(plus));

var add=plus;

console.log('typeof(add)',typeof(add));

console.log('add(3,4)',add(3,4));
