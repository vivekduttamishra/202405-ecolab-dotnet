

namespace demo05{

    class Name{
        firstName:string;
        lastName:string;
        constructor(firstName:string,lastName:string){
            this.firstName=firstName;
            this.lastName=lastName;
        }
        toString():string{
            return `${this.firstName} ${this.lastName}`;
        }
    }

    class Address
    {
       
        constructor(private street:string, private city:string){
           
        }
    }

    interface Person{
        name:string|Name,
        email:string|null;
    }

    var people: Person[]=[
        {name:"Vivek Dutta Mishra", email:"vivek@duttamishra.net"},
        
        {name: new Name("Sanjay","Mall"), email:null},
        
        {name: new Name("Mr","420"), email:"420@9211.com"},
    ]

    for(var person of people)
        console.log(`${person.name} - ${person.email??''}`);

  
}