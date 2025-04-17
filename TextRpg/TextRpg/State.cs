using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    internal class State
    {
        public static int Lv { get; set; } = 1;
        public static string Name { get; set; } = "Chad";
        public static string Job { get; set; } = "(전사)";
        public static int ATK { get; set; } = 10;
        public static int DEF { get; set; } = 5;
        public static int HP { get; set; } = 100;
        public static int Gold { get; set; } = 1500;

        public  State() 
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("상태보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            Console.Write($"Lv. {Lv}\n" 
                + $"{Name} {Job}\n"
                + $"공격력 : {ATK}\n" 
                + $"방어력 : {DEF}\n" 
                + $"체력 : {HP}\n" 
                + $"Gold : {Gold} G\n\n" 
                + "0. 나가기\n");

           
            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();
                int choice;

                if (!int.TryParse(input, out choice) || choice != 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }
                break;
            }
            Console.Clear();
            new GameStart();

        }

    }
}
