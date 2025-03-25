namespace Rookiss_CSharp;

class Program
{
    static void Main(string[] args)
    {
        // int 정수형
        // float 실수형
        // string 문자열
        // bool 불리언
        
        // [데이터 타입] [이름];
        //int hp;
        
        // [이름] = ?
        //hp = 100;

        int hp = 100;
        int maxHp;
        
        // int hp = 100; 한번에

        maxHp = hp;
        
        Console.WriteLine(hp);
        
        // [100]
        // 완전히 정확하게 표현하지 않는 타입
        // 메모리 공간은 유한하기 때문에 이 모든 무한대의 데이터를 다 표현할 수 없다.
        // 그래서 어느 정도 근삿값으로 컴퓨터가 데이터를 표현한다.
        // 많은 숫자가 들어갈 수록 데이터가 정확히 저장이 될 수 없다는 걸 염두해야 한다!
        //float a;

        //a = 3.51234f; // 끝에 f를 붙여야 한다.

        string name;
        
        name = "Rookiss";
        
        Console.WriteLine(name);

        // 하나의 문자만 char C# 에선 2바이트로 영어,프랑스 등을 담기 가능하다.
        //char ch;
        //ch = 'a';
        
        // soundOnOff = true/false
        //bool b;

        //b = true;
        //b = false;
        
        // 캐스팅
        // [        ] 큰
        int a = 100;
        // [  ] 작은
        short b = (short)a;
        
        // 실수 -> 인트 100->100.0f
        float c = a;
        // 50.5f->50
        int d = (int)c; // 캐스팅 처리를 요구한다.
    }
}