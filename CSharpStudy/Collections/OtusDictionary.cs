namespace Collections;

public class OtusDictionary
{
    private int[] _keys;
    private string[] _values;
    private int _count;
    private int _size = 8;

    public OtusDictionary()
    {
        _keys = new int [ _size ];
        _values = new string[ _size ];
        _count = 0;
    }
    
    public void Add(int key, string value)
    {
        switch (value)
        {
            case null:
                throw new ArgumentNullException(nameof(value), "Value cannot be null.");
            case "":
                throw new ArgumentException("Value cannot be empty.", nameof(value));
            default:
            {
                if (Array.Exists(_values, val => val == value))
                {
                    throw new ArgumentException($"Value {value} already exists in dictionary.");
                }
                break;
            }
        }

        if (_count == _size)
        {
            Resize();
        }
        
        int index = key % _size;

        while (_values[index] != null)
        {
            if (_count == _size)
            {
                throw new ArgumentException($"Key {key} already exists.");
            }
            index = (index + 1) % _size;
        }
        _keys[index] = key;
        _values[index] = value;
        _count++;
    }
    
    
    public string Get(int key)
    {
        int index = key % _size;

        while (_values[index] != null)
        {
            if(_keys[index] == key)
                return _values[index];
            index = (index + 1) % _size;
        }
        Console.WriteLine($"Error. Value with key \"{key}\" does not exist.");
        return null!;
    }

    
    public string this[int key]
    {
        get => Get(key);
        set => Add(key, value);
    }
    
    
    private void Resize()
    {
        _size = Math.Min( _size * 2, _count * 2 );
        int[] previousKeys = _keys;
        string[] previousValues = _values;
        
        _keys = new int[ _size ];
        _values = new string[ _size ];
        _count = 0;

        for (int i = 0; i < previousKeys.Length; i++)
        {
            if (previousValues[i] != null)
            {
                Add(previousKeys[i], previousValues[i]);
            }
        }
    }
}
