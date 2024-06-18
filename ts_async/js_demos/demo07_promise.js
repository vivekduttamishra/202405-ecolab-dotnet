
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


function findPrimes(min, max) {

    var promise = new Promise((resolve, reject) => {

        //promise code starts
        var lo = min;
        var hi = Math.min(max, lo + 1000);
        var primes = [];
        
        var iid=setInterval(() => {
            //interval code starts
            if (max <= min){
                clearInterval(iid);
                return reject(new Error(`Invalid Range: ${min}-${max}`));
            }


            for (var i = lo; i <= hi; i++) {
                if (isPrime(i)) {
                    primes.push(i);
                }
            }

            lo = hi;
            hi = Math.min(max, lo + 1000);

            if (lo >= max) {
                clearInterval(iid);
                return resolve({ primes, min, max });
            }

        }, 1);


    });

    return promise;

}


function printPrimeCount(min,max){

    findPrimes(min,max)
        .then(result=> console.log(`[${min}-${max}]  has ${result.primes.length} primes`))
        .catch(err=> console.log(`Error: ${err.message}`));

}


function main(){
    printPrimeCount(0,200000);
    printPrimeCount(100,1);
    printPrimeCount(0,200);
    printPrimeCount(0,100000);
}

main();