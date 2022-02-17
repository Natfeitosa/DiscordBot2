using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_bot.Commands
{
    class Parcer
    {
        public static string Word_Seperator(string word)
        {
            if (word.Contains("\n"))
            {
                string[] words = word.Split('\n');
                string final="";
                for(int i =0;i<words.Length; i++) 
                {
                    final = final + words[i].Replace('　', ';') + "\n";
                }
                
                return final;
            }
            else
            {
                return (word.Replace('　', ';'));
            }
            
            
        }
    }
}