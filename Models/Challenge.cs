namespace code_challenge.Models
{
    public class Challenge : IEntity
    {
        public int Id { get; set; }

        public string Output { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Degree Degree { get; set; } = Degree.Beginner;

        // https://stackoverflow.com/questions/26822277/return-html-from-asp-net-web-api
        public override string ToString()
        {
            // String.Join("<br/>", this.Output.Split("\n"));
            return $"{this.Content}\n{this.Degree.ToString()}\n{this.Output}";
        }
    }
}