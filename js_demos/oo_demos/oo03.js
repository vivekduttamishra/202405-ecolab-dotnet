

function showPerson(p){
    console.log('person=>',p);
}

var p={
    name:'Sanjay',
    age:50
};

p.email="sanjay@gmail.com";
p["phone"]="993939393";

showPerson(p);

console.log('p["email"]',p["email"]);
console.log('p.phone',p.phone);


