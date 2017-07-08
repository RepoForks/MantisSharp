﻿using PetaJson;

namespace MantisSharp
{
  public class IssueStatus : LocalizedMantisReference
  {
    #region Fields

    private string _color;

    #endregion

    #region Properties

    [Json("color")]
    public string Color
    {
      get { return _color; }
      internal set { _color = value; }
    }

    #endregion
  }
}
