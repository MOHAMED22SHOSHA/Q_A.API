using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q_A.API.Data;
using Q_A.API.Models;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
	private readonly AppDbContext _db;

	public QuestionsController(AppDbContext context)
	{
		_db = context;
	}

	[HttpPost]
	public async Task<IActionResult> PostQuestion([FromBody] question question)
	{
		// Ensure that the creation date is set
		question.QuestionCreatedAt = DateTime.Now;

		// Add the new question to the database
		_db.question.Add(question);
		await _db.SaveChangesAsync();
		return Ok(question);
	}

	[HttpGet]
	public async Task<IActionResult> GetAnsweredQuestions()
	{
		var answeredQuestions = await _db.question
			.Where(q => q.IsAnswered)
			.Select(q => new
			{
				q.QuestionId,
				q.QuestionContent,
				q.QuestionAnswer,
				// Format QuestionCreatedAt as a string
				QuestionCreatedAt = q.QuestionCreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
				// Safely handle nullable AnswerCreatedAt
				AnswerCreatedAt = q.AnswerCreatedAt.HasValue
					? q.AnswerCreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss")
					: "Not Available"
			})
			.ToListAsync();

		return Ok(answeredQuestions);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> AnswerQuestion(int id, [FromBody] string answer)
	{
		var question = await _db.question.FindAsync(id);
		if (question == null) return NotFound();

		// Set the answer and the answered flag
		question.QuestionAnswer = answer;
		question.IsAnswered = true;
		question.AnswerCreatedAt = DateTime.Now;  // Set AnswerCreatedAt to current time

		await _db.SaveChangesAsync();
		return Ok(question);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteQuestion(int id)
	{
		var question = await _db.question.FindAsync(id);
		if (question == null)
		{
			return NotFound();
		}

		// Remove the question from the database
		_db.question.Remove(question);
		await _db.SaveChangesAsync();

		return NoContent();
	}
}
