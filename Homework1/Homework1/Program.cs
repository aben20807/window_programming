using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool firstInput = true;
            int numOfStudents = 0;
            int[] number = new int[0];
            string[] name = new string[0];
            int[] scoreOfChinese = new int[0];
            int[] scoreOfEnglish = new int[0];
            int[] scoreOfMath = new int[0];
            while (true)
            {
                Console.WriteLine("1> 輸入 2>印出 3>排序(以國文成績排序) -1>離開:");
                int mode = int.Parse(Console.ReadLine());
                if (mode != 1 && mode != 2 && mode != 3 && mode != -1)
                {//command does not exist
                    Console.WriteLine("指令錯誤!");
                    continue;
                }
                else if (mode == -1)
                {//exit
                    break;
                }
                else if (mode == 1)
                {//input
                    if(firstInput == true)//check if first input
                    {
                        Console.WriteLine("\n\n請輸入班級人數: (僅第一次輸入需要使用)");
                        numOfStudents = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n");
                        //init
                        firstInput = false;
                        number = new int[numOfStudents];
                        name = new string[numOfStudents];
                        scoreOfChinese = new int[numOfStudents];
                        scoreOfEnglish = new int[numOfStudents];
                        scoreOfMath = new int[numOfStudents];
                        for(int i = 0; i < numOfStudents; i++)
                        {
                            number[i] = -1;
                            scoreOfChinese[i] = -1;
                            scoreOfEnglish[i] = -1;
                            scoreOfMath[i] = -1;
                        }
                    }
                    else
                    {
                        int currentNumber, storeIndex = 0;
                        Console.WriteLine("\n\n請輸入座號:");
                        currentNumber = int.Parse(Console.ReadLine());
                        if(currentNumber < 1 || currentNumber > numOfStudents)
                        {//check if input number out of range
                            Console.WriteLine("輸入座號錯誤");
                            continue;
                        }
                        for (int i = 0; i < numOfStudents; i++)
                        {//check if there have existed number want to input
                            if (currentNumber == number[i])
                            {
                                storeIndex = i;
                                break;
                            }
                            else if (number[i] == -1)
                            {
                                storeIndex = i;
                                number[i] = currentNumber;
                                break;
                            }
                        }
                        Console.WriteLine("請輸入姓名:");
                        name[storeIndex] = (Console.ReadLine());
                        Console.WriteLine("請輸入國文成績:");
                        scoreOfChinese[storeIndex] = int.Parse(Console.ReadLine());
                        Console.WriteLine("請輸入英文成績:");
                        scoreOfEnglish[storeIndex] = int.Parse(Console.ReadLine());
                        Console.WriteLine("請輸入數學成績:");
                        scoreOfMath[storeIndex] = int.Parse(Console.ReadLine());
                    }
                }
                else if(mode == 2)
                {
                    Console.WriteLine("\n\n座號\t國文\t英文\t數學\t姓名");
                    Console.WriteLine("=====================================");
                    for(int i = 0; i < numOfStudents; i++)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", number[i], scoreOfChinese[i], scoreOfEnglish[i], scoreOfMath[i], name[i]);
                    }
                }
                else if(mode == 3)
                {

                }
            }
        }
    }
}
