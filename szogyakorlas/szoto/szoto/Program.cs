using System.Text;
using szoto;

var filePath = "szo10000.txt";
if (!File.Exists(filePath))
    {
        Console.WriteLine($"File not found: {filePath}");
        return;
    }
    var list = new List<Szo>();
    foreach (var line in File.ReadLines(filePath, Encoding.UTF8).Skip(1))
    {
        if (string.IsNullOrWhiteSpace(line))
            continue;
            var parts = line.Split('\t');
        if (parts.Length < 4)
        {                 
            continue;
        }
        var szo = new Szo
        {
            azon = int.TryParse(parts[0], out var a) ? a : 0,
            szoto = parts[1],
            szofaj = parts[2],
            gyakori = int.TryParse(parts[3], out var g) ? g : 0
        };
        list.Add(szo);
    }
    var csvFilePath = "szo10000.csv";
    using (var writer = new StreamWriter(csvFilePath, false, Encoding.UTF8))
    {
        writer.WriteLine("azon,szoto,szofaj,gyakori");
        foreach (var szo in list)
        {
            writer.WriteLine($"{szo.azon},{szo.szoto},{szo.szofaj},{szo.gyakori}");
        }
    }
