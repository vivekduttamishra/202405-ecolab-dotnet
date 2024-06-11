

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

function createCar(brand,registration){
    var car= new Object();
    car.brand=brand;
    car.registration=registration;
    car.drive=function(){
        console.log(`${this.brand} is driving`);
    }

    return car;
}
