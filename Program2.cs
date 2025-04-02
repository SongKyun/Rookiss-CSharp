// 디버깅 기초
/*using System;

namespace Rookiss_CSharp;

public class Program2
{
    static void Print(int value)
    {
        Console.WriteLine(value);
    }
    
    static int AddAndPrint(int a, int b)
    {
        int ret = a + b;
        Print(ret);
        return ret;
    }
    
    static void Main(string[] args)
    {
        Program2.AddAndPrint(5, 20);
        Program2.AddAndPrint(6, 20);
        Program2.AddAndPrint(7, 20);
        Program2.AddAndPrint(10, 20);
    }
}*/

// TextRPG
using System;
using System.Diagnostics;
using System.Xml.Schema;

namespace Rookiss_CSharp
{
    class Program2
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        struct Player
        {
            public int hp;
            public int attack;
        }

        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3,
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }
        
        // 함수화
        static ClassType ChooseClass()
        {
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");
            
            ClassType choice = ClassType.None;

            string input = Console.ReadLine();
            //if (input == "1" || input == "2" || input == "3")
            //    break;

            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    break;
                case "2":
                    choice = ClassType.Archer;
                    break;
                case "3":
                    choice = ClassType.Mage;
                    break;
            }

            return choice; // 함수 형식도 ClassType로 변경 해줘야 반환값이 제대로 됨
        }

        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(1,4);
            switch (randMonster)
            { // 정수형인데 enum 타입 이여서 int로 형변환
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임 스폰");
                    monster.hp = 20;
                    monster.attack = 2;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine("오크 스폰");
                    monster.hp = 40;
                    monster.attack = 4;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤 스폰");
                    monster.hp = 30;
                    monster.attack = 3;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
            // 랜덤으로 1~3 몬스터 중 하나를 리스폰
        }

        static void Fight(ref Player player, ref Monster monster) // 원본값을 받아와야 하는데 복사본을 사용 중이다 그래서 ref로 받아옴
        {
            while (true)
            {
                // 플레이어가 몬스터 공격
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리");
                    Console.WriteLine($"남은 체력 : {player.hp}");
                    break;
                }
                
                // 몬스터 반격
                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    Console.WriteLine("패배");
                    break;
                }
            }
        }
        
        static void EnterField(ref Player player) // player 전달 받음
        {
            while (true)
            {
                Console.WriteLine("필드에 접속했습니다!");

                // 몬스터 생성
                Monster monster;
                CreateRandomMonster(out monster);
                // 랜덤으로 1~3 몬스터 중 하나를 리스폰

                // [1]전투 모드로 돌입
                Console.WriteLine("[1]전투 모드 돌입");
                // [2]일정 확률로 마을로 도망
                Console.WriteLine("[2]일정 확률로 마을 도망");
                
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Fight(ref player, ref monster); // player 정보를 최종적으로 전달
                }
                else if (input == "2")
                {
                    Random rand = new Random();
                    int randValue = rand.Next(0, 101);
                    if (randValue <= 33)
                    {
                        Console.WriteLine("도망 성공");
                        break;
                    }
                    else
                    {
                        Fight(ref player, ref monster);
                    }
                }
            }
        }
        
        static void EnterGame(ref Player player) // player 정보를 받아줌
        {
            while (true)
            {
                Console.WriteLine("마을에 접속했습니다");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 로비로 돌아가기");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        EnterField(ref player); // player 전달
                        break; // switch 문의 break는 
                    case "2":
                        return;
                }

                /*if (input == "1")
                {
                    // EnterField();
                }
                else if (input == "2")
                {
                    break;
                }*/ // if문과는 관련이 없기에 break로 상위에 있는 while문을 나가게 됩니다
            }
        }
        
        static void Main(string[] args)
        {
            // 함수에서 choice를 알 수 없기에 반환타입으로 넘긴다
            //ClassType choice = ClassType.None;
            
            // while(choice != ClassType.None)
            while (true) // 조건식 true 무한 루프 - break 문 필요
            {
                //ChooseClass(); // static에서 호출을 위해 static 타입으로 선언해줘야함
                ClassType choice = ChooseClass(); // 안에서 선언해줘도 된다

                if (choice != ClassType.None)
                {
                    // 캐릭터 생성 Player는 C#에서 제공되는 타입
                    Player player;
                    CreatePlayer(choice, out player);
                    EnterGame(ref player); // player 정보를 넘겨줌
                    Console.WriteLine($"HP{player.hp} Attack{player.attack}");
                }
            }
        }
    }
}