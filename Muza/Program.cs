using Muza;
using Muza.Synths;

internal class Program
{
    private static void Main()
    {
        for (int note = -30; note <= 30; note++)
        {
            Console.WriteLine($"note {note} = {Acetza.Power(note)}");
        }
    }
    public static void Fn()
    {
        Wave wave = new();
        SynthAx synth = new(wave);
        synth.Write();
        wave.Save();
    }
}