using kalapacsvetes;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Versenyző> versenyzok = new List<Versenyző>();
        StreamReader sr = new StreamReader("Selejtezo2012.txt");
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
            versenyzok.Add(new Versenyző(sr.ReadLine()));
        }
        Console.WriteLine($"5. feladat: Versenyzők száma a selejtezőben: {versenyzok.Count} fő\n");

        int tovabbjutott = 0;
        foreach (var item in versenyzok)
        {
            if (item.D2 == "-" || item.D3 == "-")
            {
                tovabbjutott++;
            }
        }
        Console.WriteLine($"6. feladat: 78,00 méter feletti eredménnyel továbbjutott: {tovabbjutott} fő\n");
        double legnagyobb = 0;
        int legnagyobbindex = 0;
        for (int i = 0; i < versenyzok.Count; i++)
        {
            if (legnagyobb < versenyzok[i].Eredmeny)
            {
                legnagyobb = versenyzok[i].Eredmeny;
                legnagyobbindex = i;
            }
        }
        Console.WriteLine($"9. feladat: A selejtező nyertese: \n\tNév: {versenyzok[legnagyobbindex].Nev}\n\tCsoport: {versenyzok[legnagyobbindex].Csoport}\n\tNemzet: {versenyzok[legnagyobbindex].Nemzet}\n\tNemzet kód: {versenyzok[legnagyobbindex].Kod}\n\tSorozat: {versenyzok[legnagyobbindex].D1};{versenyzok[legnagyobbindex].D2};{versenyzok[legnagyobbindex].D3}\n\tEredmény: {versenyzok[legnagyobbindex].Eredmeny}");

        // ide kéne egy rendezés de nem tudom hogy kell
        StreamWriter sw = new StreamWriter("Dontos2012.txt");
        sw.WriteLine("Helyezés;Név;Csoport;NemzetÉsKód;D1;D2;D3");
        for (int i = 0;i < 12; i++)
        {
            sw.WriteLine($"{i + 1};{versenyzok[i].Nev};{versenyzok[i].Csoport};{versenyzok[i].Nemzet_kod};{versenyzok[i].D1};{versenyzok[i].D2};{versenyzok[i].D3}");
        }
        sw.Close();
    }
}