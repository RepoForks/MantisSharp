﻿using System;
using PetaJson;

// Copyright (c) 2017 Cyotek Ltd.
// http://mantissharp.net/
// Licensed under the MIT License. See LICENSE.txt for the full text.

// If you use this control in your applications, attribution, donations or contributions are welcome.

namespace MantisSharp
{
  public class Category : NamedMantisEntity, IEquatable<Category>
  {
    #region Fields

    private Reference _project;

    #endregion

    #region Properties

    [Json("project")]
    public Reference Project
    {
      get { return _project; }
      set { _project = value; }
    }

    #endregion

    #region Methods

    public override bool Equals(object obj)
    {
      return !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || obj.GetType() == this.GetType() && this.Equals((Category)obj));
    }

    public override int GetHashCode()
    {
      unchecked
      {
        int result;

        result = this.Id;
        result = (result * 397) ^ (this.Name?.GetHashCode() ?? 0);
        result = (result * 397) ^ (_project?.GetHashCode() ?? 0);

        return result;
      }
    }

    #endregion

    #region IEquatable<Category> Interface

    public bool Equals(Category other)
    {
      return !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || this.Id == other.Id && string.Equals(this.Name, other.Name) && (_project == null && other._project == null || _project != null && _project.Equals(other._project)));
    }

    #endregion
  }
}
