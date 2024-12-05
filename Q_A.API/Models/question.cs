namespace Q_A.API.Models
{
    public class question
    {
        public int QuestionId { get; set; }   
        public string QuestionContent { get; set; }   
        public string? QuestionAnswer { get; set; }   
        public bool IsAnswered { get; set; } = false;
		// Stores the time when the question was created
		public DateTime QuestionCreatedAt { get; set; } = DateTime.Now;

		// Stores the time when the question was answered
		public DateTime? AnswerCreatedAt { get; set; }
	}
}
