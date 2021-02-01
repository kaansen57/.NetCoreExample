using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    class MyDictionary<TKey,TValue>
    {
        TKey[] _keyArray;
        TValue[] _valueArray;

        public MyDictionary()
        {
            _keyArray = new TKey[0];
            _valueArray = new TValue[0];
        }

        public void Add(TKey key , TValue value)
        {
            TKey[] _keyTemp = _keyArray;
            TValue[] _valueTemp = _valueArray;

            _keyArray = new TKey[_keyArray.Length + 1];
            _valueArray = new TValue[_valueArray.Length + 1];

            for (int i = 0; i < _keyTemp.Length; i++)
            {
                _keyArray[i] = _keyTemp[i];
                _valueArray[i] = _valueTemp[i];
            }

            _keyArray[_keyArray.Length - 1] = key;
            _valueArray[_valueArray.Length - 1] = value;
        }

        public TKey [] Keys
        {
            get { return _keyArray; }
        }

        public TValue [] Values
        {
            get { return _valueArray; }
        }

        public int Count
        {
            get { return _keyArray.Length; } 
        }
    }
}
