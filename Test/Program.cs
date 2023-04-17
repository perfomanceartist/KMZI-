// Клиенское приложение
using CryptographyLib;
using System.Diagnostics;
using System.IO;
using System.Numerics;


Console.WriteLine("Введите границу базы простых чисел D:");
string? mstr = Console.ReadLine();
Console.WriteLine("Введите факторизуемое число:");
string? nstr = Console.ReadLine();
if (nstr == null) return;
BigInteger n = BigInteger.Parse(nstr);


LenstraFactorisation lenstra = new LenstraFactorisation(Convert.ToInt16(mstr));


Int64 tries;

DateTime startTime = DateTime.Now;


BigInteger d = lenstra.Factor(n, 1000000, out tries);

TimeSpan difference = (DateTime.Now - startTime);
string timeString = difference.Hours + ":" + difference.Minutes + ":" + difference.Seconds;

Console.Clear();
Console.WriteLine("Factorising number: " + n.ToString());
Console.WriteLine("Found factor : " + d.ToString());
Console.WriteLine("Total time: " + timeString);
Console.WriteLine("Iterations: " + tries);



/*
//BigInteger factor1 = BigInteger.Parse("816090919034804801829483632676405325904602891528591278609217435184417988562991");
//BigInteger factor2 = BigInteger.Parse("646734967453693699814719158526461074929200460362425027145449669290622486244349");

//BigInteger factor1 = BigInteger.Parse("6744274345102754102145487");
//BigInteger factor2 = BigInteger.Parse("2577569434851656888248393");
BigInteger factor1 = BigInteger.Parse("68704624514115959561");
BigInteger factor2 = BigInteger.Parse("52376460141248978561");
BigInteger factor3 = BigInteger.Parse("8970383295884199319789357");
BigInteger factor4 = BigInteger.Parse("9670369451257969922512591");
BigInteger factor5 = BigInteger.Parse("7110452979724516125024877");


//BigInteger n = factor1 * factor2 * factor3 * factor4 * factor5;
BigInteger n = factor1 * factor2;
*/