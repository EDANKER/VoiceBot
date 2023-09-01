using System;
using ConsoleApplication1.Voice;
using HtmlAgilityPack;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var voice = new VoiceSeitings();
            Console.WriteLine(voice.VoiceAi());
        }
    }
}