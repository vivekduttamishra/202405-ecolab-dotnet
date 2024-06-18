

// for(let i=0;i<5;i++){
//     setTimeout(()=>{
//         var d= new Date();
//         console.log(d.toLocaleTimeString());
//     },1000);
// }

let i=0;
let iid=setInterval(()=>{
    var d=new Date();
    console.log(d.toLocaleTimeString());
    i++;
    if(i==5)
        clearInterval(iid);
},1000);