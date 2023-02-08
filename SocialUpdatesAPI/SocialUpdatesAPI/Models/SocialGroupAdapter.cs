namespace SocialUpdatesAPI.Models
{
    public class SocialGroupAdapter
    {
        public static SocialGroupDTO ToDTO(SocialGroup postItem) =>
           new SocialGroupDTO
           {
               Id = postItem.Id,
               Post = postItem.Post
           };
    }
}
