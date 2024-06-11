

class Person
{
    constructor(name, age){
        this.name=name;
        this.age=age;
    }

    eat(food){
        console.log(`${this.name} is eating ${food}`);
    }

    move(from,to){
        console.log(`${this.name} moves from ${from} to ${to}`);
    }

    toString(){
        return `${this.name} is ${this.age} years old`;
    }
}


class Employee extends Person{
    constructor(id,name,age,salary){
        super(name,age);
        this.id=id;
        this.salary=salary;
    }
}

var p1= new Person("Sanjay",50)
p1.eat("Lunch");
