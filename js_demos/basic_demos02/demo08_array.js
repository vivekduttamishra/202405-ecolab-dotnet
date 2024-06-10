var x=[1,2,3,4,5];

console.log('x',x);

x[10]=50; //[1,2,3,4,5,undefined,undefined,undefined,undefined,undefined,50]

console.log('x',x);

for(var i=0; i<x.length; i++)
    console.log(`x[${i}]`,x[i]);
    