using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception();
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        int result;
        if (Int32.TryParse(input, out result))
        {
            return result;
        }
        return null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        if (Int32.TryParse(input, out result))
        {
            return true;
        }
        return false;
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        disposableObject.Dispose();
        throw new Exception();
    }
}
