// Menu variables
bool valid = false;
string? readResult;
string menuChoice = "";

// Game variables
Random random = new Random();
int lives = 3;
int answer = 0;
int playerAnswer = 0;
int int1;
int int2;
int score = 0;

Console.WriteLine("Welcome to the math game\n");

while (lives > 0) {
    Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. See highscore\n");

    do {
        Console.WriteLine("Choose an option by typing its number");
        readResult = Console.ReadLine();
        if (String.IsNullOrEmpty(readResult) == false) {
            if (readResult == "1" || readResult == "2" || readResult == "3" || readResult == "4" || readResult == "5" ) {
                menuChoice = readResult;
                valid = true;

            }
        }
    } while(valid == false);
    
    if (menuChoice == "5") {
        StreamReader reader = new StreamReader("highScore.txt");
        string? line = reader.ReadLine();
        while (line != null) {
            Console.WriteLine($"Your current highscore is {line}!");
            line = reader.ReadLine();
        }
        reader.Close();
        Console.WriteLine("Press enter to return to the menu");
        Console.ReadLine();
    }
    
    if (menuChoice == "4") {
        int modResult;
        do {
            int1 = random.Next(1, 101);
            int2 = random.Next(1, 101);
            modResult = int1 % int2;
        } while(modResult != 0);
    }
    else {
        int1 = random.Next(1, 101);
        int2 = random.Next(1, 101);
    }

    if (menuChoice != "5") {
    
        switch (menuChoice) {
            case "1":
                answer = int1 + int2;
                Console.WriteLine($"What is {int1} plus {int2}?");
                break;
            case "2":
                answer = int1 - int2;
                Console.WriteLine($"What is {int1} minus {int2}?");
                break;
            case "3":
                answer = int1 * int2;
                Console.WriteLine($"What is {int1} times {int2}?");
                break;
            case "4":
                answer = int1 / int2;
                Console.WriteLine($"What is {int1} divided ny {int2}?");
                break;
        }

        do {
            readResult = Console.ReadLine();
            if (readResult != null) {
                valid = int.TryParse(readResult, out playerAnswer);
                if (!valid) {
                    Console.WriteLine("Not a number");
                }
            }
        } while(valid == false);

        if (playerAnswer == answer) {
            score += 1;
            Console.WriteLine($"Correct answer!\nYour current score is {score}\n");
        }
        else {
            lives -= 1;
            Console.WriteLine($"Wrong answer\nYou have {lives} lives left\n");
        }   
    }
}
StreamWriter writer = new StreamWriter("highScore.txt");
writer.WriteLine(score);
writer.Close();
Console.WriteLine("You lose!");