#ifndef BASELIST_H
#define BASELIST_H

class BaseList {
public:
    virtual ~BaseList() {} 
    virtual int getCount() const = 0;
    virtual void add(int item) = 0;
    virtual void insert(int pos, int item) = 0;
    virtual void remove(int pos) = 0;
    virtual void clear() = 0;
    virtual int& operator[](int i) = 0;
    virtual const int& operator[](int i) const = 0 ;

    //Виртуальные методы которые не будут перегружаться в классах наследниках
    virtual void assign(const BaseList& source) ;
    virtual void assignTo(BaseList& dest) const ;
    virtual void print() const;
    virtual void sort();
    virtual bool isEqual(const BaseList& other) const ;
    int count = 0;
};

#endif // BASELIST_H
