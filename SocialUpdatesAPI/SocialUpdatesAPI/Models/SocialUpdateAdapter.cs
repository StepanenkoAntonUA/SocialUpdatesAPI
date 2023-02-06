namespace SocialUpdatesAPI.Models
{
    public static class SocialUpdateAdapter
    {
        public static SocialUpdateDTO ToDTO(SocialUpdate postItem) =>
           new SocialUpdateDTO
           {
               Id = postItem.Id,
               Description = postItem.Description
           };
    }
}
