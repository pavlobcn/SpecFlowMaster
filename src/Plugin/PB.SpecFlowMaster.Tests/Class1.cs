using System;

public class A
{
    public void Meth1()
    {

    }

    public void MethB(Action a)
    {
        a();
    }

    public void MethodMain()
    {
        MethB(Meth1);
    }
}
