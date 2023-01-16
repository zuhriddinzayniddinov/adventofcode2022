string path = "input.txt";
string[] temp = File.ReadAllLines(path);
(Queue<Dictionary<int,int>>,int Tru,int Fal,int Tes,string ope, int count)[] que = 
      new (Queue<Dictionary<int,int>>,int Tru,int Fal,int Tes,string ope, int count)[4];
int m = -1;

for (int i = 0; i < temp.Length; i++)
{
  string[] temp1 = temp[i].Split(":");
  if(temp1[0] == "  Starting items")
  {
      string[] tempt = temp1[1].Split(",");
      for (int l = 0; l < tempt.Length; l++)
      {
          que[m].Item1.Enqueue(Sonlar(int.Parse(tempt[l])));
      }
  }
  else if(temp1[0] == "  Operation")
  {
    que[m].ope = temp1[1];
  }
  else if(temp1[0] == "  Test")
  {
      var temp2 = temp1[1].Split(" "); 
      que[m].Tes = int.Parse(temp2[temp2.Length - 1]);
  }
  else if(temp1[0] == "    If true")
  {
    var temp2 = temp1[1].Split(" "); 
      que[m].Tru = int.Parse(temp2[temp2.Length - 1]);
  }
  else if(temp1[0] == "    If false")
  {
    var temp2 = temp1[1].Split(" "); 
      que[m].Fal = int.Parse(temp2[temp2.Length - 1]);
  }
  else
  {
    var str = temp1[0].Split(" ");
    if(str.Length > 0 && str[0] == "Monkey")
    {
      que[int.Parse(str[1])].Item1 = new Queue<Dictionary<int,int>>();
      m++;
    }
  }
}

for (int g = 0; g < 20; g++)
{
  for (int i = 0; i < que.Length; i++)
  {
    while(que[i].Item1.Count > 0)
    {
      var temppp = Razrabotchuk(que[i].Item1.Dequeue(),que[i].ope);
      que[i].count++;
      if(temppp.ContainsKey(que[i].Tes))
      {
        que[que[i].Tru].Item1.Enqueue(temppp);
      }
      else
      {
        que[que[i].Fal].Item1.Enqueue(temppp);
      }
    }
  }
}


for (int i = 0; i < que.Length; i++)
{
  System.Console.WriteLine(i + " " + que[i].count);
}


static Dictionary<int,int> Razrabotchuk(Dictionary<int,int> temp7, string temp1)
{
  Dictionary<int,int> temp = new Dictionary<int, int>();
  foreach (var item in temp7)
  {
    temp.Add(item.Key,item.Value);
  }
  string[] ddd = temp1.Split(" ");
  switch(ddd[4])
  {
    case "*":
      if(ddd[5] == "old")
      return temp;
      else
      {
        if(temp.ContainsKey(int.Parse(ddd[5])))
        return temp;
        else
        {
          temp.Add(int.Parse(ddd[5]),1);
          return temp;
        }
      }
    break;
    case "+":
      if(ddd[5] == "old")
      return temp;
      else
      {
        int kk = 1;
        foreach (var item in temp)
        {
          kk *= item.Key;
        }
        kk += int.Parse(ddd[5]);
        return Sonlar(kk);
      }
    break;
  }
  return temp;
}




static Dictionary<int,int> Sonlar(int mjk)
{
  Dictionary<int,int> mjkl = new Dictionary<int, int>();
        int tub = 2;
        while(mjk > 1)
        {
          if(mjk % tub == 0)
          {
            if(!mjkl.ContainsKey(tub))
            {
              mjkl.Add(tub,1);
            }
            while(mjk % tub == 0)
            {
              mjk /= tub;
            }
          }
          tub++;
        }
        return mjkl;
}