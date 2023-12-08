class Program
{
    public static void Main()
    {
        //a mestint jegyzetben szereplő keretrsz. úgy lett megírva, h mélységi klónozást igényel
        //elmélet: 2 fajta klónozásról beszélünk
        //mélységi klónozás (deep-copy)
        //sekély klónozás (shallow-copy)
        //sekély klónozást MemberWiseClone() metódus segítségével
        //szerencsére a mély és a sekély klónozás egybeesik, ha csak egyszerű típusokat használok a mezőkön
        //pl. minden mezőm int, double, ...string akkor nem kell felülírnom a klónozást
        //ha bármilyen saját osztályt használok mezőtípusként v bármilyen tömböt v bármilyen collection-t,
        //akkor már felül kell írni a klón metódust

    }

}

class Kutya : ICloneable //az ICloneable interface-ből jön a Clone() metódus
{
    string nev;
    int labakSzama;
    List<String> becenevek = new List<string>(); //emiatt felül kell írni

    //itt azért nem kell override, mert az IClonable-ből jön
    //otthoni projektben az AbsztraktÁllapotból jön, ezért felül kell írni
    public Object Clone()
    {
        //Klón minden tul-a ua. legyen mint a this verzió!
        Kutya myClone = new Kutya();
        // sekély klón 
        // myClone.nev = this.nev;
        // myClone.labakSzama = this.labakSzama;
        // myClone.becenevek = this.becenevek;
        // return myClone;
        //ez egy sekély klón - referenciát simán másolom
        //nekem mély klón kell - beceneveket for ciklusban másolom
        //a referencia mögött lévő értékeket másolom

        // mély klón,ahol a primitíveket ugyanúgy klónozom, azonban a listát for ciklussal töltöm fel és úgy klónozom! 
        myClone.nev = this.nev;
        myClone.labakSzama = this.labakSzama;
        myClone.becenevek = new List<string>(); //először helyet kell foglalni a memóriába -> ha nem teszem NullReferenceExceptiont dob! 
        //for ciklussal átmásolok mindent
        foreach (string becenev in becenevek)
        {
            myClone.becenevek.Add(becenev);

        }
        return myClone;
    }
}

class Kutya2 : ICloneable
{
    string nev;
    int labakSzama;
    string[] becenevek = new string[3];

    public Object Clone()
    {
        Kutya2 myClone = new Kutya2(); 
        myClone.nev = this.nev;
        myClone.labakSzama = this.labakSzama;
        // myClone.becenevek = new string[this.becenevek.Length]; // ugyanakkora méretűt, mint az eredeti tömb volt! 
        // for (int i = 0; i < becenevek.Length; i++)
        // {
           //  myClone.becenevek[i] = this.becenevek[i];
        // }

        myClone.becenevek = this.becenevek.Clone() as string[]; // for ciklus a biztosabb

        return myClone;
    }
}