

function showPerson(p){
    console.log('person=>',p);
}

function eat(food){
    console.log(`${this.name} is eating ${food}`);
}


let sanjay = new Object();
sanjay.name="Sanjay";
sanjay.eat=eat; //attach eat to p1

let shivanshi={name:"Shivanshi",eat:eat};

sanjay.eat("Lunch");

shivanshi.eat("Breakfast");



