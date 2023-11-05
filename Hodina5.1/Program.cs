//Dictionary<string, List <string>> telefonniSeznam = new Dictionary<string, List<string>> (); ale dá se vytvořit kratší zápis
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

var telefonniSeznam = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
bool jeKonec = false;

while (!jeKonec)
{
    Console.WriteLine("1 - přidat osobu");
    Console.WriteLine("2 - smazat osobu");
    Console.WriteLine("3 - Vypsat osoby");
    Console.WriteLine("4 - Vyhledej podle čísla");
    Console.WriteLine("0 - Konec");

    int volba = Convert.ToInt32(Console.ReadLine());


    switch (volba)
    {
        case 0:
            jeKonec = true;
            break;
        case 1:
            {
                Console.WriteLine("Zadej jméno:");
                var jmeno = Console.ReadLine();
                if (!telefonniSeznam.ContainsKey(jmeno))
                {
                    Console.WriteLine("Zadej telefonní číslo:");
                    string cislo = Console.ReadLine();
                    telefonniSeznam.Add(jmeno, cislo);
                }
                else { Console.WriteLine("Toto jméno již v seznamu existuje."); }
                break;
            }
        case 2:
            //zde jsou složené závorky, aby byla proměnná uvnitř nich (jméno) pouze lokální, jinak tady být nemusí
            {
                Console.WriteLine("Zadej jméno:");
                string jmeno = Console.ReadLine();
                if (telefonniSeznam.Remove(jmeno))
                {
                    Console.WriteLine("Položka úspěšně smazána.");
                } else
                {
                    Console.WriteLine("Položka neexistuje.");
                }
                break;
            }
        case 3:
            foreach (KeyValuePair<string, string> kontakt in telefonniSeznam)
            {
                Console.WriteLine($"{kontakt.Key}\t{kontakt.Value}");
            }
            break;
        case 4:
            {
                Console.WriteLine("Zadej počátek hledaného čísla:");
                string pocatek = Console.ReadLine();
                var jmeno = telefonniSeznam.Where(x => x.Value.StartsWith(pocatek)).Select(z => z.Key).ToList();
                foreach (var jm in jmeno)
                {
                    Console.WriteLine(jm);
                }
            }
            break;
    }
}