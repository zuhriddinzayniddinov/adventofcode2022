string path = "input.txt";
string[] temp = File.ReadAllLines(path);
int count = 0;
int sum = 1;
int sum2 = 0;
string[,] str = new string[6, 40];
List<string> temp3 = new List<string>();
for (int i = 0; i < temp.Length; i++)
{
  string[] temp1 = temp[i].Split(" ");
  if (temp1[0] == "addx")
  {
      count++;
      if (Math.Abs(sum - ((count - 1) % 40)) <= 1)
        str[(count - 1) / 40, (count - 1) % 40] = "#";
      else
        str[(count - 1) / 40, (count - 1) % 40] = " ";

      if ((count - 20) % 40 == 0)
      {
        sum2 += count * sum;
      }
      count++;
      if (Math.Abs(sum - ((count - 1) % 40)) <= 1)
        str[(count - 1) / 40, (count - 1) % 40] = "#";
      else
        str[(count - 1) / 40, (count - 1) % 40] = " ";
      if (((count - 20) % 40) % 40 == 0)
      {
        sum2 += count * sum;
      }
      sum += int.Parse(temp1[1]);
  }
  else
  {
    count++;
    if (Math.Abs(sum - ((count - 1) % 40)) <= 1)
      str[(count - 1) / 40, (count - 1) % 40] = "#";
    else
      str[(count - 1) / 40, (count - 1) % 40] = " ";
    if ((count - 20) % 40 == 0)
    {
      sum2 += count * sum;
    }
  }
}
System.Console.WriteLine("birinchisi: "+sum2);
System.Console.WriteLine("ikkinchisi: ");
for (int i = 0; i < str.GetLength(0); i++)
{
  for (int j = 0; j < str.GetLength(1); j++)
  {
    System.Console.Write(str[i, j]);
  }
  System.Console.WriteLine();
}