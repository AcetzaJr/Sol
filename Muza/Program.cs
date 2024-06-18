using Muza;
using Muza.Synths;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Hello, World!");
        Wave wave = new();
        SynthAx synth = new();
        synth.Wave(wave);
    }
}