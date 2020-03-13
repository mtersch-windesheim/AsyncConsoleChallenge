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
            MaakOntbijt().Wait();
            Console.WriteLine($"{DateTime.Now.Second} Ontbijt is klaar!");
        }
        static async Task MaakOntbijt()
        {
            string koffieMelding = SchenkKoffieIn();
            Console.WriteLine(koffieMelding);
            string eitjesMelding = KookEitjesAsync().Result;
            Console.WriteLine(eitjesMelding);
            string broodMelding = RoosterBroodAsync().Result;
            Console.WriteLine(broodMelding);
        }
        static string SchenkKoffieIn() {
            Thread.Sleep(500);
            return "Koffie is klaar";
        }
        static async Task<string> KookEitjesAsync() {
            await Task.Delay(3000);
            return "Eitjes zijn klaar";
        }
        static async Task<string> RoosterBroodAsync()
        {
            await Task.Delay(3000);
            return "Brood is klaar";
        }
    }
}
