

function showPerson(p){
    console.log('person=>',p);
}

var p={
    name:'Sanjay',
    age:50
};

p.email="sanjay@gmail.com";
p["phone"]="993939393";

for(var x in p)
    console.log(x,p[x]);


