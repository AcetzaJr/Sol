namespace Muza
{
    internal partial class Wave(int channels = Constants.ChannelsCount, int frameRate = Constants.FrameRate)
    {
        public int SamplesCount => samples.Count;
        public int ChannelsCount { get; } = channels;
        public int FrameRate { get; } = frameRate;
        public int FramesCount => samples.Count / ChannelsCount;

        public float this[int index]
        {
            get => index >= SamplesCount ? 0.0f : samples[index];
            set { EnsureSize(index + 1); samples[index] = value; }
        }

        public float this[int frame, int channel]
        {
            get => this[Index(frame, channel)];
            set => this[Index(frame, channel)] = value;
        }
        public float FrameToTime(int frame)
        {
            return (float)frame / FrameRate;
        }
        public int TimeToFrame(float time)
        {
            return (int)(time * FrameRate);
        }

        private void EnsureSize(int size)
        {
            while (SamplesCount < size)
            {
                for (int channel = 0; channel < ChannelsCount; channel++)
                {
                    samples.Add(0.0f);
                }
            }
        }
        private int Index(int frame, int channel) { return frame * ChannelsCount + channel; }
        private readonly List<float> samples = [];
    }
}