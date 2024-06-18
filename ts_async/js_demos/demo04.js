
function isPrime(n){
    if(n<2)
        return false;

    for(var i = 2; i < n; i++){
        if(n % i === 0){
            return false;
        }
    }
    return true;
}

// A syncrhnous findPrimes

//fn is a function that will be called when task completes.
function findPrimes(min,max, fn){
    console.log(`finding primes between ${min} and ${max}`)
    var lo=min;
    var hi=Math.min(lo+1000,max);
    let primes=[];

    //loop this code until every 1ms until lo>max
    let iid= setInterval(()=>{

        if(lo>=max){
            //task is over
            //no more running
            clearInterval(iid);
            //let client know
            fn(primes,min,max);
            
        }
    
        for(let i=lo; i<hi; i++){
            if(isPrime(i)){
                primes.push(i);
            }
        }
        
        lo=hi;
        hi=Math.min(lo+1000,max);
    },1);
    // end of code
    
}

findPrimes(2,200000, (primes,min,max)=> console.log(min,max,primes.length)  );
findPrimes(2,200,    (primes,min,max)=> console.log(min,max,primes.length)  );
findPrimes(2,100000,    (primes,min,max)=> console.log(min,max,primes.length)  );