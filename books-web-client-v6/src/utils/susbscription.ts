



class Subscription<T>{
    private _unsubscribed: any;
    update(books: import("../books/models/book.model").Book[]) {
      throw new Error('Method not implemented.');
    }

    subscriber?: ((args:T)=>void);
    _unsubscribe: boolean= false;

   
    subscribe(subsciber: (args:T)=> void){
        this.subscriber=subsciber;
    }

    unsubscribe(){
        this._unsubscribe=true;
    }

    isUnsubscribed(){
        return this._unsubscribe;
    }

}