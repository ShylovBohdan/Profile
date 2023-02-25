using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Thesis
{
    public abstract class EmptyDataException : Exception
    {
        public abstract void ShowMessageBox();
    }
    public class EmptySearchDataException : EmptyDataException
    {
        public EmptySearchDataException() : base() { }
        public override void ShowMessageBox()
        {
            MessageBox.Show("Data is empty", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class IncorrectRegisterDataException : EmptyDataException
    {
        public IncorrectRegisterDataException() : base() { }
        public override void ShowMessageBox()
        {
            MessageBox.Show("Incorrect register data", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class IncorrectWriteOffDataException : EmptyDataException
    {
        public IncorrectWriteOffDataException() : base() { }
        public override void ShowMessageBox()
        {
            MessageBox.Show("Incorrect write off data", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class IncorrectSearchDataException : EmptyDataException
    {
        public IncorrectSearchDataException() : base() { }
        public override void ShowMessageBox()
        {
            MessageBox.Show("Incorrect search data", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class IncorrectFilterDataException : EmptyDataException
    {
        public IncorrectFilterDataException() : base() { }
        public override void ShowMessageBox()
        {
            MessageBox.Show("Incorrect filter data", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class IncorrectSellDataException : EmptyDataException
    {
        public IncorrectSellDataException() : base() { }
        public override void ShowMessageBox()
        {
            MessageBox.Show("Incorrect sell data", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class EmptyProductsException : EmptyDataException
    {
        public EmptyProductsException() : base() { }
        public override void ShowMessageBox()
        {
            MessageBox.Show("No one product is here", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class IncorrectDataException : Exception
    {
        public void ShowMessageBox()
        {
            MessageBox.Show("Incorrect data in file", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class NotEnoughAmount : Exception
    {
        public void ShowMessageBox()
        {
            MessageBox.Show("Not enough amount", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
