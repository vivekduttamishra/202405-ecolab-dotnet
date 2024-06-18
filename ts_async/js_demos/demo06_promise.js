
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


function print_primes(result) {
    console.log(`There are ${result.primes.length} in range ${result.min}-${result.max}`);
}

function print_error(error) {
    console.error("Error:", error.message);
}


var p1 = findPrimes(2, 200000);
p1
    .then(result => console.log(`Found ${result.primes.length} in range ${result.min}-${result.max}`))
    .catch(error => console.log("Error:", error));


var p2 = findPrimes(2, 200);
p2
    .then(print_primes)
    .catch(print_error);

findPrimes(100, 1)
    .then(print_primes) //this will not execute
    .catch(print_error); //this will be executed

findPrimes(2, 100000)
    .then(print_primes)
    .catch(print_error);
