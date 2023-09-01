using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApplication1.Voice.bazeWord
{
    public class WordHello
    {
        public async Task<List<string>> HelloBase()
        {
            var listWord = new List<string>{"Добрый день", "Привет", "Пламенный привет" };
            return listWord;
        }
    }
}