#ifndef LINKEDLIST_H
#define LINKEDLIST_H

#include "BaseList.h"

class LinkedList : public BaseList {
private:
    struct Node {
        int data;
        Node* next;
        Node(int value) : data(value), next(nullptr) {}
        
    };

    Node* head;
    // int count;

public:
    LinkedList();
    ~LinkedList();
    int getCount() const override;
    void add(int item) override;
    void insert(int pos, int item) override;
    void remove(int pos) override;
    void clear() override;
    int& operator[](int i) override;
    // void print();
    const int& operator[](int i) const override;
    // BaseList* clone() const override;

private:
    void deleteList();
};

#endif // LINKEDLIST_H
