﻿using System;

namespace MantisSharp.Browser
{
  internal sealed partial class PropertiesDialog : BaseForm
  {
    #region Constructors

    public PropertiesDialog()
    {
      this.InitializeComponent();
    }

    public PropertiesDialog(object item)
      : this()
    {
      propertyGrid.SelectedObject = item;
    }

    #endregion

    #region Static Methods

    public static void ShowDialog(object item)
    {
      using (PropertiesDialog dialog = new PropertiesDialog(item))
      {
        dialog.ShowDialog();
      }
    }

    #endregion

    #region Methods

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    #endregion
  }
}