﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace MantisSharp
{
  public class AttachmentCollection : ICollection<Attachment>
  {
    #region Constants

    private readonly Dictionary<int, int> _indexesById;

    private readonly Dictionary<string, int> _indexesByName;

    private readonly IList<Attachment> _items;

    #endregion

    #region Constructors

    public AttachmentCollection()
    {
      _indexesByName = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
      _indexesById = new Dictionary<int, int>();
      _items = new List<Attachment>();
    }

    #endregion

    #region Properties

    public Attachment this[string key]
    {
      get
      {
        int index;

        if (!_indexesByName.TryGetValue(key, out index))
        {
          throw new KeyNotFoundException(string.Format("Cannot find key '{0}'.", key));
        }

        return _items[index];
      }
    }

    public Attachment this[int key]
    {
      get
      {
        int index;

        if (!_indexesById.TryGetValue(key, out index))
        {
          throw new KeyNotFoundException(string.Format("Cannot find key {0}.", key));
        }

        return _items[index];
      }
    }

    #endregion

    #region Methods

    public bool ContainsKey(string key)
    {
      return _indexesByName.ContainsKey(key);
    }

    public bool ContainsKey(int key)
    {
      return _indexesById.ContainsKey(key);
    }

    public bool TryGetValue(string key, out Attachment value)
    {
      int index;

      if (_indexesByName.TryGetValue(key, out index))
      {
        value = _items[index];
      }
      else
      {
        index = -1;
        value = null;
      }

      return index != -1;
    }

    public bool TryGetValue(int key, out Attachment value)
    {
      int index;

      if (_indexesById.TryGetValue(key, out index))
      {
        value = _items[index];
      }
      else
      {
        index = -1;
        value = null;
      }

      return index != -1;
    }

    internal void Add(Attachment item)
    {
      string name;
      int index;

      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }

      name = item.FileName;

#if NET35
      if (string.IsNullOrEmpty(name))
#else
      if (string.IsNullOrWhiteSpace(name))
#endif
      {
        throw new ArgumentException("Unnamed items cannot be added.", nameof(item));
      }

      if (_indexesByName.ContainsKey(name))
      {
        throw new ArgumentNullException(string.Format("An item with key '{0}' already exists.", name), nameof(item));
      }

      _items.Add(item);

      index = _items.Count - 1;

      _indexesByName.Add(name, index);
      _indexesById.Add(item.Id, index);
    }

    internal void Clear()
    {
      _indexesById.Clear();
      _indexesByName.Clear();
      _items.Clear();
    }

    internal bool Remove(Attachment item)
    {
      return this.Remove(item.FileName);
    }

    internal bool Remove(string key)
    {
      int index;

      if (_indexesByName.TryGetValue(key, out index))
      {
        _indexesByName.Remove(key);
        _items.RemoveAt(index);
      }
      else
      {
        index = -1;
      }

      return index != -1;
    }

    #endregion

    #region ICollection<Attachment> Interface

    public bool Contains(Attachment item)
    {
      return this.ContainsKey(item.Id);
    }

    public void CopyTo(Attachment[] array, int arrayIndex)
    {
      _items.CopyTo(array, arrayIndex);
    }

    public IEnumerator<Attachment> GetEnumerator()
    {
      return _items.GetEnumerator();
    }

    void ICollection<Attachment>.Add(Attachment item)
    {
      this.Add(item);
    }

    void ICollection<Attachment>.Clear()
    {
      this.Clear();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    bool ICollection<Attachment>.Remove(Attachment item)
    {
      return this.Remove(item);
    }

    public int Count
    {
      get { return _items.Count; }
    }

    bool ICollection<Attachment>.IsReadOnly
    {
      get { return false; }
    }

    #endregion
  }
}

