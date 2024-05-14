#include "DynamicList.h"
#include "LinkedList.h"
#include <iostream>
#include <random>
#include <stdexcept>

void testPerformance() {
    std::random_device rd;
    std::mt19937 gen(rd());
    std::uniform_int_distribution<> operationDist(0, 6);
    std::uniform_int_distribution<> valueDist(0, 99);
    std::uniform_int_distribution<> indexDist(1, 99);
    

    DynamicList dynamicList;
    LinkedList linkedList;

    for (int i = 0; i < 10000; ++i) {
        int operation = operationDist(gen);
        int value = valueDist(gen);
        int index = indexDist(gen);

        try {
            switch (operation) {
                case 0:
                    dynamicList.add(value);
                    linkedList.add(value);
                    break;
                case 1:
                    if (dynamicList.getCount() > 0 && linkedList.getCount() > 0) {
                        dynamicList.insert(value, index % dynamicList.getCount());
                        linkedList.insert(value, index % linkedList.getCount());
                    }
                    break;
                case 2:
                    if (dynamicList.getCount() > 0 && linkedList.getCount() > 0) {
                        dynamicList.remove(index);
                        linkedList.remove(index);
                    }
                    break;
                case 3:
                    dynamicList.clear();
                    linkedList.clear();
                    break;
                case 4:
                    if (dynamicList.getCount() > 0 && linkedList.getCount() > 0) {
                        dynamicList[index % dynamicList.getCount()] = value;
                        linkedList[index % linkedList.getCount()] = value;
                    }
                    break;
                case 5:
                    dynamicList.sort();
                    linkedList.sort();
                    break;
            }
        } catch (const std::exception& e) {
            std::cout << "Error: " << e.what() << std::endl;
        }
    }

    std::cout << (dynamicList.getCount() == linkedList.getCount()) << std::endl; //if 1 to true 

    bool areListsEqual = dynamicList.isEqual(linkedList);
    std::cout << "Lists are " << (areListsEqual ? "equal" : "different") << "." << std::endl;
    std::cout << "Testing completed." << std::endl;
}

int main() {
   BaseList* dynamicList = new DynamicList();
    BaseList* linkedList = new LinkedList();

    std::cout << "Testing the Add method:" << std::endl;
    dynamicList->add(3);
    dynamicList->add(10);
    dynamicList->add(5);

    linkedList->add(3);
    linkedList->add(10);
    linkedList->add(5);

    std::cout << "DynamicList after adding elements:" << std::endl;
    dynamicList->print();
    std::cout << "LinkedList after adding elements:" << std::endl;
    linkedList->print();
    std::cout << std::endl;

    std::cout << "Testing the Insert method:" << std::endl;
    dynamicList->insert(1, 1);
    linkedList->insert(1, 1);

    std::cout << "DynamicList after inserting an element:" << std::endl;
    dynamicList->print();
    std::cout << "LinkedList after inserting an element:" << std::endl;
    linkedList->print();
    std::cout << std::endl;

    std::cout << "Testing the Delete method:" << std::endl;
    dynamicList->remove(1);
    linkedList->remove(1);

    std::cout << "DynamicList after removing an element:" << std::endl;
    dynamicList->print();
    std::cout << "LinkedList after removing an element:" << std::endl;
    linkedList->print();
    std::cout << std::endl;

    std::cout << "Testing the Clear method:" << std::endl;
    dynamicList->clear();
    linkedList->clear();

    std::cout << "DynamicList after clearing:" << std::endl;
    dynamicList->print();
    std::cout << "LinkedList after clearing:" << std::endl;
    linkedList->print();
    std::cout << std::endl;

    std::cout << "Testing the IsEqual method:" << std::endl;
    dynamicList->add(3);
    dynamicList->add(10);
    dynamicList->add(5);

    linkedList->add(3);
    linkedList->add(10);
    linkedList->add(5);

    bool equal = dynamicList->isEqual(*linkedList);
    std::cout << "Lists are " << (equal ? "equal" : "different") << std::endl;

    std::cout << "***Testing the Assign method***" << std::endl;

    BaseList* assignedList = new DynamicList();
    assignedList->add(1);
    assignedList->add(2);
    assignedList->add(3);

    std::cout << "Original dynamicList:" << std::endl;
    dynamicList->print();
    std::cout << "Original assignedList:" << std::endl;
    assignedList->print();

    dynamicList->assign(*assignedList);

    std::cout << "DynamicList after applying the Assign method:" << std::endl;
    dynamicList->print();
    std::cout << "AssignedList after applying the Assign method:" << std::endl;
    assignedList->print();
    std::cout << std::endl;

    std::cout << "***Testing the AssignTo method***" << std::endl;

    dynamicList->add(9);
    BaseList* assignedToList = new DynamicList();
    assignedToList->add(2);
    assignedToList->add(4);
    assignedToList->add(3);

    std::cout << "DynamicList after applying the Assign method:" << std::endl;
    dynamicList->print();
    std::cout << "AssignedToList after applying the Assign method:" << std::endl;
    assignedToList->print();

    dynamicList->assignTo(*assignedToList);

    std::cout << "DynamicList after applying the AssignTo method:" << std::endl;
    dynamicList->print();
    std::cout << "AssignedToList after applying the AssignTo method:" << std::endl;
    assignedToList->print();
    std::cout << std::endl;

    std::cout << "Testing the Sort method:" << std::endl;
    dynamicList->sort();
    linkedList->sort();

    std::cout << "DynamicList after sorting:" << std::endl;
    dynamicList->print();
    std::cout << "LinkedList after sorting:" << std::endl;
    linkedList->print();
    std::cout << std::endl;

    std::cout << "***Calling the performance testing method***" << std::endl;
    testPerformance();

    delete dynamicList;
    delete linkedList;

    return 0;
}
