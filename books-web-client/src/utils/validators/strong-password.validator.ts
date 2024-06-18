import { AbstractControl, ValidationErrors } from "@angular/forms";


export function strong_password(control:AbstractControl):ValidationErrors|null{

    var value = control.value;
    
    if (!value)
        return null; //I don't care about required field.

    if(value.length<8){
       
        return{
            strong_password:{
                message: 'Password must be at least 8 characters long',
                actual: value.length,
            }
        }
    }
    if(value.length>15){
       
        return{
            strong_password:{
                message: 'Password must not be more than 15 characters long',
                actual: value.length,
            }
        }
    }

    if(!value.match(/[A-Z]/)){
        return {
            strong_password:{
                message: 'Password must contain at least one uppercase letter'
            }
        }
    }

    if(!value.match(/[a-z]/)){
        return {
            strong_password:{
                message: 'Password must contain at least one lower letter'
            }
        }
    }

    var specialSymbols = "#@%^&*().??{}[]!~";
    
    var match=false;
    for(var i=0;i<specialSymbols.length;i++){
        if(value.indexOf(specialSymbols[i])>=0){
            match=true;
            break;
        }
    }

    if(!match){
        return {
            strong_password:{
                message: 'Password must contain at least one special symbol'
            }
        }
    }



    return null; //success

}