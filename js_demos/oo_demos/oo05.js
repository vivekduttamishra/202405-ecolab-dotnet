

function showPerson(p){
    console.log('person=>',p);
}

function eat(person,food){
    console.log(`${person.name} is eating ${food}`);
}


let sanjay = new Object();
sanjay.name="Sanjay";
sanjay.eat=eat; //attach eat to p1

let shivanshi={name:"Shivanshi",eat:eat};

sanjay.eat(sanjay,"Lunch");

sanjay.eat(shivanshi,"Breakfast");



