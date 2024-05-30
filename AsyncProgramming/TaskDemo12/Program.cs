// See https://aka.ms/new-console-template for more information


using TaskDemo11;

var film = new Film() { TotalFrames = 5};

var producer = new AnimationBuilder(film);

var presenter = new AnimationPresenter(film);

var t1 = producer.Build();
var t2 = presenter.Present();


Console.WriteLine("Film Has Started.");

Task.WaitAll(t1, t2);

Console.WriteLine("Film Ended");