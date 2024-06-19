namespace Muza.Synths
{
    internal class SynthAx(
        Wave? wave = null,
        WaveForm? waveForm = null,
        float frequency = 360.0f,
        float time = 0.0f,
        float duration = 1.0f,
        float amplitude = 1.0f,
        int channels = Constants.ChannelsCount,
        int frameRate = Constants.FrameRate
    )
    {
        public Wave Wave = wave is null ? new() : wave;
        public WaveForm WaveForm { get; set; } = waveForm is null ? Constants.WaveForm : waveForm;
        public float Frequency { get; set; } = frequency;
        public float Time { get; set; } = time;
        public float Duration { get; set; } = duration;
        public float Amplitude { get; set; } = amplitude;
        public int Channels { get; set; } = channels;
        public int FrameRate { get; set; } = frameRate;

        public void Write()
        {
            int start = Wave.TimeToFrame(Time);
            int end = Wave.TimeToFrame(Time + Duration);
            for (int frame = start; frame < end; frame++)
            {
                float time = Wave.FrameToTime(frame - start);
                float part = time * Frequency % 1.0f;
                float sample = WaveForm(part) * Amplitude;
                for (int channel = 0; channel < Wave.ChannelsCount; channel++)
                {
                    Wave[frame, channel] += sample;
                }
            }

        }
    }
}