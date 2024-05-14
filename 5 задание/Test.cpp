#include <iostream>
#include "DynamicList.h"
#include "LinkedList.h"

int main() {
    // Создаем объекты списков
    DynamicList dynamicList;
    LinkedList linkedList;

    // Добавляем элементы в списки
    for (int i = 1; i <= 10; ++i) {
        dynamicList.add(i);
        linkedList.add(i * 10);
    }

    // Выводим списки
    std::cout << "DynamicList: ";
    dynamicList.print();
    std::cout << "LinkedList: ";
    linkedList.print();

    // Сортируем списки
    dynamicList.sort();
    linkedList.sort();

    // Выводим отсортированные списки
    std::cout << "DynamicList (sorted): ";
    dynamicList.print();
    std::cout << "LinkedList (sorted): ";
    linkedList.print();

    // Проверяем на равенство
    if (dynamicList.isEqual(linkedList)) {
        std::cout << "DynamicList is equal to LinkedList\n";
    } else {
        std::cout << "DynamicList is not equal to LinkedList\n";
    }

    return 0;
}
