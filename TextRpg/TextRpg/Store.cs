using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRpg.Item;

namespace TextRpg
{
    internal class Store
    {

        public Store()
        {
            ShowStore();
        }
        public void ShowStore() 
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("상점");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드] \n{0} G\n", State.Gold);

            Console.WriteLine("[아이템 목록]");
            foreach (var item in ItemDatabase.Items)
            {
                // 문자열 조립 공격력 , 방어력 둘 중에 하나만 표시하게
                var bonuses = new List<string>();
                if (item.ATKbonus > 0)
                    bonuses.Add($"공격력 +{item.ATKbonus}");
                if (item.DEFbonus > 0)
                    bonuses.Add($"방어력 +{item.DEFbonus}");
                string bonusText = bonuses.Count > 0
                    ? string.Join(" | ", bonuses) //
                    : "";

                //
                string priceOrStatus = item.IsPurchased ? "구매완료" : $"{item.Cost} G";

                Console.WriteLine(
                    $"- {item.Name} | {bonusText} | {item.Description} | {priceOrStatus}"
                );
            }


            Console.WriteLine("\n1. 아이템 구매\n0. 나가기");
            int choice;
            while(true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                if(!int.TryParse(input, out choice) || choice<0 || choice >1)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }
                break;
            }
            
            if(choice == 0)
            {
                Console.Clear();
                new GameStart();
            }
            else//아이템 구매
            {
                ShowItemIdStore();
                BuyItem();
            }
        }
        private void ShowItemIdStore() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("상점 - 아이템 구매");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드] \n{0} G\n", State.Gold);

            foreach (var item in ItemDatabase.Items)
            {
                var bonuses = new List<string>();
                if (item.ATKbonus > 0) bonuses.Add($"공격력 +{item.ATKbonus}");
                if (item.DEFbonus > 0) bonuses.Add($"방어력 +{item.DEFbonus}");
                var bonusText = bonuses.Count > 0
                    ? string.Join(" | ", bonuses)
                    : "";

                var priceOrStatus = item.IsPurchased ? "구매완료" : $"{item.Cost} G";

                // 여기서는 ID 를 포함
                Console.WriteLine(
                    $"- {item.Id}. {item.Name} | {bonusText} | {item.Description} | {priceOrStatus}"
                );
            }
        }
        private void BuyItem()
        {
            while(true)
            {
                Console.Write("\n구매할 아이템 번호를 입력하세요.\n>> ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int itemId))
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;   // 루프 맨 앞으로 돌아가서 재입력
                }
                // 0 입력 시 상점으로 복귀
                if (itemId == 0)
                {
                    Console.Clear();
                    ShowStore();
                    return;
                }
                var item = ItemDatabase.Items.FirstOrDefault(i => i.Id == itemId);
                if (item == null)
                {
                    Console.WriteLine("잘못된 입력입니다.");//없는 아이템 번호
                    continue;
                }
                else if (item.IsPurchased)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    continue;
                }
                else if (State.Gold < item.Cost)
                {
                    Console.WriteLine("골드가 부족합니다.");
                    continue;
                }
                else
                {
                    State.Gold -= item.Cost; //골드 차감
                    item.IsPurchased = true;

                    Console.Clear();
                    Console.WriteLine($"{item.Name}을(를) 구매 완료했습니다.\n");
                    // 다시 상점으로
                    ShowStore();
                    break;
                }
            }



        }
    }
}
