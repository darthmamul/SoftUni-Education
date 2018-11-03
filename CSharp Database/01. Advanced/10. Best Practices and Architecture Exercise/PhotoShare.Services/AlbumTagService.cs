namespace PhotoShare.Services
{
    using Models;
    using PhotoShare.Data;
    using Services.Contracts;

    public class AlbumTagService : IAlbumTagService
    {
        private readonly PhotoShareContext context;

        public AlbumTagService(PhotoShareContext context)
        {
            this.context = context;
        }

        public AlbumTag AddTagTo(int albumId, int tagId)
        {
            var albumTag = new AlbumTag
            {
                AlbumId = albumId,
                TagId = tagId
            };

            this.context.AlbumTags.Add(albumTag);

            this.context.SaveChanges();

            return albumTag;
        }
    }
}
