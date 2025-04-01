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
                    break;
            }
        }
    }
}