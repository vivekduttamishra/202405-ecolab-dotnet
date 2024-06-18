
function isPrime(n) {
    if (n < 2)
        return false;

    for (var i = 2; i < n; i++) {
        if (n % i === 0) {
            return false;
        }
    }
    return true;
}


const delay = async (ms)=>{
    return new Promise( resolve=>{
        setTimeout(resolve, ms);
    });
};




async function  findPrimes(min, max) {

    var primes=[];

    for(var i=min;i<max;i++){
        if(isPrime(i)){
            primes.push(i);
        }
        if(i%1000===0)
            await delay(1);
    }

    return {min,max,primes};
    
}


async function  printPrimeCount(min,max){

    try{        
        var result = await findPrimes(min,max);
        console.log(`[${min}-${max}]  has ${result.primes.length} primes`);
    }catch(err){

        console.log(`Error: ${err.message}`);
    }

    //returns a promise 
}


const  main=async()=>{
    var p1= findPrimes(0,200000);
    
    var p2= findPrimes(0,200);
    
    var r2=await p2;    
    console.log(r2);
    
    var r1=await p1;
    console.log(r1);
}

main();