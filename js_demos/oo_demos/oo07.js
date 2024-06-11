

function createPerson(name,age){
    let p= new Object();
    p. name=name;
    p.age=age;
    p.eat=function(food){
            console.log(`${this.name} is eating ${food}`);
    };

    p.move=function(from,to){
        console.log(`${this.name} is moving from ${from} to ${to}`);
    }

    p.toString=function(){
        return `Person[Name=${this.name}\tAge=${this.age}]`
    }

    return p;
}

var sanjay= createPerson('Sanjay',50);
var shivanshi=createPerson('Shivanshi',17);

console.log(`${sanjay}`);
console.log('shivanshi',shivanshi);

sanjay.eat('Lunch');
sanjay.move('Home','Office');

shivanshi.eat('Breakfast');
shivanshi.move('Home','School');
