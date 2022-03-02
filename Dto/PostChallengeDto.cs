namespace code_challenge.Dto
{
    public class PostChallengeDto
    {
        public string Output { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Degree Degree { get; set; } = Degree.Beginner;
    }
}