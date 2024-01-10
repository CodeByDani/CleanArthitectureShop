namespace Common.Helper;

public static class ObjectExtensions
{
    public static void ThrowIfNotNull<TException>(this object obj) where TException : Exception, new()
    {
        if (obj != null)
        {
            throw new TException();
        }
    }
    public static void ThrowIfNull<TException>(this object obj) where TException : Exception, new()
    {
        if (obj == null)
        {
            throw new TException();
        }
    }
}