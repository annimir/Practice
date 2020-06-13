#include <fstream>
#include <string>
#include <sstream>
#include <list>

using namespace std;

class ipadress
{
private:
    union
    {
        unsigned int adress32 : 32;
        unsigned char adress8[4];
    }adress;

    friend ifstream& operator>>(ifstream& stream, ipadress& ip);
    friend bool oneNetwork(const ipadress& ip1, const ipadress& ip2, const ipadress& mask);
};

int main()
{
    ifstream in("INPUT.TXT");
    ofstream out("OUTPUT.TXT");

    unsigned int netMasksCount;
    in >> netMasksCount;

    list<ipadress> masks;
    for (unsigned int i = 0; i < netMasksCount; ++i)
    {
        ipadress ip;
        in >> ip;
        masks.push_back(ip);
    }

    unsigned int netAdressCount;
    in >> netAdressCount;

    for (unsigned int i = 0; i < netAdressCount; ++i)
    {
        ipadress ip1, ip2;
        in >> ip1 >> ip2;
        unsigned int counter = 0;
        for (list<ipadress>::const_iterator it = masks.begin(); it != masks.end(); ++it)
        {
            counter += oneNetwork(ip1, ip2, *it);
        }
        out << counter << endl;
    }
    return 0;
}

ifstream& operator>>(ifstream& stream, ipadress& ip)
{
    string str;
    stream >> str;
    if (!stream.fail())
    {
        char sa[4];
        int ia;
        bool good = true;
        unsigned __int32 adress = 0;

        istringstream sstream(str);
        for (unsigned int i = 0; i < 4 && good; ++i)
        {
            if (i)sstream.ignore(1, '.');
            sstream.get(sa, 4, '.');
            ia = atoi(sa);
            if (ia > 255)good = false;
            adress = (adress << 8) | ia;
        }
        if (good)ip.adress.adress32 = adress;
        else stream.setstate(ios::badbit);
    }
    return stream;
}
bool oneNetwork(const ipadress& ip1, const ipadress& ip2, const ipadress& mask)
{
    return (ip1.adress.adress32 & mask.adress.adress32) == (ip2.adress.adress32 & mask.adress.adress32);
}