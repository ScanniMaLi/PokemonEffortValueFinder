using System.Diagnostics;

const string exePath = "./_Data/PokemonEffortValueFinder.exe";
Process process = new Process();
process.StartInfo.FileName = exePath;
process.StartInfo.UseShellExecute = false;
process.StartInfo.Arguments = "run";
process.Start();