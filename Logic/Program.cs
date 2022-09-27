

int x = 1;
int y = 2;
int z = 3;
bool B, C, D;
B = x > y;
C = y > z;
D = z == x;

bool A = x > y | y > z & z == x;
A = !A;
if (x > y | y > z & z == x)
    Console.WriteLine("true");
else
    Console.WriteLine("false");



string[] array_text = GetData();
string[] array_new = Filter(array_text);
Print(array_new);

string[] GetData()
{
    string file = File.ReadAllText("D://russian_names.csv");
    string[] array_file = file.Split("\n");
    return array_file;
}

void Print(string[] array)
{
    for (int i = 1; i < array.Length; i++)
    {
        string[] array_fields = array[i].Split(";");
        if (array_fields.Length == 6)
            Console.WriteLine("{0}, {1}, {2}", array_fields[1], array_fields[2], array_fields[3]);
    }
}

string[] Filter(string[] array)
{
    int count = 0;
    for (int i = 1; i < array.Length; i++)
    {
        string[] array_fields = array[i].Split(";");
        if (array_fields.Length != 6) continue;
        if (!ApplyFilter(array_fields)) continue;

        count++;
    }

    string[] array_new = new string[count];
    int j = 0;

    for (int i = 1; i < array.Length; i++)
    {
        string[] array_fields = array[i].Split(";");
        if (array_fields.Length != 6) continue;
        if (!ApplyFilter(array_fields)) continue;
        array_new[j++] = array[i];

    }
    return array_new;
}



bool ApplyFilter(string[] array_fields)
{
    return array_fields[2] == "Ж" && int.Parse(array_fields[3]) >10;
}