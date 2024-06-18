namespace Muza.Synths
{
    internal class SynthAx(
    WaveForm? waveForm = null,
    float frequency = 360.0f,
    float time = 0.0f,
    float duration = 1.0f,
    float amplitude = 1.0f,
    int channels = Constants.ChannelsCount,
    int frameRate = Constants.FrameRate
)
    {
        public WaveForm WaveForm { get; set; } = waveForm is null ? Constants.WaveForm : waveForm;
        public float Frequency { get; set; } = frequency;
        public float Time { get; set; } = time;
        public float Duration { get; set; } = duration;
        public float Amplitude { get; set; } = amplitude;
        public int Channels { get; set; } = channels;
        public int FrameRate { get; set; } = frameRate;

        public void Wave(Wave wave)
        {
            int start = wave.TimeToFrame(Time);
            int end = wave.TimeToFrame(Time + Duration);
            for (int frame = start; frame < end; frame++)
            {
                float time = wave.FrameToTime(frame - start);
                float part = time * Frequency % 1.0f;
                float sample = WaveForm(part) * Amplitude;
                for (int channel = 0; channel < wave.ChannelsCount; channel++)
                {
                    wave[frame, channel] += sample;
                }
            }

        }
    }
}