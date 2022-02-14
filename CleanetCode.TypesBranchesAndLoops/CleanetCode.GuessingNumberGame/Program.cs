Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
Console.WriteLine("Как вас зовут?");
string? userName = Console.ReadLine();
int maxValue = 999;

Console.WriteLine(
    $"Привет {userName}. " +
    $"Я загадал тебе число от 0 до {maxValue}. " +
    $"Побробуй отгадать");

Random rnd = new Random();
int secretNumber = rnd.Next(maxValue);
bool isWin = false;
int counter = 0;


while (!isWin)
{
    int userNumber = -1;
    bool isIntNumber = false;
    do
    {
        Console.WriteLine($"Введи число от 0 до {maxValue}:");
        string? userInput = Console.ReadLine();
        isIntNumber = int.TryParse(userInput, out userNumber);
        counter++;

        if (!isIntNumber)
        {
            Console.WriteLine($"Вы ввели {userInput}. Нужно ввести число от 0 до {maxValue}.");
            continue;
        }
        else if (userNumber < 0 || userNumber > maxValue)
        {
            Console.WriteLine($"Вы вышли за предел допустимого значения ({userNumber})");
            continue;
        }
        else
        {
            if (userNumber > secretNumber)
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
                Console.WriteLine($"Поздравляю {userName}, вы победили! " +
                    $"Количество попыток: {counter}");
                break;
            }
        }

    } while (isIntNumber);
}

