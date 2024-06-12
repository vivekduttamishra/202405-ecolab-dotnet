
var count=10;
var interval_id= setInterval(()=>{
    console.log(`${new Date().toLocaleTimeString()}: ${count}`)
    count-=1;
}, 1000);

 //clear interval after count seconds

setTimeout(()=> clearInterval(interval_id), (count+1)*1000);  

//immediate execution
console.log(`${new Date().toLocaleTimeString()}:Starting Count down`);


