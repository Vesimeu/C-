#include "DynamicList.h"
#include "LinkedList.h"
#include <iostream>
#include <random>
#include <stdexcept>


int main() {
    BaseList* dynamicList = new DynamicList();
    BaseList* linkedList = new LinkedList();
    
    std::cout<<linkedList<<std::endl;
    linkedList->add(3);
    linkedList->add(10);
    linkedList->add(5);

    dynamicList->add(4);

    // std::cout << "DynamicList after adding elements:" << std::endl;
    // dynamicList->print();
    std::cout << "LinkedList after adding elements:" << std::endl;
    linkedList->print();
    dynamicList->print();
    std::cout << std::endl;

    delete dynamicList;
    delete linkedList;


    return 0;
}
