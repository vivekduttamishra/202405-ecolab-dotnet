function show_args(x,y=10){
    console.log(`x=${x}\ty=${y}\t arguments=`,arguments);
    
}

show_args(1,2);
show_args(1,2,3,4,5,6);
show_args(1);
show_args();