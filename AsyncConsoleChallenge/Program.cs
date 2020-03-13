using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncConsoleChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now.Second} We gaan een ontbijtje maken!");
            OchtendRoutineAsync().Wait();
            Console.WriteLine($"{DateTime.Now.Second} Ontbijt is klaar!");
        }
        static async Task OchtendRoutineAsync()
        {
            Task ontbijt = MaakOntbijtAsync();
            Task krant = PakKrantAsync();
            await ontbijt;
            await krant;
        }
        static async Task MaakOntbijtAsync()
        {
            // Synchroon koffiezetten -> bij aanroep direct (500msec) resultaat
            string koffieMelding = SchenkKoffieIn();

            // Asynchroon eitjes koken en brood roosteren: hier beginnen we beide taken...
            Task<string> eitjesTaak = KookEitjesAsync();
            Console.WriteLine("Eitjes staan op het vuur");
            Task<string> broodTaak = RoosterBroodAsync();
            Console.WriteLine("Brood zit in het rooster");

            // ... en hier wachten we op het resultaat.
            // NB: op dit punt aangekomen kunnen we tussendoor ook andere dingen doen!
            string eitjesMelding = await eitjesTaak;
            string broodMelding = await broodTaak;

            // NB: Kijk ook eens wat er gebeurt als je volgende code gebruikt:
            // string eitjesMelding = await KookEitjesAsync();
            // string broodMelding = await RoosterBroodAsync();

            Console.WriteLine(koffieMelding);
            Console.WriteLine(eitjesMelding);
            Console.WriteLine(broodMelding);

        }
        static string SchenkKoffieIn()
        {
            Thread.Sleep(500);
            return "Koffie is klaar";
        }
        static async Task<string> KookEitjesAsync()
        {
            await Task.Delay(3000);
            return "Eitjes zijn klaar";
        }
        static async Task<string> RoosterBroodAsync()
        {
            await Task.Delay(3000);
            return "Brood is klaar";
        }
        static async Task PakKrantAsync()
        {
            await Task.Delay(1500);
            Console.WriteLine("Krant gepakt");
        }
    }
}
