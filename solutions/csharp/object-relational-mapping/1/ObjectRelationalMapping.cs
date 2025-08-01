using System;

public class Orm: IDisposable
{
    private Database db;

    public Orm(Database database)
    {
        this.db = database;
    }

    public void Begin()
    {
        db.BeginTransaction();
    }

    public void Write(string data)
    {
        try
        {
            db.Write(data);    
        }
        catch (InvalidOperationException e)
        {
            this.Dispose();
        }
    }

    public void Commit()
    {
        try
        {
            db.EndTransaction();
        }
        catch (InvalidOperationException e)
        {
            this.Dispose();
        }
    }

    public void Dispose() => db.Dispose();
}
