using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    public class Items
    {
        public int Id { get; }              // 메뉴 선택용 번호
        public string Name { get; }         // 아이템 이름
        public int ATKbonus { get; }        // 공격력 추가
        public int DEFbonus { get; }        // 방어력 추가
        public int Cost { get; }            // 골드 가격
        public string Description { get; }  // 아이템 설명
        public bool IsPurchased { get; set; }  // 구매 여부
        public bool IsEquipped { get; set; } = false; // 장착 여부

        public Items(int id, string name, int atk, int def, int cost, string desc)
        {
            Id = id;
            Name = name;
            ATKbonus = atk;
            DEFbonus = def;
            Cost = cost;
            Description = desc;
            IsPurchased = false;
            IsEquipped = false;
        }
    }
    internal class Item
    {
        public static class ItemDatabase
        {
            // 모든 아이템을 한곳에서 관리
            public static List<Items> Items { get; } = new List<Items>
            {
                new Items(1, "수련자 갑옷", 0, 5, 1000, "수련에 도움을 주는 갑옷입니다."),
                new Items(2, "무쇠갑옷",   0, 9, 2000, "무쇠로 만들어져 튼튼한 갑옷입니다."),
                new Items(3, "스파르타의 갑옷", 0, 15, 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다."),
                new Items(4, "낡은 검", 2, 0, 600, "쉽게 볼 수 있는 낡은 검 입니다."),
                new Items(5, "청동 도끼", 5, 0, 1500, "어디선가 사용됐던것 같은 도끼입니다."),
                new Items(6, "스파르타의 창", 7, 0, 5000, "스파르타의 전사들이 사용했다는 전설의 창입니다."),


            };
        }
    }
}
