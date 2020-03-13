using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncConsoleChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We gaan een ontbijtje maken!");
            string koffieMelding = SchenkKoffieIn();
            Console.WriteLine(koffieMelding);
            string eitjesMelding = KookEitjesAsync().Result;
            Console.WriteLine(eitjesMelding);
            string broodMelding = RoosterBroodAsync().Result;
            Console.WriteLine(broodMelding);
            Console.WriteLine("Ontbijt is klaar!");
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
