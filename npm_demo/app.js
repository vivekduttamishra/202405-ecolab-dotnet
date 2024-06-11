class Author{
    constructor(name,photo){
        this.name = name;
        this.id= name.toLowerCase().replace(' ','-');
        this.photo=photo;
    }
}

class AuthorManager{
    constructor(){
        this.authors = [
            new Author("Mahagma Gandhi","https://pbs.twimg.com/profile_images/185517358/mahatmagandhi_400x400.jpg"),
            new Author("Vivek Dutta Mishra","https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCFlHW7IBctOZc9PQG0fojV04Rzt4iHzxE8A&s"),
            new Author("Ramdhari Singh Dinkar","https://pbs.twimg.com/profile_images/1269658848777785345/2bY35KV0_400x400.jpg"),
        ];
    }
}

function getAuthors(){
    var manager=new AuthorManager();
    var authors=manager.authors;
    var authorsTable=$("#authors")

    authors.forEach(author=>{
        authorsTable.append(`
        <tr>
            <td><img src="${author.photo}" alt="${author.name}" width="100" height="100"></td>
            <td>${author.name}</td>
            <td>
                <a href="/author/info/${author.id}"  class="btn btn-sm btn-primary"><i class="fa-solid fa-circle-info"></i> Info</a>
                <a href="/author/edit/${author.id}"  class="btn btn-sm btn-primary"><i class="fa-regular fa-pen-to-square"></i> Edit</a>
                <a href="/author/delete/${author.id}"  class="btn btn-sm btn-danger"><i class="fa-solid fa-trash"></i> Delete</a>

            </td>
        </tr>
        `);
    })
}