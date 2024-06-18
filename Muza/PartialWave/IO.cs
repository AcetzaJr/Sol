using NAudio.Wave;

namespace Muza
{
    internal partial class Wave
    {
        private WaveFormat WaveFormat { get; } = WaveFormat.CreateIeeeFloatWaveFormat(frameRate, channels);
        public Wave Save(string path = "out/wave")
        {
            using WaveFileWriter waveFileWriter = new($"{path}.wav", WaveFormat);
            foreach (int sample in Samples)
            {
                waveFileWriter.WriteSample(this[sample]);
            }
            return this;
        }
    }
}