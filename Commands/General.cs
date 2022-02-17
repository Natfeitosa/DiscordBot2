using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Discord.Addons.Interactive;

//This is the Class that handles all the Commands the bot will do
namespace Discord_bot.Commands
{
    public class General : ModuleBase
    {
        //private const string FilePath = "C:\\Users\\Natanael Feitosa\\source\\repos\\Discord_bot\\bin\\Debug\\Anki_cards.txt";

        [Command("say")]
        public async Task Say()
        {
            await Context.Channel.SendMessageAsync("hello");
            //return;
        }

        [Command("jisho")]
        public async Task Jisho(string word) //Since this has no Remainder it will only take one word after !jisho
        {
            string link = "https://jisho.org/search/";
            Context.Channel.SendMessageAsync(link + word);

        }
        [Command("jisho_word")]//This sets the command in which the bot is looking for
        public async Task Jisho_word(string word)
        {
            string link = "https://jisho.org/word/";
            Context.Channel.SendMessageAsync(link + word);
        }
        [Command("anki")]
        public async Task Anki_Card([Remainder] string word)// Remainder is there so discord bot can accept sentences
        {
            // The Parcer class is something created with a function that parses the sentence and adds it to the format of ANKI
            // Accepted Format is "[KANJI] [FURIGANA] [TRANSLATION] there can be no spaces in TRANSLATION. to look should be to_look
            string words = Parcer.Word_Seperator(word);
            Console.WriteLine("Adding the words to the text file\n");
            Console.WriteLine(words);
            //Opens the txt file that is going to append to
            using StreamWriter streamWriter = new("Anki_cards.txt", append: true); //If the text file doesnt exist, it creates it


            await streamWriter.WriteLineAsync(words);           //This adds the string to the  text file



            // The following works pased on the path of working directory
            //string path = Directory.GetCurrentDirectory();
            // path = path + "\\Anki_cards.txt";
            //Context.Channel.SendMessageAsync(path);
            //Sends the txt file to the Channel
            //await Context.Channel.SendFileAsync(path);
            //await Context.Channel.SendFileAsync("C:\\Users\\'Natanael Feitosa'\\source\\repos\\Discord_bot\\bin\\Debug\\Anki_cards.txt");

        }
    }
}