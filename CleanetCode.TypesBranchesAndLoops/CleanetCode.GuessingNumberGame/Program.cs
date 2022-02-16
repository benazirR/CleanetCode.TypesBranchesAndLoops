bool isWin = false;
bool isContinue = true;
int maxValue = 999;
Random randomNumberGenerator = new Random();
int secretNumber = randomNumberGenerator.Next(0, maxValue);
int attemptsCounter = 0;

Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
Console.WriteLine("Как вас зовут?");
string? userName = Console.ReadLine();
Console.WriteLine(
    $"Привет {userName}. " +
    $"Я загадал тебе число от 0 до {maxValue}. " +
    $"Побробуй отгадать");

while (!isWin)
{
    int userNumber = -1;
    bool isIntNumber = false;
    do
    {
        Console.WriteLine($"Введи число от 0 до {maxValue}:(для выхода наберите 'exit')");
        string? userInput = Console.ReadLine();
        isIntNumber = int.TryParse(userInput, out userNumber);

        if (userInput == "exit")
        {
            isContinue = false;
        }
        else if (!isIntNumber)
        {
            Console.WriteLine($"Вы ввели {userInput}. Нужно ввести число от 0 до {maxValue}.");
        }
        else if (userNumber < 0 || userNumber > maxValue)
        {
            Console.WriteLine($"Вы вышли за предел допустимого значения ({userNumber})");
        }
    } while (!isIntNumber && isContinue || userNumber < 0 || userNumber > maxValue);
    
    attemptsCounter++;

    if (!isContinue)
    {
        Console.WriteLine("Вы вышли из игры.");
        break;
    }
    else if (userNumber > secretNumber)
    {
        Console.WriteLine($"Ваше число ({userNumber}) больше, чем загаданное.");
    }
    else if (userNumber < secretNumber)
    {
        Console.WriteLine($"Ваше число ({userNumber}) меньше, чем загаданное.");
    }
    else
    {
        isWin = true;
        Console.WriteLine($"Поздравляю {userName}, вы победили!\n " +
            $"Количество попыток: {attemptsCounter}");
    }
}

