// #include "BaseList.h"
#include <algorithm>
#include <stdexcept>
#include <iostream>
#include "DynamicList.h"

DynamicList::DynamicList() : buffer(new int[4]), capacity(4) {}

DynamicList::~DynamicList() {
    delete[] buffer;
}

int DynamicList::getCount() const {
    return count;
}

void DynamicList::add(int item) {
    if (count == capacity) {
        resize(capacity * 2);
    }
    buffer[count++] = item;
}

void DynamicList::insert(int pos, int item) {
    if (pos < 0 || pos > count) {
        return;
    }

    if (count == capacity) {
        resize(capacity * 2);
    }

    for (int i = count; i > pos; --i) {
        buffer[i] = buffer[i - 1];
    }

    buffer[pos] = item;
    ++count;
}

void DynamicList::remove(int pos) {
    if (pos < 0 || pos >= count) {
        return;
    }

    for (int i = pos; i < count - 1; ++i) {
        buffer[i] = buffer[i + 1];
    }

    --count;
}

void DynamicList::clear() {
    delete[] buffer;
    buffer = new int[4];
    capacity = 4;
    count = 0;
}

int& DynamicList::operator[](int i) {
    if (i < 0 || i >= count) {
        throw std::out_of_range("Index out of range");
    }
    return buffer[i];
}

const int& DynamicList::operator[](int i) const {
    if (i < 0 || i >= count) {
        throw std::out_of_range("Index out of range");
    }
    return buffer[i];
}



void DynamicList::resize(int newSize) {
    int* newBuffer = new int[newSize];
    std::copy(buffer, buffer + count, newBuffer);
    delete[] buffer;
    buffer = newBuffer;
    capacity = newSize;
}

