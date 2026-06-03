namespace DDLiquid.Domain.Models.Product
{
    public class ToggleLikeResult
    {
        public bool IsLiked { get; set; }
        public int LikeCount { get; set; }
    }

    public class ToggleFavoriteResult
    {
        public bool IsFavorited { get; set; }
    }
}
