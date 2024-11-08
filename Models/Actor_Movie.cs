namespace eApplication.Models
{
    public class Actor_Movie
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; } //Navigation Property

        public int ActorId { get; set; }
        public Actor Actor { get; set; } //Navigation Property

    }
}
