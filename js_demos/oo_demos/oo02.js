

function showPerson(p){
    console.log('person=>',p);
}

var p1 = {} // same as new Object(); 
p1.name="Sanjay";
p1.age=50;
showPerson(p1);

//we can also initialize the object while creating
var p2= {
    name:"Shivanshi",
    age:16
}

showPerson(p2);
