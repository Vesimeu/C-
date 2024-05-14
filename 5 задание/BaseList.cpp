#include <iostream>
#include <stdexcept>
// #include "BaseList.h"
// #include "LinkedList.h" // Добавим, если нужно

#include "BaseList.h"

// BaseList::~BaseList() {}

void BaseList::assign(const BaseList& source) {
    clear();
    for (int i = 0; i < source.getCount(); ++i) {
        add(source[i]);
    }
}

void BaseList::assignTo(BaseList& dest) const {
    dest.clear();
    for (int i = 0; i < count; ++i) {
        dest.add((*this)[i]);
    }
}

void BaseList::print() const {
    // std::cout << count << std::endl; Отладочка
    for (int i = 0; i < count; ++i) {
        std::cout << (*this)[i] << " ";
    }
    std::cout << std::endl; 
}

// BaseList* BaseList::clone() const {
//     BaseList* clonedList = new LinkedList(); // Создаем объект нужного класса, копируя в него элементы текущего объекта
//     clonedList->assign(*this); // Копируем содержимое текущего объекта в клон
//     return clonedList;
// }

void BaseList::sort() {
    // Bubble sort implementation
    for (int i = 0; i < count - 1; ++i) {
        for (int j = 0; j < count - 1 - i; ++j) {
            if ((*this)[j] > (*this)[j + 1]) {
                int temp = (*this)[j];
                (*this)[j] = (*this)[j + 1];
                (*this)[j + 1] = temp;
            }
        }
    }
}

bool BaseList::isEqual(const BaseList& other) const {
    if (count != other.getCount()) {
        return false;
    }
    for (int i = 0; i < count; ++i) {
        if ((*this)[i] != other[i]) {
            return false;
        }
    }
    return true;
}
