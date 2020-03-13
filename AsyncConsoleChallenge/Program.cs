using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncConsoleChallenge
{
    class Program
    {
        private static Stopwatch watch;
        static void Main(string[] args)
        {
            watch = new Stopwatch();
            watch.Start();

            TimedWrite("We gaan ontbijten met een krantje!");
            OchtendRoutineAsync().Wait();
            TimedWrite("Zo... klaar voor de dag!");

            watch.Stop();
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
            TimedWrite("Begonnen ontbijt te maken");
            // Synchroon koffiezetten -> bij aanroep direct (500msec) resultaat
            string koffieMelding = SchenkKoffieIn();
            TimedWrite(koffieMelding);

            // Asynchroon eitjes koken en brood roosteren: hier beginnen we beide taken...
            Task<string> eitjesTaak = KookEitjesAsync();
            TimedWrite("Eitjes staan op het vuur");
            Task<string> broodTaak = RoosterBroodAsync();
            TimedWrite("Brood zit in het rooster");

            // ... en hier wachten we op het resultaat.
            // NB: op dit punt aangekomen kunnen we tussendoor ook andere dingen doen!
            string eitjesMelding = await eitjesTaak;
            string broodMelding = await broodTaak;

            // NB: Kijk ook eens wat er gebeurt als je volgende code gebruikt:
            // string eitjesMelding = await KookEitjesAsync();
            // string broodMelding = await RoosterBroodAsync();

            TimedWrite(eitjesMelding);
            TimedWrite(broodMelding);

            TimedWrite("Ontbijt is klaar");
        }
        static string SchenkKoffieIn()
        {
            Thread.Sleep(500);
            return "2 kopjes koffie";
        }
        static async Task<string> KookEitjesAsync()
        {
            await Task.Delay(3000);
            return "2 gekookte eitjes";
        }
        static async Task<string> RoosterBroodAsync()
        {
            await Task.Delay(3000);
            return "2 geroosterde broodjes";
        }
        static async Task PakKrantAsync()
        {
            TimedWrite("Naar de brievenbus voor de krant...");
            await Task.Delay(1500);
            TimedWrite("Krant gepakt");
        }
        static void TimedWrite(string message)
        {
            Console.WriteLine($"{watch.ElapsedMilliseconds.ToString()} - {message}");
        }
    }
}
