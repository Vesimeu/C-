#ifndef DYNAMICLIST_H
#define DYNAMICLIST_H

#include "BaseList.h"

class DynamicList : public BaseList {
private:
    int* buffer;
    // int count;
    int capacity;

public:
    DynamicList();
    ~DynamicList();
    int getCount() const override;
    void add(int item) override;
    void insert(int pos, int item) override;
    void remove(int pos) override;
    void clear() override;
    int& operator[](int i) override;
    const int& operator[](int i) const override;

private:
    void resize(int newSize);
};

#endif // DYNAMICLIST_H
