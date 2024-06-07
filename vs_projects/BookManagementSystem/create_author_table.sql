

CREATE TABLE Authors(

        id VARCHAR(255) PRIMARY KEY, 
        name VARCHAR(255) NOT NULL, 
        biography VARCHAR(2500), 
        photograph VARCHAR(500), 
        email VARCHAR(250) default('') 
                    
)