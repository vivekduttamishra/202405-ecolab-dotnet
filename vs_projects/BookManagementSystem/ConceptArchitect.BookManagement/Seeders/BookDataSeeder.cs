using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{

    public interface IDataSeeder
    {
        Task SeedData();
    }


    public class BookDataSeeder : IDataSeeder
    {

        IAuthorService authorService;
        IBookService bookService;
        IUserService userService;
        Random rnd = new Random();


        public BookDataSeeder(IAuthorService authorService, 
                                     IBookService bookService,
                                     IUserService userService)
        {
            this.authorService = authorService;
            this.bookService = bookService;
            this.userService = userService;
        }
        public async Task SeedData()
        {
            await SeedWellknownAuthors();
            await SeedWellKnownBooks();
            await SeedUsers();
            await SeedReviews();
            await SeedBookSheleves();
        }

        private async Task SeedWellknownAuthors()
        {
            await authorService.AddAuthor(new Author { Name = "Vivek Dutta Mishra", BirthDate = new DateTime(1977, 7, 9), DeathDate = null, Biography = "The Best selling Author of The Lost Epic Series and Manas and co-author is several anthology.  Welknown podcaster and expert on Indian History and Mahabharata.", Photograph = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCFlHW7IBctOZc9PQG0fojV04Rzt4iHzxE8A&s" });
            await authorService.AddAuthor(new Author { Name = "Ramdhari Singh Dinkar", BirthDate = new DateTime(1908, 9, 23), DeathDate = new DateTime(1974, 4, 24), Biography = "The National Poet of India, freedom fighter and historian. His books Rashmirathi, Urvashi and Kurukshetra are exremely famous.", Photograph = "https://pbs.twimg.com/profile_images/1269658848777785345/2bY35KV0_400x400.jpg" });
            await authorService.AddAuthor(new Author { Name = "Mahatma Gandhi", Biography = "Father of the Nation of India, Freedom fighter, Social reformer. Revered world wide as the Masihah of truth and non-violence and deemed as the man of the century", Photograph = "https://pbs.twimg.com/profile_images/185517358/mahatmagandhi_400x400.jpg" });
            await authorService.AddAuthor(new Author { Name = "Jeffrey Archer", BirthDate = new DateTime(1940, 04, 15), DeathDate = null, Biography = "Contemporary Bestseller Brithish author, parliamentarian and ex-convict. He has written several best seller in varied topics.", Photograph = "https://pbs.twimg.com/profile_images/3751745623/11bd5e198e1f0f7de40ffdf08f556293_400x400.jpeg" });
            await authorService.AddAuthor(new Author { Name = "John Grisham",   BirthDate = new DateTime(1955, 2, 8), DeathDate = null, Biography = " According to the American Academy of Achievement, Grisham has written 37 consecutive number-one fiction bestsellers, and his books have sold 300 million copies worldwide. Along with Tom Clancy and J. K. Rowling, Grisham is one of only three anglophone authors to have sold two million copies on the first printing", Photograph = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQthaeZGsdX1MTIqZTSqsTZrHoDBI35vPrssg&s" });
            await authorService.AddAuthor(new Author { Name = "Alexandre Dumas", BirthDate = new DateTime(1802, 07, 24), DeathDate = new DateTime(1870, 10, 05), Biography = "French novelist and playwright.\r\n\r\nHis works have been translated into many languages and he is one of the most widely read French authors. Many of his historical novels of adventure were originally published as serials, including The Count of Monte Cristo, The Three Musketeers, Twenty Years After and The Vicomte of Bragelonne: Ten Years Later. Since the early 20th century, his novels have been adapted into nearly 200 films. Prolific in several genres, Dumas began his career by writing plays, which were successfully produced from the first. He wrote numerous magazine articles and travel books; his published works totalled 100,000 pages.[3] In the 1840s, Dumas founded the Théâtre Historique in Paris.", Photograph= "https://cdn.vocab.com/units/h3ekjthk/author.jpg?width=400&v=176fc5c134d" });
            await authorService.AddAuthor(new Author { Name = "Charles Dickens", BirthDate = new DateTime(1812, 02, 07), DeathDate = new DateTime(1870, 06, 09), Biography = "Charles John Huffam Dickens (/ˈdɪkɪnz/; 7 February 1812 – 9 June 1870) was an English novelist, journalist, short story writer and social critic. He created some of literature's best-known fictional characters, and is regarded by many as the greatest novelist of the Victorian era.[1] His works enjoyed unprecedented popularity during his lifetime and, by the 20th century, critics and scholars had recognised him as a literary genius. His novels and short stories are widely read today.", Photograph= "https://cdn.vocab.com/units/4o42qceu/author.jpg?width=400&v=16c913c23d6" });
            await authorService.AddAuthor(new Author { Name = "J K Rowlings",     BirthDate = new DateTime(1965, 7, 31), DeathDate = null, Biography = "Joanne Rowling CH OBE FRSL (/ˈroʊlɪŋ/ ROH-ling;[1] born 31 July 1965), known by her pen name J. K. Rowling, is a British author and philanthropist. She wrote Harry Potter, a seven-volume fantasy series published from 1997 to 2007. The series has sold over 600 million copies, been translated into 84 languages, and spawned a global media franchise including films and video games. The Casual Vacancy (2012) was her first novel for adults. She writes Cormoran Strike, an ongoing crime fiction series, under the alias Robert Galbraith.", Email = "jkr@hogwards.net", Photograph = "https://static.toiimg.com/thumb/msid-76027268,width-400,resizemode-4/76027268.jpg" });
            await authorService.AddAuthor(new Author { Name = "Munshi Premchand",BirthDate = new DateTime(1880, 7, 31), DeathDate = new DateTime(1936, 10, 08), Biography = "Premchand was a pioneer of Hindi and Urdu social fiction. He was one of the first authors to write about caste hierarchies and the plights of women and labourers prevalent in the society of the late 1880s.[5] He is one of the most celebrated writers of the Indian subcontinent,[6] and is regarded as one of the foremost Hindi writers of the early twentieth century.[7] His works include Godaan, Karmabhoomi, Gaban, Mansarovar, and Idgah. He published his first collection of five short stories in 1907 in a book called Soz-e-Watan (Sorrow of the Nation).\r\n\r\nHis works include more than a dozen novels, around 300 short stories, several essays and translations of a number of foreign literary works into Hindi.", Photograph= "https://pbs.twimg.com/profile_images/1251088697203679233/fdW0tbbO_400x400.jpg" });
            await authorService.AddAuthor(new Author { Name = "Conan Doyle",     BirthDate = new DateTime(1859, 5, 22), DeathDate = new DateTime(1930, 7, 7), Biography = "Author of the greatest detective Sherlock Holmes, Sir Arthur Ignatius Conan Doyle KStJ, DL (22 May 1859 – 7 July 1930) was a British writer and physician. He created the character Sherlock Holmes in 1887 for A Study in Scarlet, the first of four novels and fifty-six short stories about Holmes and Dr. Watson. The Sherlock Holmes stories are milestones in the field of crime fiction.\r\n\r\nDoyle was a prolific writer. In addition to the Holmes stories, his works include fantasy and science fiction stories about Professor Challenger, and humorous stories about the Napoleonic soldier Brigadier Gerard, as well as plays, romances, poetry, non-fiction, and historical novels. One of Doyle's early short stories, \"J. Habakuk Jephson's Statement\" (1884), helped to popularise the mystery of the Mary Celeste.", Photograph = "https://cdn.vocab.com/units/fsyoq26b/author.jpg?width=400&v=16d64ff4cf4" });
            await authorService.Save();

        }

        public async Task SeedWellKnownBooks()
        {
            await bookService.AddBook(new Book
            {
                Title = "The Accursed God",
                Author = await authorService.GetAuthorById("vivek-dutta-mishra"),
                Price = 399,
                Rating = 4.7,
                Votes=275,
                CoverPhoto = "https://m.media-amazon.com/images/I/81c-qj2VZSL._SY522_.jpg",                
                Description =  "The Best selling First Part of the the Lost Epic Series based Mahabharata." +
                               "The Lost Epic\r\nThe epic battle of Kurukshetra has been told and retold for ages. Millennia of dust, fables, imaginations — and the epic is lost. What remains is the story of a family feud and the ambition of Kauravas and Pandavas. But why, then, did this war become an epic? How did it suck the entire Aryavart into its flames? Why does the echo of this ancient clash of titans still resonate after all those centuries? Rediscover the lost epic whose origin lies in the birth of the Kurukshetra that had tasted its first blood over a hundred years before the final Mahabharata war. Are you ready to uncover the secrets of the lost epic, a saga that transcends the ambitions of the Kauravas and Pandavas, revealing a forgotten legacy waiting to be rediscovered?\r\nThe Accursed God\r\nLong before the epic battle, long before even the birth of Kurukshetra, a man swore on his father’s pyre to topple the mightiest empire any civilisation had ever seen. His journey was of relentless pursuit, driven by an oath taken amidst flames and ashes.\r\nBetween his might and near-certain destruction of the Empire stood a lone warrior who rose like a phoenix from the ashes of his seven dead brothers — taking the mantle of a fabled Accursed God. \r\nIn the clash that followed, Aryavart heard several more oaths by the side of more burning pyres until a young king decided that no price was too high for peace. Little did he know that the price would be a war engulfing the entire Aryavart, where few would live to tell the tale. Can the Accursed God halt the march of destiny,  or is destiny like quicksand, where his every action would hasten Aryavart's further descent into catastrophe? \r\nDiscover the saga of a man’s journey to that of a legendary Accursed God, whose name is both feared and reviled — the saga of ruthless ambitions and unfulfilled loves, endless deceits and vengeful oaths, and of the battles to prevent the ultimate war.\r\n"
            });

            await bookService.AddBook(new Book
            {
                Id = "manas",
                Title = "Manas (मानस)",
                Author = await authorService.GetAuthorById("vivek-dutta-mishra"),
                Price = 199,
                Rating = 4.5,
                Votes=120,
                CoverPhoto = "https://m.media-amazon.com/images/I/71MvJTjRjPL._SY522_.jpg",
                Description =   "A Hindi poetic take on Mahabharata with an attempt to bust out common distorive myth around one of the greatest epic ever told" +
                                "It is set after the end of Mahabharata epic when Yudhishthira, the elder Pandava acends to heaven only to realise" +
                                "that his brothers are languishing in hell, while Duryodhana is enjoying the luxaries in the afterline" +
                                "Anguished by this injustice, Yudhishitra blames Swarga and laments his understanding of Dharma." +
                                "Krishna sets up a committee to rexamine what happened and why and what role each of them played." +
                                "The book is based on non-fictioanal authentic account of Mahabharata."
            });

            await bookService.AddBook(new Book
            {
                Title = "My Experiements With The Truth",
                Author = await authorService.GetAuthorById("mahatma-gandhi"),
                Price = 149,
                Rating = 4.4,
                Votes=300000,
                CoverPhoto = "https://m.media-amazon.com/images/I/71r55-KjjpL._SY522_.jpg",
                Description = "This is the autobiography of Mahatma Gandhi, covering his life from early childhood through to 1921. It was written in weekly installments and published in his journal Navjivan from 1925 to 1929. Its English translation also appeared in installments in his other journal Young India.[1] It was initiated at the insistence of Swami Anand and other close co-workers of Gandhi, who encouraged him to explain the background of his public campaigns. In 1998, the book was designated as one of the \"100 Best Spiritual Books of the 20th Century\" by a committee of global spiritual and religious authorities."
            });

            await bookService.AddBook(new Book
            {
                Title = "The Count of Monte Cristo",
                Author = await authorService.GetAuthorById("alexandre-dumas"),
                Price = 298,
                Rating = 4.6,
                Votes=200000,
                CoverPhoto = "https://m.media-amazon.com/images/I/61j4bBLKA4L._SY522_.jpg",
                Description = "The victim of a miscarriage of justice, Edmund Dantes is fired by a desire for retribution and empowered by a stroke of Providence. In his campaign of vengeance, he becomes an anonymous agent of fate. One of the altime best-seller and classic"
            });

            await bookService.AddBook(new Book
            {
                Id="harry-potter-01",
                Title = "Harry Potter and the Philosopher's Stone",
                Author = await authorService.GetAuthorById("j-k-rowlings"),
                Price = 149,
                Rating = 4.7,
                Votes=112036,
                CoverPhoto = "https://m.media-amazon.com/images/I/81m9fP+LIPL._SY522_.jpg",
                Description = "Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry's eleventh birthday, a great beetle-eyed giant of a man called Rubeus Hagrid bursts in with some astonishing news: Harry Potter is a wizard, and he has a place at Hogwarts School of Witchcraft and Wizardry. An incredible adventure is about to begin!"
            });

            await bookService.AddBook(new Book
            {
                Id = "harry-potter-02",
                Title = "Harry Potter and the Chamber of Secrets",
                Author = await authorService.GetAuthorById("j-k-rowlings"),
                Price = 149,
                Rating = 4.7,
                Votes = 112036,
                CoverPhoto = "https://m.media-amazon.com/images/I/81Wbfijio4L._SY522_.jpg",
                Description = "'There is a plot, Harry Potter. A plot to make most terrible things happen at Hogwarts School of Witchcraft and Wizardry this year.'\r\n\r\nHarry Potter's summer has included the worst birthday ever, doomy warnings from a house-elf called Dobby, and rescue from the Dursleys by his friend Ron Weasley in a magical flying car! Back at Hogwarts School of Witchcraft and Wizardry for his second year, Harry hears strange whispers echo through empty corridors - and then the attacks start. Students are found as though turned to stone... Dobby's sinister predictions seem to be coming true."
            });
            await bookService.AddBook(new Book
            {
                Id = "harry-potter-03",
                Title = "Harry Potter and the Prisoner of Askaban",
                Author = await authorService.GetAuthorById("j-k-rowlings"),
                Price = 306,
                Rating = 4.8,
                Votes = 39979,
                CoverPhoto = "https://m.media-amazon.com/images/I/51n7uF9FfxL._SY445_SX342_.jpg",
                Description = "'Welcome to the Knight Bus, emergency transport for the stranded witch or wizard. Just stick out your wand hand, step on board and we can take you anywhere you want to go.'\r\n\r\nWhen the Knight Bus crashes through the darkness and screeches to a halt in front of him, it's the start of another far from ordinary year at Hogwarts for Harry Potter. Sirius Black, escaped mass-murderer and follower of Lord Voldemort, is on the run - and they say he is coming after Harry. In his first ever Divination class, Professor Trelawney sees an omen of death in Harry's tea leaves... But perhaps most terrifying of all are the Dementors patrolling the school grounds, with their soul-sucking kiss..."
            });
            await bookService.AddBook(new Book
            {
                Id = "harry-potter-04",
                Title = "Harry Potter and the Goblet of Fire",
                Author = await authorService.GetAuthorById("j-k-rowlings"),
                Price = 149,
                Rating = 4.8,
                Votes = 70826,
                CoverPhoto = "https://m.media-amazon.com/images/I/81YoazRCtBL._SY522_.jpg",
                Description = "'There will be three tasks, spaced throughout the school year, and they will test the champions in many different ways ... their magical prowess - their daring - their powers of deduction - and, of course, their ability to cope with danger.'\r\n\r\nThe Triwizard Tournament is to be held at Hogwarts. Only wizards who are over seventeen are allowed to enter - but that doesn't stop Harry dreaming that he will win the competition. Then at Hallowe'en, when the Goblet of Fire makes its selection, Harry is amazed to find his name is one of those that the magical cup picks out. He will face death-defying tasks, dragons and Dark wizards, but with the help of his best friends, Ron and Hermione, he might just make it through - alive!"
            });

            await bookService.AddBook(new Book
            {
                Id = "harry-potter-05",
                Title = "Harry Potter and the Order of Phoenix",
                Author = await authorService.GetAuthorById("j-k-rowlings"),
                Price = 149,
                Rating = 4.7,
                Votes = 33753,
                CoverPhoto = "https://m.media-amazon.com/images/I/51iQwWIl+XL._SY445_SX342_.jpg",
                Description = "'You are sharing the Dark Lord's thoughts and emotions. The Headmaster thinks it inadvisable for this to continue. He wishes me to teach you how to close your mind to the Dark Lord.'\r\n\r\nDark times have come to Hogwarts. After the Dementors' attack on his cousin Dudley, Harry Potter knows that Voldemort will stop at nothing to find him. There are many who deny the Dark Lord's return, but Harry is not alone: a secret order gathers at Grimmauld Place to fight against the Dark forces. Harry must allow Professor Snape to teach him how to protect himself from Voldemort's savage assaults on his mind. But they are growing stronger by the day and Harry is running out of time..."
            });

            await bookService.AddBook(new Book
            {
                Id = "harry-potter-06",
                Title = "Harry Potter and the Half Blood Prince",
                Author = await authorService.GetAuthorById("j-k-rowlings"),
                Price = 149,
                Rating = 4.7,
                Votes = 78301,
                CoverPhoto = "https://m.media-amazon.com/images/I/813zbNPhO5L._SY522_.jpg",
                Description = "There it was, hanging in the sky above the school: the blazing green skull with a serpent tongue, the mark Death Eaters left behind whenever they had entered a building... wherever they had murdered...\r\n\r\nWhen Dumbledore arrives at Privet Drive one summer night to collect Harry Potter, his wand hand is blackened and shrivelled, but he does not reveal why. Secrets and suspicion are spreading through the wizarding world, and Hogwarts itself is not safe. Harry is convinced that Malfoy bears the Dark Mark: there is a Death Eater amongst them. Harry will need powerful magic and true friends as he explores Voldemort's darkest secrets, and Dumbledore prepares him to face his destiny..."
            });
            await bookService.AddBook(new Book
            {
                Id = "harry-potter-07",
                Title = "Harry Potter and the Deathly Hollows",
                Author = await authorService.GetAuthorById("j-k-rowlings"),
                Price = 249,
                Rating = 4.8,
                Votes = 89902,
                CoverPhoto = "https://m.media-amazon.com/images/I/81qmfY6mMrL._SY522_.jpg",
                Description = "'Give me Harry Potter,' said Voldemort's voice, 'and none shall be harmed. Give me Harry Potter, and I shall leave the school untouched. Give me Harry Potter, and you will be rewarded.'\r\n\r\nAs he climbs into the sidecar of Hagrid's motorbike and takes to the skies, leaving Privet Drive for the last time, Harry Potter knows that Lord Voldemort and the Death Eaters are not far behind. The protective charm that has kept Harry safe until now is broken, but he cannot keep hiding. The Dark Lord is breathing fear into everything Harry loves and to stop him Harry will have to find and destroy the remaining Horcruxes. The final battle must begin - Harry must stand and face his enemy..."
            });

            await bookService.AddBook(new Book
            {
                Title = "The Exchange",
                Author = await authorService.GetAuthorById("john-grisham"),
                Price = 473,
                Rating = 3.9,
                Votes = 89902,
                CoverPhoto = "https://m.media-amazon.com/images/I/71WLkq4iTXL._SY522_.jpg",
                Description = "'It leaves the reader gasping for breath' DAILY MAIL\r\n\r\n'This is Grisham delivering the kind of mesmeric narrative that we expect from him' FINANCIAL TIMES\r\n\r\n\r\n***THE BIGGEST GRISHAM IN OVER A DECADE***\r\n\r\n\r\nThe Exchange is John Grisham's epic follow-up to his phenomenal global bestseller The Firm, the novel that launched his career as the world's favourite storyteller - it will take you on a rollercoaster journey across the globe, from New York to London, and Rome to Marrakech."
            });

            await bookService.AddBook(new Book
            {
                Title = "A Time to Kill",
                Author = await authorService.GetAuthorById("john-grisham"),
                Price = 326,
                Rating = 4.3,
                Votes = 89902,
                CoverPhoto = "https://m.media-amazon.com/images/I/81e-b8aSHgL._SY522_.jpg",
                Description = "John Grisham's first and most shocking legal thriller, adapted as a film starring Samuel L. Jackson and Matthew McConaughey.\r\n______________________________\r\n\r\nTHE MULTI-MILLION COPY BESTSELLER FROM THE MASTER OF LEGAL THRILLERS\r\n\r\nWhen Carl Lee Hailey guns down the violent racists who raped his ten-year-old daughter, the people of the small town of Clanton, Mississippi see it as justice done, and call for his acquittal.\r\n\r\nBut when extremists outside Clanton - including the KKK - hear that a black man has killed two white men, they invade the town, determined to destroy anything and anyone that opposes their sense of justice. A media circus descends on Clanton."
            });

            await bookService.AddBook(new Book
            {
                Title = "Camino Ghosts",
                Author = await authorService.GetAuthorById("john-grisham"),
                Price = 322,
                Rating = 4.5,
                Votes = 5200,
                CoverPhoto = "https://m.media-amazon.com/images/I/81xLb8Ec8NL._SY522_.jpg",
                Description = "Following John Grisham's international bestsellers, Camino Island and Camino Winds, Camino Ghosts is the story of an island off the Florida coast with a haunted, violent history and an uncertain future.\r\n\r\nDark Isle off the Florida coast is said to be cursed: drownings, disappearances and hauntings have been the fate of intruders. The people who lived there were once enslaved. Now abandoned, it is the target of greedy developers.\r\n\r\nLovely Jackson is the last survivor and claims to be its legal owner. But there is not a shred of evidence to prove that is true.\r\n\r\nIt's unlikely that the developers will be deterred by the claims of one old woman. They have millions; Lovely only has Steve Mahon, a pro bono environmental lawyer, and Mercer Mann, a floundering novelist, to fight in her corner"
            });
            await bookService.AddBook(new Book
            {
                Title = "The Whistler",
                Author = await authorService.GetAuthorById("john-grisham"),
                Price = 230,
                Rating = 4.2,
                Votes = 760000,
                CoverPhoto = "https://m.media-amazon.com/images/I/81FO0FUeufL._SY522_.jpg",
                Description = "'The best thriller writer alive' Ken Follett\r\n\r\nThe most corrupt judge in US history. A young investigator with a secret informant.\r\n\r\nLacy Stoltz never expected to be in the firing line. Investigating judicial misconduct by Florida's one thousand judges, her cases so far have been relatively unexciting. That's until she meets Greg Myers, an indicted lawyer with an assumed name, who has an extraordinary tale to tell.\r\n\r\nMyers is representing a whistle blower who knows of a judge involved in organised crime. Along with her gangster associates this judge has facilitated the building of a casino on an Indian reservation. At least two people who opposed the scheme are dead. Since the casino was built, the judge has made several fortunes off undeclared winnings. She owns property around the world, hires private jets to take her where she wishes, and her secret vaults are overflowing with rare books, art and jewels.\r\n\r\nNo one has a clue what she's been doing - until now.\r\n\r\nUnder Florida law, those who help the state recover illegally acquired assets stand to gain a large percentage of them. Myers and his whistle blower friend could make millions.\r\n\r\nBut first they need Lacy to start an investigation. Is she ready to pit herself against the most corrupt judge in American history, a judge whose associates think nothing of murder?\r\n\r\nPraise for THE WHISTLER\r\n\r\n'Grisham really is the master of the legal thriller!' - 5-star reader review\r\n\r\n'A great read' - 5-star reader review\r\n\r\n'A thriller with plenty of action' - 5-star reader review\r\n\r\n'Another gripping tale' - 5-star reader review\r\n\r\n'Absolutely loved this book' - 5-star reader review\r\n\r\n\r\n350+ million copies, 45 languages, 9 blockbuster films:\r\nNO ONE WRITES DRAMA LIKE JOHN GRISHAM\r\n\r\n*** Lacy Stoltz returns in THE JUDGE'S LIST, the new must-read legal thriller coming this October!***\r\n\r\n"
            });

            await bookService.AddBook(new Book
            {
                Title = "Sherlock Homes The Complete Edition",
                Author = await authorService.GetAuthorById("conan-doyle"),
                Price = 230,
                Rating = 4.4,
                Votes = 20000,
                CoverPhoto = "https://m.media-amazon.com/images/I/81yJVuSu78L._SY522_.jpg",
                Description = "Sherlock Holmes is a fictional detective of the late 19th and early 20th centuries, who first appeared in publication in 1887. He is the creation of Scottish born author and physician Sir Arthur Conan Doyle. A brilliant London-based detective, Holmes is famous for his intellectual prowess, and is renowned for his skillful use of deductive reasoning (somewhat mistakenly - see inductive reasoning) and astute observation to solve difficult cases. He is arguably the most famous fictional detective ever created, and is one of the best known and most universally recognizable literary characters in any genre."
            });

            await bookService.AddBook(new Book
            {
                Title = "The Adventures of Sherlock Homes",
                Author = await authorService.GetAuthorById("conan-doyle"),
                Price = 125,
                Rating = 4.5,
                Votes = 1794,
                CoverPhoto = "https://m.media-amazon.com/images/I/81C1R0xbozL._SY522_.jpg",
                Description = "What made Sherlock Holmes a household name and cultural icon? This very first collection of stories featuring the astute sleuth and his loyal assistant, Dr. Watson. In these twelve ingenious mysteries, Holmes is embroiled in betrayal, abduction, thievery, deception, and murder. Relying on logic, driven by instinct, and employing his uncanny powers of observation, Holmes cracks the cases that elude Scotland Yard. For him, it’s rather elementary.\r\n\r\nThis Baker Street dozen by Sir Arthur Conan Doyle is all the evidence readers will need to understand why Sherlock Holmes is an enduring legend in detective fiction.\r\n\r\nRevised edition: Previously published as The Adventures of Sherlock Holmes, this edition of The Adventures of Sherlock Holmes (AmazonClassics Edition) includes editorial revisions."
            });

            await bookService.AddBook(new Book
            {
                Title = "Kurukshetra",
                Author = await authorService.GetAuthorById("ramdhari-singh-dinkar"),
                Price = 115,
                Rating = 4.5,
                Votes = 1905,
                CoverPhoto = "https://m.media-amazon.com/images/I/81foM6nOBiL._SY522_.jpg",
                Description = "Kurukshetra is a Hindi classic. It gives an extraordinary account of the Kurukshetra war mentioned in the Mahabharata. It describes in vivid details the armed confrontation that took place between the Pandavas and the Kauravas. This bloody war lasted eighteen days.\r\nThe author's own views on war are showcased in this work. He criticizes war but also admits that it is a necessary evil. It describes the demerits of war and the damage it does to mankind, through the medium of poetry.\r\n\r\nIn a situation where one's country's freedom is threatened, one must defend oneself even if one has to resort to war. The importance of power is also emphasized. The negative consequences of war have been highlighted through the dialogues between Bhishma and Yudhisthira and the latter's remorse over his own actions.\r\n\r\nKurukshetra is a beautifully written masterpiece and it has a timeless appeal. It was published by Rajpal in 2013 and is available in hardcover."
            });

            await bookService.AddBook(new Book
            {
                Title = "Sanskriti Ke Chaar Adhyaya",
                Author = await authorService.GetAuthorById("ramdhari-singh-dinkar"),
                Price = 349,
                Rating = 4.6,
                Votes = 722,
                CoverPhoto = "https://m.media-amazon.com/images/I/51ssFXwIj4L.jpg",
                Description = "...यह संभव है कि संसार में जो बड़ी-बड़ी ताकतें काम कर रही हैं, उन्हें हम पूरी तरह न समझ सकें, लेकिन इतना तो हमें समझना ही चाहिए कि भारत क्या है और कैसे इस राष्ट्र ने अपने सामाजिक व्यक्तित्व के विभिन्न पहलू कौन से हैं और उसकी सुदृढ़ एकता कहाँ छिपी हुई है ! भारत में बसने वाली कोई भी जाति यह दावा नहीं कर सकती कि भारत के समस्त मन और विचारों पर उसी का एकाधिकार है ! भारत आज जो कुछ है, उसकी रचना में भारतीय जनता के प्रत्येक भाग का योगदान है ! यदि हम इस बुनियादी बात को नहीं समझ पाते तो फिर हम भारत को भी समझने में असमर्थ रहेंगे ! और यदि भारत को हम नहीं समझ सके तो हमारे भाव, विचार और काम सब-के-सब अधूरे रह जायंगे और हम देश की ऐसी कोई सेवा नहीं कर सकेंगे, जो ठोस और प्रभावपूर्ण हो ! मेरा विचार है कि ‘दिनकर’ की पुस्तक इस बातों को समझने में, एक हद तक, सहायक होगी ! इसलिए, मैं इसकी सराहना करता हूँ और आशा करता हूँ कि इसे पढ़कर अनेक लोग लाभाविंत होंगे !"
            });

            await bookService.AddBook(new Book
            {
                Title = "Parshuram Ki Pratisha",
                Author = await authorService.GetAuthorById("ramdhari-singh-dinkar"),
                Price = 49,
                Rating = 4.7,
                Votes = 1722,
                CoverPhoto = "https://m.media-amazon.com/images/I/819256AWvhL._SY522_.jpg",
                Description = "परशुराम की प्रतीक्षा राष्ट्रकवि रामधारी सिंह 'दिनकर' द्वारा रचित खंडकाव्य की पुस्तक है। इस खंडकाव्य की रचना का काल 1962-63 के आसपास का है, जब चीनी आक्रमण के फलस्वरूप भारत को जिस पराजय का सामना करना पड़ा, उससे राष्ट्रकवि दिनकर अत्यंत व्यथित हुये और इस खंडकाव्य की रचना की।"
            });


            await bookService.AddBook(new Book
            {
                Title = "Rashmirathi",
                Author = await authorService.GetAuthorById("ramdhari-singh-dinkar"),
                Price = 139,
                Rating = 4.7,
                Votes = 7058,
                CoverPhoto = "https://m.media-amazon.com/images/I/71XEVjrMVoL._SY522_.jpg",
                Description = "‘रश्मिरथी’ आधुनिक हिन्दी साहित्य की एक कालजयी काव्य-कृति है। यह ‘दिनकर’ की सबसे प्रशंसित काव्य-कृतियों में से एक है।\r\n\r\nइस काव्य के केन्द्र में कर्ण का जीवन है जो ‘महाभारत’ में अविवाहित कुन्ती (पांडु की पत्नी) का पुत्र था, और जिसे उन्होंने जनमते ही छोड़ दिया था। कर्ण एक वर्णसंकर जाति में बड़ा हुआ, फिर भी अपने समय के सर्वश्रेष्ठ योद्धाओं में से एक बन गया। कौरवों की ओर से कर्ण का लड़ना पांडवों के लिए एक बड़ी चिन्ता थी, क्योंकि वह ऐसा महारथी था जिसे युद्ध में कोई हरा नहीं सकता था। दिनकर जी ने नैतिक दुविधाओं में फँसे कर्ण की मानव भावनाओं के सभी रंगों के साथ जो कहानी प्रस्तुत की है, वह उल्लेखनीय और अद्भुत है।\r\n\r\nदिनकर जी के शब्दों में—“कर्ण-चरित के उद्धार की चिन्ता इस बात का प्रमाण है कि हमारे समाज में मानवीय गुणों की पहचान बढ़नेवाली है। कुल और जाति का अहंकार विदा हो रहा है। आगे, मनुष्य केवल उसी पद का अधिकारी होगा जो उसके अपने सामर्थ्य से सूचित होता है, उस पद का नहीं, जो उसके माता-पिता या वंश की देन है। इसी प्रकार, व्यक्ति अपने निजी गुणों के कारण जिस पद का अधिकारी है, वह उसे मिलकर रहेगा, यहाँ तक कि उसके माता-पिता के दोष भी इसमें कोई बाधा नहीं डाल सकेंगे। कर्ण-चरित का उद्धार एक तरह से, नई मानवता की स्थापना का ही प्रयास है…!”"
            });

            await bookService.AddBook(new Book
            {
                Title = "Karmbhoomi",
                Author = await authorService.GetAuthorById("munshi-premchand"),
                Price = 139,
                Rating = 4.7,
                Votes = 7058,
                CoverPhoto = "https://m.media-amazon.com/images/I/61I1AhqGP8L._SY522_.jpg",
                Description = "Premchand weaves this novel around the social goals championed by it. Human life is portrayed as a field of action in which the character and destinies of individuals are formed and revealed through their actions. Some of these actions, which might seem melodramatic in ordinary realistic fiction, gain resonance in Karmabhumi, placed as they are in this symbolic and philosophical framework."
            });

            await bookService.AddBook(new Book
            {
                Title = "Traitors Gate",
                Author = await authorService.GetAuthorById("jeffrey-archer"),
                Price = 250,
                Rating = 4.3,
                Votes = 8761,
                CoverPhoto = "https://m.media-amazon.com/images/I/81rssdYTmJL._SY522_.jpg",
                Description = "The gripping new instalment in the William Warwick series, An Eye for an Eye, is available to pre-order now!\r\n\r\n24 hours to stop the crime of the century\r\nThe race against time is about to begin…\r\nTHE TOWER OF LONDON…\r\n\r\nImpenetrable. Well protected. Secure. Home to the most valuable jewels on earth. But once a year, the Metropolitan Police must execute the most secret operation in their armoury when they transport the Crown Jewels across London.\r\n\r\nSCOTLAND YARD…\r\n\r\nFor four years, Chief Superindendent William Warwick – together with his second-in-command Inspector Ross"
            });

            await bookService.AddBook(new Book
            {
                Title = "Kane and Abel",
                Author = await authorService.GetAuthorById("jeffrey-archer"),
                Price = 280,
                Rating = 4.6,
                Votes = 18761,
                CoverPhoto = "https://m.media-amazon.com/images/I/717S1DktIHL._SY522_.jpg",
                Description = "Jeffrey Archer's thrilling historical fiction novel, Kane and Abel, is a global phenomenon that has captivated readers worldwide, spawning two sequels and dominating bestseller charts the world over.\r\n\r\nTwo strangers born worlds apart with one destiny that will define them both.\r\n\r\nWilliam Lowell Kane, the son of a Boston millionaire, and Abel Rosnovski, the son of a penniless Polish immigrant, are born on the same day on opposite sides of the world and brought together by fate and the quest of a dream.\r\n\r\nLocked in a relentless struggle spanning sixty years and three generations, the two men battle for supremacy in pursuit of an empire, fuelled only by their hatred for the other and the knowledge it will end in triumph for one, and destruction of the other . . .\r\n"
            });

            await bookService.AddBook(new Book
            {
                Title = "Paths to Glory",
                Author = await authorService.GetAuthorById("jeffrey-archer"),
                Price = 250,
                Rating = 4.3,
                Votes = 8761,
                CoverPhoto = "https://m.media-amazon.com/images/I/71TNi+fV28L._SY522_.jpg",
                Description = "Inspired by the true story of mountaineer George Mallory, Paths of Glory bring to life one of history's enduringly enigmatic figures in a stunning novel from bestselling author Jeffrey Archer.\r\n\r\nSome people have dreams that are so outrageous that if they were to achieve them, their place in history would be guaranteed. Francis Drake, Robert Scott, Amy Johnson, and Neil Armstrong are among such individuals. But what if one man had such a dream, and when he'd fulfilled it, there was no proof that he had achieved his ambition?\r\n\r\nPaths of Glory is the story of such a man. But not until you've turned the last page of Jeffrey Archer's extraordinary novel, will you be able to decide if mountaineer George Mallory should be added to this list of legends, because if he were, another name would have to be removed."
            });

            await bookService.AddBook(new Book
            {
                Title = "An Eye for an Eye",
                Author = await authorService.GetAuthorById("jeffrey-archer"),
                Price = 2306,
                Rating = 0,
                Votes = 0,
                CoverPhoto = "https://m.media-amazon.com/images/I/81EZcjp4DoL._SY522_.jpg",
                Description = "The unputdownable new novel from international bestseller Jeffrey Archer – Pre-order now!\r\n\r\nIn one of the most luxurious cities on earth…\r\n\r\nA billion-dollar deal is about to go badly wrong. A lavish night out is about to end in murder. And the British government is about to be plunged into crisis.\r\n\r\nIn the heart of the British establishment…\r\n\r\nLord Hartley, the latest in a line of peers going back over two hundred years, lies dying. But his will triggers an inheritance with explosive consequences.\r\n\r\nTwo deaths. Continents apart. No obvious connection.\r\n\r\nSo why are they both at the centre of a master criminal's plot for revenge?"
            });

            await bookService.Save();

        }

        public async Task SeedUsers()
        {
            await userService.AddUser(new User { Name = "Vivek Dutta Mishra", Email = "vivek@conceptarchitect.in", Roles = { "User", "Admin" }, Password = "no.p@ssword#1" });
            await userService.AddUser(new User { Name = "Sanjay Mall", Email = "sanjay@gmail.com", Roles = { "User" }, Password = "no.p@ssword#1" });
            await userService.AddUser(new User { Name = "Reena Upadhayaya", Email = "reena@gmail.com", Roles = { "User", "Moderator" }, Password = "no.p@ssword#1" });
            await userService.AddUser(new User { Name = "Shivanshi Mishra", Email = "shivanshi@gmail.com", Roles = { "User", "Author" }, Password = "no.p@ssword#1" });
            await userService.Save();
        }

        public async Task SeedBookSheleves()
        {
            var books= await bookService.GetAllBooks();
            var users = await userService.GetAllUsers();
            var bookCount = books.Count;
            Random rnd = new Random();
            string[] notes = [
                "I liked the quote",
                "That is a a profound Thinking",
                "It resonates with my thought",
                "My personal favorite",
                "That should be life's phiolosophy",
                "This character is so real"
                ];

            foreach(var user in users)
            {
                List<string> bookIds = new List<string>();
                
                var email = user.Email;
                var bookToCount = rnd.Next(1, 5);
                for(int i = 0; i < bookToCount; i++)
                {
                    Book book = null;
                    do
                    {
                        book = books.GetRandom();

                    } while (bookIds.Contains(book.Id));

                    bookIds.Add(book.Id);

                    //create shelfItem
                    var bookShelf = new BookShelfItem
                    {
                        Book = book,
                        Status = Enum.GetValues<ReadingStatus>().GetRandom(),
                    };

                    if (bookShelf.Status == ReadingStatus.Read)
                    {
                        bookShelf.Rating = rnd.Next(1, 6);
                    }
                    var notesCount = rnd.Next(10);
                    for(int n=0;n<notesCount;n++)
                        bookShelf.Notes.Add(new BookNote
                        {
                            Location = $"Page {rnd.Next(1, 200)}",
                            Note= notes.GetRandom(),
                            //Book = book
                        });
                    

                    await userService.AddToShelf(email, bookShelf);            
                    
                }
            

            }

            await bookService.Save();
        }
    
        public async Task SeedReviews()
        {
            var books = await bookService.GetAllBooks();

            string[][] reviews =
            {
                new string[]{ }, 
                new string[]{ "Boring", "Not Worth Reading","Wasted My Time", "Nothing New Hear", "Absolute Boring", "I will never read this author again","Terrible", "Absolute Dud" },
                new string[]{ "TimePass", "Read if you have nothing else to do","Very Slow","Redundant Story","Nothing New Here","A very common place","Cliche" },
                new string[]{ "Nice but slow","I kinda like it, but won't recommend","The story lost somewhere", "What did the book say?","Could have been better","Good Story", "Good Narrative"},
                new string[]{ "Wonderful story","Oh! I like the narrative","I like this genre. It is a great read","Great Read. You should read it","Unexpected conclusion","Great story telling","Wonderful moment","Page turner"},
                new string[]{ "Most Extraordinary Experience","A Must read","I wish I had it sooner","A life changing experience","Add it to your Top 50 Todos"}
            };

            string[] fNames = { "Sanjay", "Vivek", "Reena", "Jayant", "Shayamal", "Rinku", "Amresh", "Prosanjeet", "Prabhat", "Tanya", "Asha" };
            string[] lNames = { "Singh", "Mishra", "Pandey", "Bhattacharya", "Seth", "Choudhary", "Ayer", "Raman", "Gowda", "Apte", "Sahay", "Sharma", "Kumar" };

            
            foreach (var book in books)
            {
                
                var reviewCount = rnd.Next(1, 16);
                for(int i = 0; i < reviewCount; i++)
                {
                    var review = new Review
                    {
                        //Book = book,
                        Rating = rnd.Next(1, 6)
                    };

                    review.ReviewTitle = reviews[review.Rating].GetRandom();

                    review.ReviewDetails = "";
                    var detailsFragment = rnd.Next(1, 4);
                    for(int x=0; x<detailsFragment; x++)
                    {
                        review.ReviewDetails += reviews[review.Rating].GetRandom();
                    }

                    review.ReviewerName =$"{fNames.GetRandom()} {lNames.GetRandom()}";
                    book.Reviews.Add(review);
                    
                }
            }

            await bookService.Save();
        
        }
    
    
    }

  
}
