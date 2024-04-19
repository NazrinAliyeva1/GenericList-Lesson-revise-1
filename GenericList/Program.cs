using System;
using System.Runtime.InteropServices;

namespace GenericList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ObjectArrayList integrs = new ObjectArrayList(typeof(String));
            //integrs.Add("32");
            //integrs.Add("2");
            //integrs.Add("3");
            //integrs.GetElement();


            //StringArrayList strs = new StringArrayList();
            //strs.Add("Nazrin");
            //strs.Add("Aliyeva");
            //strs.Add("Opur Hamini =>:) :) ;)");
            //strs.GetElemnt();

            //GenericList <Student> intArr = new GenericList<Student>();
            var students = new Student[] {
            new Student
            {
                Name = "Nazile",
                Surname = "Abbasli"
            },
            new Student
            {
                Name = "Sahil",
                Surname = "Abbli"
            }

            };
            GenericList<Student> stdArr = new GenericList<Student>(students);
            stdArr.GetElement();

            //GenericList<int> intArrw = new GenericList<int>();
            //intArrw.Add(1);
            //intArrw.Add(2);
            //intArrw.GetElement();

        }

    }

    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
    class GenericList<T>
    {
        T[] _array;
        public int Capacity { get; set; } = 5;
        public int Count { get; set; } = 0;

        public GenericList(int capacity)
        {
            Capacity = capacity;
            _array = new T[Capacity];

        }
        public GenericList(T[] array, int capacity=5)
        {
            Capacity = capacity;
            _array = array;
            Count = _array.Length;  

        }
        public void Add(T value)
        {

            if (_array.Length == Count)
            {
                Array.Resize(ref _array, Count + Capacity);

            }
            _array[Count++] = value;
        }

        public void GetElement()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(_array[i]);
            }
        }

    }

    class ObjectArrayList
    {
        object[] _array;
        public int Capacity { get; set; } = 5;
        public int Count { get; set; } = 0;
        private Type _listType;
        public ObjectArrayList(Type listType)
        {
            _array = new object[Capacity];
            _listType = listType;
        }
        public ObjectArrayList(int capacity, Type listType)
        {
            Capacity = capacity;
            _array = new object[Capacity];
            _listType = listType;

        }
        public void Add(object value)
        {
            if (value.GetType().Name == _listType.Name)
            {
                if (_array.Length == Count)
                {
                    Array.Resize(ref _array, Count + Capacity);

                }
                _array[Count++] = value;

            }
            else
            {
                throw new ArrayTypeMismatchException();
            }

        }

        public void GetElement()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(_array[i]);
            }
        }


    }

    class StringArrayList
    {
        string[] _array;
        public int Capacity { get; set; } = 5;
        public int Count { get; private set; } = 0;


        public StringArrayList()
        {
            _array = new string[Capacity];
        }
        public StringArrayList(int capacity)
        {
            Capacity = capacity;
            _array = new string[Capacity];
        }
        public void Add(string value)
        {
            if (_array.Length == Count)
            {
                Array.Resize(ref _array, Count + Capacity);
            }
            _array[Count] = value;
            Count++;
        }
        public void GetElemnt()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(_array[i]);
            }
        }
    }

}

