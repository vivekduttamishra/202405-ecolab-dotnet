

function Person(name,age){
    //let P= new Object();
    this. name=name;
    this.age=age;
    this.eat=function(food){
            console.log(`${this.name} is eating ${food}`);
    };

    this.move=function(from,to){
        console.log(`${this.name} is moving from ${from} to ${to}`);
    }

    this.toString=function(){
        return `Person[Name=${this.name}\tAge=${this.age}]`
    }

    //return p;
}

var sanjay = new Person("Sanjay",50);

console.log(sanjay);

