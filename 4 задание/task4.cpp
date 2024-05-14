#include <iostream>
#include <cstdlib>

class DynamicList {
private:
    int* buffer; // Массив для хранения элементов списка
    int count; // Количество элементов в списке
    int bufferSize; // Размер буфера

public:
    DynamicList() {
        bufferSize = 4; // Начальный размер буфера
        buffer = new int[bufferSize];
        count = 0;
    }

    // Добавление элемента в список
    void Add(int item) {
        if (count == bufferSize) {
            Resize(bufferSize * 2); // Увеличиваем размер буфера, если необходимо
        }
        buffer[count++] = item;
    }

    // Удаление дубликатов
    void RemoveDuplicates() {
        for (int i = 0; i < count - 1; i++) {
            for (int j = i + 1; j < count; j++) {
                if (buffer[i] == buffer[j]) {
                    Delete(j);
                    j--; // После удаления уменьшаем индекс, чтобы не пропустить следующий элемент
                }
            }
        }
    }

    // Вставка элемента на указанную позицию
    void Insert(int item, int pos) {
        if (pos > count || pos < 0) {
            throw std::out_of_range("Позиция вне диапазона списка");
        }

        if (count == bufferSize) {
            Resize(bufferSize * 2);
        }

        // Сдвигаем элементы на одну позицию вправо, начиная с конца списка
        for (int i = count; i > pos; i--) {
            buffer[i] = buffer[i - 1];
        }

        buffer[pos] = item;
        count++;
    }

    // Удаление элемента с указанной позиции
    void Delete(int index) {
        if (index < 0 || index >= count) {
            return;
        }

        for (int i = index; i < count - 1; i++) {
            buffer[i] = buffer[i + 1];
        }

        buffer[count - 1] = 0; // Обнуляем последний элемент после сдвига
        count--;
    }

    // Очистка списка
    void Clear() {
        delete[] buffer;
        bufferSize = 4; // Возвращаем начальный размер буфера
        buffer = new int[bufferSize];
        count = 0;
    }

    // Получение количества элементов в списке
    int Count() const {
        return count;
    }

    // Получение элемента по индексу
    int& operator[](int i) {
        if (i >= count || i < 0) {
            throw std::out_of_range("Индекс вне диапазона списка");
        }
        return buffer[i];
    }

    // Изменение размера буфера
    void Resize(int newSize) {
        int* newBuffer = new int[newSize];
        for (int i = 0; i < count; i++) {
            newBuffer[i] = buffer[i];
        }
        delete[] buffer;
        buffer = newBuffer;
        bufferSize = newSize;
    }

    // Вывод элементов списка
    void Cout() {
        for (int i = 0; i < count; i++) {
            std::cout << buffer[i] << " ";
        }
        std::cout << std::endl;
    }

    ~DynamicList() {
        delete[] buffer;
    }
};

class LinkedList {
private:
    struct Node {
        int data; // Данные, хранящиеся в узле
        Node* next; // Ссылка на следующий узел в списке

        Node(int d) : data(d), next(nullptr) {}
    };

    Node* head; // Голова списка, первый узел
    int count; // Количество узлов в списке

public:
    LinkedList() : head(nullptr), count(0) {}

    // Добавление элемента в конец списка
    void Add(int data) {
        if (head == nullptr) {
            head = new Node(data);
        }
        else {
            Node* current = head;
            while (current->next != nullptr) {
                current = current->next;
            }
            current->next = new Node(data);
        }
        count++;
    }
    // Оператор [] для доступа к элементам списка по индексу
    int& operator[](int index) {
        if (index < 0 || index >= count) {
            throw std::out_of_range("Индекс вне диапазона списка");
        }

        Node* current = head;
        for (int i = 0; i < index; i++) {
            current = current->next;
        }
        return current->data;
    }

    // Вставка элемента на указанную позицию
    void Insert(int data, int pos) {
        if (pos < 0 || pos > count) {
            throw std::out_of_range("Позиция вне допустимого диапазона");
        }

        Node* newNode = new Node(data);

        if (pos == 0) {
            newNode->next = head;
            head = newNode;
        }
        else {
            Node* current = head;
            for (int i = 0; i < pos - 1; i++) {
                current = current->next;
            }

            newNode->next = current->next;
            current->next = newNode;
        }
        count++;
    }

    // Удаление элемента с указанной позиции
    void Delete(int pos) {
        if (pos < 0 || pos >= count) {
            return;
        }

        Node* temp = head;

        if (pos == 0) {
            head = head->next;
            delete temp;
        }
        else {
            Node* current = head;
            for (int i = 0; i < pos - 1; i++) {
                current = current->next;
            }

            temp = current->next;
            current->next = temp->next;
            delete temp;
        }
        count--;
    }

    // Очистка списка
    void Clear() {
        Node* current = head;
        while (current != nullptr) {
            Node* next = current->next;
            delete current;
            current = next;
        }
        head = nullptr;
        count = 0;
    }

    // Получение количества элементов в списке
    int Count() const {
        return count;
    }

    // Вывод элементов списка
    void Cout() const {
        Node* current = head;
        while (current != nullptr) {
            std::cout << current->data << " ";
            current = current->next;
        }
        std::cout << std::endl;
    }

    ~LinkedList() {
        Clear();
    }
};

class PerformanceTester {
private:
    static int getRandom(int min, int max) {
        return min + rand() % (max - min + 1);
    }

public:
    static void TestPerformance() {
    DynamicList dynamicList;
    LinkedList linkedList;

    for (int i = 0; i < 10000; i++) {
        int operation = getRandom(0, 5); // Выбор операции
        int value = getRandom(0, 99); // Случайное значение
        int index = getRandom(1, 99); // Случайный индекс

        try {
            switch (operation) {
            case 0:
                dynamicList.Add(value);
                linkedList.Add(value);
                break;
            case 1:
                if (dynamicList.Count() > 0 && linkedList.Count() > 0) {
                    dynamicList.Insert(value, index % dynamicList.Count());
                    linkedList.Insert(value, index % linkedList.Count());
                }
                break;
            case 2:
                if (dynamicList.Count() > 0 && linkedList.Count() > 0) {
                    dynamicList.Delete(index);
                    linkedList.Delete(index);
                }
                break;
            case 3:
                dynamicList.Clear();
                linkedList.Clear();
                break;
            case 4:
                if (dynamicList.Count() > 0 && linkedList.Count() > 0) {
                    dynamicList[index % dynamicList.Count()] = value;
                    linkedList[index % linkedList.Count()] = value;
                }
                break;
            }
        }
        catch (const std::exception& e) {
            std::cout << "Ошибка: " << e.what() << std::endl;
        }
    }

    // Проверка списков на равенство
    bool listsEqual = true;
    if (dynamicList.Count() == linkedList.Count()) {
        for (int i = 0; i < dynamicList.Count(); ++i) {
            if (dynamicList[i] != linkedList[i]) {
                listsEqual = false;
                break;
            }
        }
    } else {
        listsEqual = false;
    }

    if (listsEqual) {
        std::cout << "Тестирование завершено успешно. Списки одинаковы. :0 " << std::endl;
    } else {
        std::cout << "Тестирование завершено с ошибкой. Списки не совпадают." << std::endl;
    }
}
};

int main() {
    std::cout << "Тестирование" << std::endl;

    // Тестирование DynamicList
    std::cout << "Тестирование DynamicList:" << std::endl;
    DynamicList dynamicList;
    dynamicList.Add(1);
    dynamicList.Add(2);
    dynamicList.Add(3);
    dynamicList.Insert(4, 1); // Вставляем 4 на позицию 1
    dynamicList.Cout(); // Должно вывести: 1 4 2 3

    dynamicList.Delete(2); // Удаляем элемент на позиции 2
    dynamicList.Cout(); // Должно вывести: 1 4 3

    dynamicList.Clear();
    dynamicList.Cout(); // Должно вывести пустую строку

    // Тестирование LinkedList
    std::cout << "\nТестирование LinkedList:" << std::endl;
    LinkedList linkedList;
    linkedList.Add(5);
    linkedList.Add(6);
    linkedList.Add(7);
    linkedList.Insert(8, 2); // Вставляем 8 на позицию 2
    linkedList.Cout(); // Должно вывести: 5 6 8 7

    linkedList.Delete(1); // Удаляем элемент на позиции 1
    linkedList.Cout(); // Должно вывести: 5 8 7

    linkedList.Clear();
    linkedList.Cout(); // Должно вывести пустую строку

    std::cout << "Тестирование 2" << std::endl;
    PerformanceTester::TestPerformance();

    return 0;
}
