using CryptographyLib;
using System.Diagnostics;
using System.IO;
using System.Numerics;


BigInteger[] getContinuedFraction(BigInteger b, BigInteger a, int limit, out int size)
{
    BigInteger[] coeffs = new BigInteger[limit];

    for (size = 0; size < limit; size++)
    {
        BigInteger div = BigInteger.Divide(b, a);
        coeffs[size] = div;
        BigInteger t = a;
        BigInteger.DivRem(b, a, out a); //остаток  a = b - div * a;
        b = t;
        if (a == 0) break;
    }
    return coeffs;
}


BigInteger WienerAttack(BigInteger n, BigInteger e)
{
    int limit = 32; int size;
    BigInteger[] coeffs = getContinuedFraction(n, e, limit, out size);

    /*foreach (BigInteger coefficient in coeffs)
    {
        Console.WriteLine(coefficient.ToString());
    }*/

    BigInteger qi;
    //BigInteger pi2 = 1, pi1 = 0;
    BigInteger qi2 = 0, qi1 = 1;

    int lenNBytes = 32;

    for (int i = 0; i < limit; i++)
    {
        qi = coeffs[i] * qi1 + qi2;

        BigInteger m = Cryptography.getRandomBigInteger(lenNBytes) % n;

        if (BigInteger.ModPow(m, e * qi, n) == m) return qi;

        qi2 = qi1;
        qi1 = qi;
    }

    return 0;
}

BigInteger n = 1220275921, e = 1073780833;
Console.WriteLine(WienerAttack(n, e));
n = 2796304957;
e = 1779399043;
Console.WriteLine(WienerAttack(n, e));









return;

BigInteger p1 = BigInteger.Parse("28383634463013533931739356077");
// t = 19380265085840254491285433902460268744611336351034722096408992562558754544593
// tA = 1125095555625344820451352329
// tAB = 1125095555625344820451352329

/*
Generated prime: 11779627509269
Generated prime: 267161487820018966909342704086828398431737366834966681877874561830185962764513577227076371974507697161285191228230707474998747208788691828051746899369421908156666007948967404135286756002733936385493485106523
t (key):8173559240281143206369716588848558201407293035221686873373476518205632680466
a:20050941495237
tA:5224571659432
tA (received):5224571659432
b:225063686720639
tAB:6503094376403
tAB (received):6503094376403
tB:11720080379584
tB (received):11720080379584
t (key):9228258897818

*/

/*BigInteger t = BigInteger.Parse("8173559240281143206369716588848558201407293035221686873373476518205632680466");
BigInteger a = BigInteger.Parse("20050941495237");
BigInteger r = BigInteger.Parse("11779627509268");
BigInteger tA = BigInteger.ModPow(t, a, r);*/


byte[] data = new byte[1024];
Array.Fill<byte>(data, 0x24);

BigInteger d = BigInteger.Parse("55441196065363246126355624130324183196576709222340016572108097750006097525544");



GOST gost = new GOST();

byte[] sign = gost.Sign(d, data);
bool result = gost.Verify(data, sign);
Console.WriteLine(result);


EllipticCurve curve = new EllipticCurve();

/*curve.p = 97;
curve.A = 2;
curve.B = 3;
curve.xP = 17;
curve.yP = 10;*/


EllipticCurvePoint P = new EllipticCurvePoint(curve.xP, curve.yP, curve);
//EllipticCurvePoint Q = new EllipticCurvePoint(1, 43, curve);

//EllipticCurvePoint R = EllipticCurvePoint.Add(P, Q);

EllipticCurvePoint R = EllipticCurvePoint.Multiply(d, P);



Console.WriteLine("x:" + R.x.ToString());
Console.WriteLine("y:" + R.y.ToString());
