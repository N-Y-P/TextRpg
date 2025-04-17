using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    internal class GameStart
    {
        public GameStart()
        {

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            var gameMenu = new List<(int number, string name)>
            {
                (1, "상태보기"),
                (2, "인벤토리"),
                (3, "상점"),
            };

            foreach (var item in gameMenu)
            {
                Console.WriteLine($"{item.number}. {item.name}");
            }

            int gameSelectedNumber;
            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string gameStartInput = Console.ReadLine();

                // 입력값이 숫자인지 확인 (숫자가 아니라면 바로 오류 메시지 출력)
                if (!int.TryParse(gameStartInput, out gameSelectedNumber))
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }
                // 입력한 숫자가 메뉴 항목에 있는지 검사
                bool menuCheck = gameMenu.Any(item => item.number == gameSelectedNumber);
                if (!menuCheck)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }

                break;
            }
            Console.Clear();
            Console.WriteLine($"\n{gameSelectedNumber}번을 선택하셨습니다.\n");

            switch (gameSelectedNumber)
            {
                case 1:
                    new State();
                    break;
                case 2:
                    new Inventory();
                    break;
                case 3:
                    new Store();
                    break;
            }

        }
    }
}