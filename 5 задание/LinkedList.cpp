#include "BaseList.h"
#include <stdexcept>
#include <iostream>
#include "LinkedList.h"

LinkedList::LinkedList() : head(nullptr){}

LinkedList::~LinkedList() {
    clear();
}

int LinkedList::getCount() const {
    return count;
}

void LinkedList::add(int item) {
    std::cout<<count<<std::endl;
    if (!head) {
        head = new Node(item);
    } else {
        Node* current = head;
        while (current->next) {
            current = current->next;
        }
        current->next = new Node(item);
    }
    ++count;
}

void LinkedList::insert(int pos, int item) {
    if (pos < 0 || pos > count) {
        return;
    }

    Node* newNode = new Node(item);

    if (pos == 0) {
        newNode->next = head;
        head = newNode;
    } else {
        Node* current = head;
        for (int i = 0; i < pos - 1; ++i) {
            current = current->next;
        }
        newNode->next = current->next;
        current->next = newNode;
    }
    ++count;
}

void LinkedList::remove(int pos) {
    if (pos < 0 || pos >= count) {
        return;
    }

    Node* temp = nullptr;

    if (pos == 0) {
        temp = head;
        head = head->next;
    } else {
        Node* current = head;
        for (int i = 0; i < pos - 1; ++i) {
            current = current->next;
        }
        temp = current->next;
        current->next = temp->next;
    }

    delete temp;
    --count;
}

void LinkedList::clear() {
    while (head) {
        Node* temp = head;
        head = head->next;
        delete temp;
    }
    count = 0;
}

int& LinkedList::operator[](int i) {
    if (i < 0 || i >= count) {
        throw std::out_of_range("Index out of range");
    }

    Node* current = head;
    for (int j = 0; j < i; ++j) {
        current = current->next;
    }
    return current->data;
}

const int& LinkedList::operator[](int i) const {
    if (i < 0 || i >= count) {
        throw std::out_of_range("Index out of range");
    }

    Node* current = head;
    for (int j = 0; j < i; ++j) {
        current = current->next;
    }
    return current->data;
}