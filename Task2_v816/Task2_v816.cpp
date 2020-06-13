#include <fstream>
#include <set>
#include <vector>
#include <iostream>

using namespace std;

void print(const vector<set<size_t>>& sets, size_t key, ostream& ost) 
{
    // Если список не содердит множество с адресом key
    if (sets.size() <= key || sets[key].empty()) 
    {
        ost << "-1" << endl;
        return;
    }

    for (auto value : sets[key]) 
    {
        ost << value << " ";
    }

    ost << endl;
}

int main() 
{
    ifstream ifst("input.txt");
    ofstream ofst("output.txt");

    size_t n, m, k;

    vector<set<size_t>> set_values; // Вектор Список множеств
    vector<set<size_t>> value_sets; // Вектор Список элементов ссылками на множества, в которых они встречаются 

    // Ввод максимального числа множества, количетсва множеств, количества операций
    ifst >> m >> n >> k;

    cout << "Программа получла следующее данные" << endl
         << "Максимальное число в множестве - " << m << endl
         << "Количество множеств - " << n << endl
         << "Количество операций - " << k << endl;

    set_values.resize(n + 1);
    value_sets.resize(m + 1);

    cout << "Операции" << endl;
    for (size_t i = 0; i < k; ++i) 
    {
        string operation;
        size_t element, set;

        ifst >> operation;

        if (operation == "ADD") 
        {
            ifst >> element >> set;

            if (element >= 1 && element <= m)
            {
                set_values[set].insert(element);
                value_sets[element].insert(set);
                cout << "Операция ADD " << element << " " << set << " была выполнена."<< endl;
            }
            else
            {
                cout << "Операция ADD " << element << " " << set << " не была выполнена, так как введеый элемент превышает максимальное разрешенноe." << endl;
            }
        }
        if (operation == "LISTSET")
        {
            ifst >> set;
            print(set_values, set, ofst);
            cout << "Операция LISTSET " << set << " была выполнена." << endl;
        }
        if (operation == "LISTSETSOF") 
        {
            ifst >> element;
            print(value_sets, element, ofst);
            cout << "Операция LISTSETSOF " << element << " была выполнена." << endl;
        }
    }

    cout << "Результаты выполнения операций хранятся в файле output.txt" << endl;
    system("Pause");
}