using Embala;
using OpenAI_API.Moderation;
using System;

bool isRunning = true;
while (isRunning)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Enter your sentence : ");
    Sentence sentence = new Sentence(Console.ReadLine());


    if (sentence.Content == "")
    {
        Console.WriteLine("Please enter something");
        continue;
    }

    string sufix = "";

    if (sentence.Content.Length > 4)
    {
        sufix = sentence.Content.Substring(sentence.Content.Length - 4);
    } else
    {
        sufix = sentence.Content;
    }


    while (!Constant.Prefixes.Contains(sufix)) {
        Console.Write("Enter an option (--c to correct || --t to translate) : ");
        sufix = Console.ReadLine();
    }

    string result = "";
    Task<string> task = null;

    switch (sufix)
    {
        case " --c":
        case "--c":
            task = sentence.Correct();

            Task correctContinuation = task.ContinueWith((Task<string> task) =>
            {
                result = task.Result;
            });

            correctContinuation.Wait();
            Console.WriteLine(result);
            break;
        case " --t":
        case "--t":
            task = sentence.Translate();

            Task translateContinuation = task.ContinueWith((Task<string> task) =>
            {
                result = task.Result;
            });

            translateContinuation.Wait();
            Console.WriteLine(result);
            break;
        case " --n":
        case "--n":
            Node.createNodeProject(sentence.Content);
            break;

    }
}
