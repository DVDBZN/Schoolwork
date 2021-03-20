#ifndef STACK
#define STACK
class StackOfIntegers
{
private:
	int elements[100];
	int size;
public:
	StackOfIntegers();
	bool isEmpty() const;
	int peak() const;
	void push(int);
	void pop();
	int getSize() const;
};
#endif