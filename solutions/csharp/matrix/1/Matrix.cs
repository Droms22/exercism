using System;

public class Matrix
{
    int[,] matrix;
    int rsize;
    int csize;
    
    public Matrix(string input)
    {
        var lines = input.Split('\n');
        rsize = lines.Length;
        csize = lines[0].Split(' ').Length;
        
        matrix = new int[rsize,csize];
        
        for (int i = 0; i < rsize; i++)
        {
            var row = lines[i].Split(' ');
            for (int j = 0; j < csize; j++)
            {
                matrix[i,j] =  int.Parse(row[j]);
            }
        }
    }

    public int[] Row(int row)
    {
        int[] Row = new int[csize];
        for (int i = 0; i < csize; i++)
        {
            Row[i] = matrix[row-1,i];
        }
        return Row;
    }

    public int[] Column(int col)
    {
        int[] Col = new int[rsize];
        for (int i = 0; i < rsize; i++)
        {
            Col[i] = matrix[i,col-1];
        }
        return Col;
    }
}