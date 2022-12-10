string path = "input.txt";
string[] temp = File.ReadAllLines(path);
ListNode tempL2 =
                new ListNode(new int[]{0,0},
                new ListNode(new int[]{0,0},
                new ListNode(new int[]{0,0},
                new ListNode(new int[]{0,0},
                new ListNode(new int[]{0,0},
                new ListNode(new int[]{0,0},
                new ListNode(new int[]{0,0},
                new ListNode(new int[]{0,0},
                new ListNode(new int[]{0,0},
                new ListNode(new int[]{0,0}
                                ))))))))));
for (int i = 0; i < temp.Length; i++)
{
    string[] temp1 = temp[i].Split(" ");
    int k = int.Parse(temp1[1]);
    for (int l = 0; l < k; l++)
    {
        Swap(tempL2,temp1[0]);
    }
}
System.Console.WriteLine("1 - shartniki: " + tempL2.DicValue.Count);
System.Console.WriteLine("2 - shartniki: " + tempL2.Next.Next.Next.Next.Next.Next.Next.Next.DicValue.Count);
static void Swap(ListNode temp, string A = null)
{
    if(temp == null||temp.Next == null)
    return;
            if(A != null)
            switch(A)
            {
                case "R":
                    temp.Value[1]++;
                    break;
                case "L":
                    temp.Value[1]--;
                    break;
                case "U":
                    temp.Value[0]++;
                    break;
                case "D":
                    temp.Value[0]--;
                    break;
            }
            if(Math.Abs(Math.Max(temp.Value[0],temp.Next.Value[0])-Math.Min(temp.Value[0],temp.Next.Value[0]))>1 || 
                     Math.Abs(Math.Max(temp.Value[1],temp.Next.Value[1])-Math.Min(temp.Value[1],temp.Next.Value[1]))>1)
            {
                temp.Next.Value = SwapSnake(temp.Value,temp.Next.Value);
                string str = temp.Next.Value[0].ToString()+":"+temp.Next.Value[1].ToString();
                if(!temp.DicValue.ContainsKey(str))
                temp.DicValue.Add(str,1);
                else
                temp.DicValue[str]++;
            }
            Swap(temp.Next);
}
static int[] SwapSnake(int[] temp,int[] temp2)
{
    if(temp[0]==temp2[0])
    {
        temp2[1] = temp[1]>=temp2[1]?temp2[1] + 1:temp2[1]-1;
    }
    else if(temp[1]==temp2[1])
    {
        temp2[0] = temp[0]>=temp2[0]?temp2[0] + 1:temp2[0]-1;
    }
    else
    {
        temp2[1] = temp[1]>=temp2[1]?temp2[1] + 1:temp2[1]-1;
        temp2[0] = temp[0]>=temp2[0]?temp2[0] + 1:temp2[0]-1;     
    }
    return temp2;
}
class ListNode
{
  public ListNode(int[] value,ListNode next = null)
  {
    this.Next = next;
    this.Value = value;
    DicValue.Add(value[0].ToString()+":"+value[1].ToString(),1);
  }
    public ListNode Next{get;set;}
    public int[] Value{get;set;}
    public Dictionary<string,int> DicValue = new Dictionary<string, int>();
}