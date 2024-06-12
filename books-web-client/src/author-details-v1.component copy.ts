import { Component } from "@angular/core";
import AuthorInfo from './author';

@Component({
    standalone: true,
    selector: 'author-details-1',
    template:`
        <div class="header">
            <h1>{{title}}</h1>
            <h3>{{slogan}}</h3>
        </div>
        <div class="content">
            <h2>{{author.name}}</h2>
            <div class='author-info'>
                <div class='left'>
                    <img src={{author.photograph}} 
                         alt={{author.name}} 
                         title={{author.name}} />
                </div>
                <div class='right'>
                    <h3>Biography</h3>
                    <p>{{author.biography}}</p>
                </div>
            </div>
        </div>
    `,
    styles:[
        `
            .header{
                border-bottom: 2px solid gray;
            } 
            .header h3{
                font-style: italic;
                color:darkgray;
            } 
                
            .author-info{
                display:flex;

            }
            .author-info .left{
                padding-right: 10px;
                border-right:1px solid gray;
                margin-right:10px;
            }

            img{
                border:10px solid black;
                padding:5px;
                box-shadow:-5px -5px 5px gray;
                border-radius:20px;
            }

        `
    ]
})
export class AuthorDetailsComponentV1{
    title="World Wide Books";
    slogan="The Official Home Page of all the books in the world";
    author= new AuthorInfo('vivek',
        "Vivek Dutta Mishra",'The Author of The Lost Epic Series and Manas',"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCFlHW7IBctOZc9PQG0fojV04Rzt4iHzxE8A&s");
}

