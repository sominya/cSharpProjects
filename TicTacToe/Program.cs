using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {


            String[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool playerWon = false;
            String nextPlayer = "Player1";
            String nextPlayerSign = "X";
            while (true)
            {

                bool goodResponse = false;
                while (!goodResponse)
                {
                    Console.Clear();
                    renderBoard(numbers);

                    Console.WriteLine(nextPlayer + ", choose your field! ");
                    String playerResponse = Console.ReadLine();

                    goodResponse = checkResponse(playerResponse, numbers);
                    if (goodResponse)
                    {
                        numbers[int.Parse(playerResponse) - 1] = nextPlayerSign;
                        playerWon = checkWin(nextPlayerSign, numbers);
                        if (playerWon)
                        {


                            Console.Clear();
                            renderBoard(numbers);
                            Console.WriteLine(nextPlayer + " has won , press any key to reset the game or X to exit");
                            String response = Console.ReadLine();
                            if (response != "X")
                            {
                                nextPlayer = "Player2";
                                nextPlayerSign = "O";
                                numbers = resetNumbers(numbers);
                                renderBoard(numbers);
                            }
                            else
                            {
                                Console.WriteLine("This gaming app is now closing..");
                                System.Threading.Thread.Sleep(5000);

                                Environment.Exit(0);
                            }

                        }


                        if (nextPlayer == "Player1")
                        {
                            nextPlayer = "Player2";
                        }
                        else
                        {
                            nextPlayer = "Player1";
                        }

                        if (nextPlayerSign == "X")
                        {
                            nextPlayerSign = "O";
                        }
                        else
                        {
                            nextPlayerSign = "X";
                        }


                    }
                    else
                    {
                        Console.WriteLine("Please choose a valid number between 1 to 9");
                    }
                }


            }




        }

        public static string[] resetNumbers(String[] numbers)
        {
            for (int i = 0; i <= 8; i++)
            {
                String value = (i + 1).ToString();
                numbers[i] = value;
            }
            return numbers;
        }

        public static bool checkWin(String playerSign, String[] numbers)
        {
            if ((numbers[0] == playerSign && numbers[1] == playerSign && numbers[2] == playerSign)
                 ||
               (numbers[3] == playerSign && numbers[4] == playerSign && numbers[5] == playerSign)
                  ||
               (numbers[6] == playerSign && numbers[7] == playerSign && numbers[8] == playerSign)
                  ||
               (numbers[2] == playerSign && numbers[5] == playerSign && numbers[8] == playerSign)
                  ||
               (numbers[1] == playerSign && numbers[4] == playerSign && numbers[7] == playerSign)
                  ||
               (numbers[0] == playerSign && numbers[3] == playerSign && numbers[6] == playerSign)
                  ||
               (numbers[0] == playerSign && numbers[4] == playerSign && numbers[8] == playerSign)
                  ||
               (numbers[2] == playerSign && numbers[4] == playerSign && numbers[6] == playerSign)
               )
            {


                return true;
            }
            else
            {
                //keep playing
                return false;
            }



        }

        public static bool checkResponse(String response, string[] previousSet)
        {
            bool responseIsInt = int.TryParse(response, out int parsedValue);
            if (responseIsInt)
            {
                if (parsedValue > 9 || parsedValue < 1)
                {
                    Console.WriteLine("Please enter a number between 1 and 9");
                    return false;
                }
                else
                {

                    //check the number chosen if it is already filled by the X or O
                    if (previousSet[parsedValue - 1] == "X" || previousSet[parsedValue - 1] == "O")
                    {
                        Console.WriteLine("This number is already used , please choose a different number");
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
            }
            else
            {
                Console.WriteLine("Please choose a valid number between 1 to 9");
                return false;
            }

        }

        public static void renderBoard(String[] currentSet)
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  " + currentSet[0] + "  |  " + currentSet[1] + "  |  " + currentSet[2] + "  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  " + currentSet[3] + "  |  " + currentSet[4] + "  |  " + currentSet[5] + "  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  " + currentSet[6] + "  |  " + currentSet[7] + "  |  " + currentSet[8] + "  ");
            Console.WriteLine("     |     |     ");

        }
    }
}
