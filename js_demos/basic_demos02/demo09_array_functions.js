var x=[1,2,3,4,5];

console.log('x',x);

x.push(10)
x.push('Hi')
x.push(new Date())

console.log('x',x);

//to remove all items from index 2-4

var y= x.splice(2,2); //start from 2  and remove 2 items. It will remove and return [3,4]
console.log('after splice');
console.log('x',x);
console.log('y',y);



