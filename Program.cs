using System.Runtime.CompilerServices;

class Program
{

    public static void Main()
    {
        bool isRunning = true;
        Boklåda boklåda = new Boklåda();
        
        System.Console.WriteLine("************************");
        System.Console.WriteLine("Välkommen till boklådan.");
        System.Console.WriteLine("************************");

        while (isRunning)
        {
            System.Console.WriteLine("Gör ett val:");
            System.Console.WriteLine("1. Lägg till en bok");
            System.Console.WriteLine("2. Skriv ut informtion om samtliga böcker");
            System.Console.WriteLine("3. Avsluta programmet");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                System.Console.WriteLine("Ogiltigt val, försök igen!");
                continue;
            }

            switch (input)
            {
                case 1:
                System.Console.Write("Skriv in titel: ");
                string titel = Console.ReadLine();
                System.Console.Write("Skriv in författare: ");
                string författare = Console.ReadLine();
                System.Console.WriteLine("Skriv in antal sidor: ");
                int antalSidor = int.Parse(Console.ReadLine());

                Bok b = new Bok(titel, författare, antalSidor);
                boklåda.LäggTillBok(b);
                System.Console.WriteLine($"Boken {titel} skriven av {författare} har lagts till. Boken består av {antalSidor}");
                System.Console.WriteLine("Vill du lägga till ytterligare böcker? Y/N"); 
                string choice = Console.ReadLine();
                if(choice == "Y".ToLower())
                    {
                        continue; 
                    }
                    else
                    {
                        break;
                    } 
                case 2:
                {
                    boklåda.ListaBöcker();
                    break;
                } 

                case 3: 
                {
                    isRunning = false;
                    System.Console.WriteLine("Tack för idag!");

                    break;
                } 
                default:
                System.Console.WriteLine("Ogiltig inmatning. Försök igen!"); 
                break;         
                
            }
        }

    }
}

public class Bok
{
    public string Titel {get; set;}
    public string Författare {get; set;}
    public int AntalSidor {get; set;}

    public Bok (string titel, string författare, int antalSidor )
    {
        Titel = titel;
        Författare = författare;
        AntalSidor = antalSidor;
    }
    
      
    public void SkrivUtInfo()
    {
        System.Console.WriteLine($"Boken heter {Titel} och är skriven av {Författare}. Den innehåller {AntalSidor} antal sidor. Trevlig läsning!");
    }
}
public class Boklåda
{
    private List<Bok> böcker = new List<Bok>();
    
    public void LäggTillBok(Bok bok)
    {
        böcker.Add(bok);
    }

    public void ListaBöcker()
    {
        foreach(Bok bok in böcker)
        {
            bok.SkrivUtInfo();
        }
    }


}
