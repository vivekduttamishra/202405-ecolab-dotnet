package test.multithreading18.futureandcallable;

public class PrimeResult {
	
	int min;
	int max;
	int primes;
	public int getMin() {
		return min;
	}
	public int getMax() {
		return max;
	}
	public int getPrimes() {
		return primes;
	}
	public PrimeResult(int min, int max) {
		super();
		this.min = min;
		this.max = max;
	}
	
	public void addPrime() { primes++; }
	@Override
	public String toString() {
		return "Result [min=" + min + ", max=" + max + ", primes=" + primes + "]";
	}
	
	

}
