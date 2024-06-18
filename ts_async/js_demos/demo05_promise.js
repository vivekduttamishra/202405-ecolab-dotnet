
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


function findPrimes(min,max){

    var promise = new Promise((resolve,reject)=>{

        if(max<=min)
            return reject(new Error(`Invalid Range: ${min}-${max}`));

        var primes = [];
        for(var i = min; i <= max; i++){
            if(isPrime(i)){
                primes.push(i);
            }
        }
        resolve({primes,min,max});

    });

    return promise;

}


function print_primes(result){
    console.log(`There are ${result.primes.length} in range ${result.min}-${result.max}`);
}

function print_error(error){
    console.error("Error:",error.message);
}


var p1= findPrimes(2,200000);
p1
    .then(result=>console.log(`Found ${result.primes.length} in range ${result.min}-${result.max}`))
    .catch(error=>console.log("Error:",error));


var p2= findPrimes(2,200);
p2
    .then(print_primes)
    .catch(print_error);

findPrimes(100,1)
    .then(print_primes) //this will not execute
    .catch(print_error); //this will be executed

findPrimes(2,100000)
    .then(print_primes)
    .catch(print_error);
