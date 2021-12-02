
public class Part2
{
    public void Run(string[] data)
    {
        List<string> input = data.ToList();
        double aim = 0;
        double horizPos = 0;
        double depth = 0;

        foreach (var item in input)
        {
            string command = string.Empty;
            int value = 0;
            (command, value) = ( item.Split(' ')[0], int.Parse(item.Split(' ')[1]) );
            aim += command switch 
            {
                "up" => value * -1,
                "down" => value,
                _ => 0,
            };
            if ( command == "forward" )
            {
                horizPos += value;
                depth += aim * value;
            }
        }

        System.Console.WriteLine($"The product of horizontal position and depth is: {horizPos * depth}");
    }
}
