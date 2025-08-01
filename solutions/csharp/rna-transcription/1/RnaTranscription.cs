using System;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        string rna = "";
        foreach (char c in nucleotide) {
            switch (c) {
                case 'A':
                    rna += 'U';
                    break;
                case 'T':
                    rna += 'A';
                    break;
                case 'G':
                    rna += 'C';
                    break;
                case 'C':
                    rna += 'G';
                    break;
            }
        } 
        return rna;
    }
}