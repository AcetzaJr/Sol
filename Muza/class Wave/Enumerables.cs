namespace Muza
{
    internal partial class Wave
    {
        public IEnumerable<int> Frames
        {
            get
            {
                for (int frame = 0; frame < FramesCount; frame++)
                {
                    yield return frame;
                }
                yield break;
            }
        }
        public IEnumerable<int> Channels
        {
            get
            {
                for (int channel = 0; channel < ChannelsCount; channel++)
                {
                    yield return channel;
                }
                yield break;
            }
        }
        public IEnumerable<int> Samples
        {
            get
            {
                for (int sample = 0; sample < SamplesCount; sample++)
                {
                    yield return sample;
                }
                yield break;
            }
        }
    }
}