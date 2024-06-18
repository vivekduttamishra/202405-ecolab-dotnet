
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

function findPrimes(min,max){
    var primes = [];
    for(var i=min; i<max; i++){
        if(isPrime(i))
            primes.push(i);
    }
    return primes;
}


function findPrimesAndPrintCount(min,max){

    var p1= findPrimes(min,max);
    console.log(`total primes in range ${min} to ${max} is ${p1.length}`);
}


findPrimesAndPrintCount(2,200000);
findPrimesAndPrintCount(2,200);