#ifndef STACK
#define STACK
#include <vector>

template<typename T>
class Stack : public std::vector<T>
{
private:
	vector<T> elements;
	//int size;

public:
	Stack();

	/*Implementing this with inheriting from the vector class is almost pointless
	since the vector class already has the same or similar functions as these.
	This is basically accessing the vector functions through the Stack class.*/

	//bool empty() const;
	//T peek() const;
	//void push(T value);
	//T pop();
	//int getSize() const;
};

#endif

template<typename T>
Stack<T>::Stack()
{
	//size = 0;
}

/*
Already in vector class
template<typename T>
bool Stack<T>::empty() const
{
return size == 0;
}


template<typename T>
T Stack<T>::peek() const
{
	return elements[size - 1];
}


//In vector
template<typename T>
void Stack<T>::push(T value)
{
	elements[size++] = value;
}

//In vector
template<typename T>
T Stack<T>::pop()
{
	return elements[--size];
}

template<typename T>
int Stack<T>::getSize() const
{
	return size;
}
*/