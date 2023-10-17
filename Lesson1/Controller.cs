namespace Lesson1
{
    public class Controller
    {
        public string[]? args;

        public Controller(string[]? args)
        {
            this.args = args;
        }

        public Controller(string str)
        {
            this.args = str.Split(' ');
        }

        private bool if3parts(string[] args)
        {
            return args.Length == 3;
        }

        private bool ifAveilable(string[] args)
        {
            string commands = "+-*/";

            if (!int.TryParse(args[0], out var firstN))
                return false;

            if (!commands.Contains(args[1]))
                return false;

            if (!int.TryParse(args[2], out var secondN))
                return false;

            return true;
        }

        private bool ifNotDevidebyZero(string[] args)
        {
            if (args[1] != "/")
                return true;
            else if (int.Parse(args[2]) != 0)
                return true;
            else
                return false;
        }

        public void Start()
        {
            string info = "Необходимо указать выражение вида: первое число + тип операции(+ - * /) + второе число, например: 3 - 2";

            if (if3parts(this.args))
            {
                if (ifAveilable(this.args))
                {
                    if (ifNotDevidebyZero(this.args))
                    {

                    }
                    else
                    {
                        Console.WriteLine("Нельзя делить на 0");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine(info);
                    return;
                }
            }
            else
            {
                Console.WriteLine(info);
                return;
            }

            int firstN = int.Parse(this.args[0]);
            int secondN = int.Parse(this.args[2]);

            switch (args[1])
            {
                case "+":
                    Console.WriteLine($"{firstN} + {secondN} = {firstN + secondN}");
                    break;
                case "-":
                    Console.WriteLine($"{firstN} - {secondN} = {firstN - secondN}");
                    break;
                case "*":
                    Console.WriteLine($"{firstN} * {secondN} = {firstN * secondN}");
                    break;
                case "/":
                    Console.WriteLine($"{firstN} / {secondN} = {firstN / secondN}");
                    break;
            }
        }
    }
}
