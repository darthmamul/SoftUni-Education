namespace _01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProgress iStreamProgressFile;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamProgress iStreamProgressFile)
        {
            this.iStreamProgressFile = iStreamProgressFile;
        }

        public int CalculateCurrentPercent()
        {
            return (this.iStreamProgressFile.BytesSent * 100) / this.iStreamProgressFile.Length;
        }
    }
}