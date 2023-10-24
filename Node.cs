using System;
using System.Diagnostics;

namespace Embala
{
    abstract class Node
    {
        public static void createNodeProject(string projectName)
        {
            if (projectName == "--n")
            {
                Console.Write("Nom du projet : ");
                projectName = Console.ReadLine();
            } else
            {
                projectName = projectName.Substring(0, projectName.Length - 4);
            }

            string script = "npx create-react-app " + projectName;

            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = "powershell",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process process = new Process()
            {
                StartInfo = psi,
            };

            process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            process.ErrorDataReceived += (sender, e) => Console.WriteLine("Error: " + e.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.StandardInput.WriteLine("cd C:\\Users\\matth\\Documents\\Cours\\C#\\projet-embala\\embala\\embala\\projects");
            process.StandardInput.WriteLine(script);
            process.StandardInput.WriteLine("code " + projectName);
            process.StandardInput.WriteLine("exit");
                
            process.WaitForExit();
            process.Close();
        }
    }
}