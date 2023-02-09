using Palvelu;

var a = new Asiakas();
var t = new Tuote();
a.Use(t);

a.Operaatio();

var u = new ToinenTuote();

a.Use(u);

a.Operaatio();