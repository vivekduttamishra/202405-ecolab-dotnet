import { Directive, Input } from "@angular/core";
import { AbstractControl, NG_VALIDATORS, ValidationErrors, Validator } from "@angular/forms";


export function custom_password(min=8, max=20, special_character_count=1,special_characters='~!@#$%^&*()_-+=>.,</?{}[]'){

    //return your validation function from here
    function actual_validator(control:AbstractControl):ValidationErrors|null{

        var value = control.value;
        
        if (!value)
            return null; //I don't care about required field.
    
        if(value.length<min){
           
            return{
                custom_password:{
                    message: `Password must be at least ${min} characters long`,
                    actual: value.length,
                }
            }
        }
        if(value.length>max){
           
            return{
                custom_password:{
                    message: `Password must not be more than ${max} characters long`,
                    actual: value.length,
                }
            }
        }
    
        if(!value.match(/[A-Z]/)){
            return {
                custom_password:{
                    message: 'Password must contain at least one uppercase letter'
                }
            }
        }
    
        if(!value.match(/[a-z]/)){
            return {
                custom_password:{
                    message: 'Password must contain at least one lower letter'
                }
            }
        }
    
        
        
        var count=0;
        for(var i=0;i<value.length;i++){
            if(special_characters.indexOf(value[i])>=0){
                count++;
                
            }
        }
    
        if(count<special_character_count){
            return {
                custom_password:{
                    message: `Password must contain at least ${special_character_count} special symbol`,
                    found:count
                }
            }
        }
    
    
    
        return null; //success
    
    }


    return actual_validator;
}

interface CustomPasswordParams{
    min?:number;
    max?:number;
    special_character_count?:number;
    special_characters?:string;
}

@Directive({
    selector:"[custom-password]",
    standalone:true,
    providers:[
        {
            provide: NG_VALIDATORS,
            useExisting:CustomPasswordValidator,
            multi:true,
        }
    ]
        
})
export class CustomPasswordValidator implements Validator{
    
    @Input("custom-password") params?:CustomPasswordParams; 
    
    defaults:CustomPasswordParams={
        min:8,
        max:20,
        special_character_count:1,
        special_characters:'~!@#$%^&*()_-+=>.,</?{}[]'
    }

    validator?: (control:AbstractControl<any,any>) => ValidationErrors|null;

    ngOnInit(){
        if(!this.params)
            this. params={};

        var p= {
            ...this.defaults, //use default
            ...this.params    //replace matching with user provided values
        }

        this.validator=custom_password(p.min,p.max,p.special_character_count,p.special_characters)
    }

    validate(control: AbstractControl<any, any>): ValidationErrors | null {
       if(this.validator)
            return this.validator(control);
        else
            return null;
    }

    

}



