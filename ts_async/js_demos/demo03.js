
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
    setTimeout(()=>{
        var primes = [];
        for(var i=min; i<max; i++){
            if(isPrime(i))
                primes.push(i);
        }
    
        //call the user function to pass result back to user
        //This function can do whatever it wants to do with the result
        //it can take as many information as it wants
        console.log(`found primes between ${min} and ${max}`);
        fn(primes,min,max); 
        
    },1) ; //run after 1 ms
    
}

findPrimes(2,200000, (primes,min,max)=> console.log(min,max,primes.length)  );

findPrimes(2,200,    (primes,min,max)=> console.log(min,max,primes.length)  );