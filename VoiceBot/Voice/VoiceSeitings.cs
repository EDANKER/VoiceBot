using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using ConsoleApplication1.Parse;
using ConsoleApplication1.Voice.bazeWord;
using Parsnet.WorkerService;

namespace ConsoleApplication1.Voice
{
    public class VoiceSeitings
    {
        public async Task<int> VoiceAi()
        {
            string[] arrayWord = new[] { "Добрый день", "Привет", "Пламенный привет" };
            var reconizer = new SpeechRecognitionEngine(new CultureInfo("ru-ru"));

            var grammarBiuld = new GrammarBuilder
            {
                Culture = CultureInfo.CreateSpecificCulture("ru-ru")
            };
            var choices = new Choices();
            foreach (var word in arrayWord)
            {
                choices.Add(new string[] { word });
            }

            grammarBiuld.Append(choices);

            var grammar = new Grammar(grammarBiuld);
            reconizer.LoadGrammar(grammar);
            reconizer.SpeechRecognized += ReconizerOnRecognizeCompleted;
            reconizer.SpeechRecognitionRejected += ReconizerOnRecognizeCompleted;

            reconizer.SetInputToDefaultAudioDevice();
            reconizer.RecognizeAsync(RecognizeMode.Multiple);
            reconizer.MaxAlternates = 1;
            Console.ReadKey();
            return 0;
        }

        private static void ReconizerOnRecognizeCompleted(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Console.WriteLine("false");
        }

        private static void ReconizerOnRecognizeCompleted(object sender, SpeechRecognizedEventArgs e)
        {
            var wordName = "";

            Console.WriteLine(e.Result.Text);
            var wordHello = new WordHello();
            var htmlParse = new ParseHtml();
            Console.WriteLine(htmlParse.HtmlDom());
            foreach (var word in wordHello.HelloBase().Result)
            {
                if (word.Contains(e.Result.Text))
                {
                    wordName = word;
                }
            }
            if (e.Result.Text.Contains(wordName))
            {
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.Volume = 100;
                speechSynthesizer.Rate = 2;
                speechSynthesizer.Speak(wordName);
                Thread.Sleep(400);
                speechSynthesizer.Speak("что вы хотите узнать?");
            }
        }
    }
}