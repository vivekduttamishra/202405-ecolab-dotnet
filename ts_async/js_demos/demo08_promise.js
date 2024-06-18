
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
    r1= await findPrimes(0,200000);
    console.log(r1);

    r2=await findPrimes(0,200);
    console.log(r2);
}

main();