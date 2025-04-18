using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRpg.Item;

namespace TextRpg
{
    internal class Inventory
    {
        public Inventory()
        {
            ShowInventory();
        }
        public void ShowInventory()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");

            var ownedItems = ItemDatabase.Items
                 .Where(item => item.IsPurchased)
                 .ToList();

            for (int i = 0; i < ownedItems.Count; i++)
            {
                var item = ownedItems[i];
                var bonuses = new List<string>();
                if (item.ATKbonus > 0) bonuses.Add($"공격력 +{item.ATKbonus}");
                if (item.DEFbonus > 0) bonuses.Add($"방어력 +{item.DEFbonus}");
                var bonusText = bonuses.Count > 0
                    ? string.Join(" | ", bonuses)
                    : "보너스 없음";

                // [E] 표시: 장착 중이면 [E], 아니면 공백
                var equipMark = item.IsEquipped ? "[E] " : "";

                // 최종 출력
                Console.WriteLine(
                    $"- {equipMark}{item.Name} | {bonusText} | {item.Description}"
                );
            }

            Console.WriteLine("\n1. 장착 관리\n2. 나가기");

            int choice;
            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();


                if(!int.TryParse(input, out choice) || choice<1 || choice >2)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }
                break;
            }
            Console.Clear();
            if (choice == 1)
            {
                ManageEquip();
            }
            else
            {
                new GameStart();
            }
        }
        private void ManageEquip()
        {
            // 구매된 아이템만 뽑아옵니다.
            var ownedItems = ItemDatabase.Items
                               .Where(it => it.IsPurchased)
                               .ToList();
            while (true)
            {
                Console.Clear ();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("인벤토리 - 장착 관리\n");
                Console.ResetColor();
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");

                for (int i = 0; i < ownedItems.Count; i++)
                {
                    var item = ownedItems[i];
                    var bonuses = new List<string>();
                    if (item.ATKbonus > 0) bonuses.Add($"공격력 +{item.ATKbonus}");
                    if (item.DEFbonus > 0) bonuses.Add($"방어력 +{item.DEFbonus}");
                    var bonusText = bonuses.Count > 0
                        ? string.Join(" | ", bonuses)
                        : "보너스 없음";

                    // [E] 표시: 장착 중이면 [E], 아니면 공백
                    var equipMark = item.IsEquipped ? "[E]" : "";

                    Console.WriteLine(
                        $"{i + 1}. {equipMark}{item.Name} | {bonusText} | {item.Description}"
                    );
                }

                Console.WriteLine("\n0. 나가기\n");
                int sel;
                while (true) 
                {
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out sel) || sel < 0 || sel > ownedItems.Count)
                    {
                        Console.WriteLine("잘못된 입력입니다.\n");
                        continue;
                    }
                    break; 
                }
                // 0 입력 시 돌아가기
                if (sel == 0)
                {
                    Console.Clear();
                    ShowInventory();
                    return;
                }
                // 실제 아이템
                var chosen = ownedItems[sel - 1];
                if (!chosen.IsEquipped)
                {
                    // 장착
                    chosen.IsEquipped = true;
                    State.ATK += chosen.ATKbonus;
                    State.DEF += chosen.DEFbonus;
                }
                else
                {
                    // 해제
                    chosen.IsEquipped = false;
                    State.ATK -= chosen.ATKbonus;
                    State.DEF -= chosen.DEFbonus;
                }
  

            }
    

        }

    }
}
