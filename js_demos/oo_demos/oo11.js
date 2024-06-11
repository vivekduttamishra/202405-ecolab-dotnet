

function Person(name,age){
    //let P= new Object();
    this. name=name;
    this.age=age;
    this.eat=function(food){
            console.log(`${this.name} is eating ${food}`);
    };
   
}

Person.prototype.move=function(from,to){
    console.log(`${this.name} is moving from ${from} to ${to}`);
}

Person.prototype.toString=function(){
    return `Person[Name=${this.name}\tAge=${this.age}]`
}
