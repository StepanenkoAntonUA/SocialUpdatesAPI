namespace PostsManagement.Models
{
    public class PlannedPostAdapter
    {
        public static PlannedPostDTO ToDTO(PlannedPost plannedPostItem) =>
          new PlannedPostDTO
          {
              Id = plannedPostItem.Id,
              Post = plannedPostItem.Post
          };
    }
}
