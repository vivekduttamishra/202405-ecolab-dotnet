
var count=10;
setInterval(()=>{
    console.log(`${new Date().toLocaleTimeString()}: ${count}`)
    count-=1;
}, 1000);

console.log(`${new Date().toLocaleTimeString()}:Starting Count down`);


