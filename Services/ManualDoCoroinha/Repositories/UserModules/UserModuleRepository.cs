using AutoMapper.Configuration.Annotations;
using ManualDoCoroinha.Context;
using ManualDoCoroinha.Shared.DTOs.Quizzes;
using ManualDoCoroinha.Shared.DTOs.UserModules;
using ManualDoCoroinha.Models.UserModules;
using Microsoft.EntityFrameworkCore;

namespace ManualDoCoroinha.Repositories.UserModules;

public class UserModuleRepository : BaseRepository<UserModule>, IUserModuleRepository
{
    public UserModuleRepository(AppDbContext context) : base(context)  {}

    public async Task<bool> UpdateLastLesson(Guid userModuleId, UpdateLastLessonDto dto)
    {
        var userModule = await _context.UserModules.FindAsync(userModuleId);
        var lesson = await _context.Lessons.FindAsync(dto.LessonId);
        var countLessons = await _context.Lessons.CountAsync(l => l.ModuleId == userModule.ModuleId) + 1;

        if (userModule == null || lesson == null || countLessons == 0)
            return false;

        if (lesson.Order * 100 / (countLessons - 1) == 100)
            userModule.QuizUnlocked = true;
        else
            userModule.QuizUnlocked = false;

            userModule.LastLessonId = dto.LessonId;
        userModule.Progress = lesson.Order * 100 / countLessons;
        _context.SaveChanges();
        return true;
    }

    public async Task<UserModule> TakeTheQuiz(Guid userModuleId, QuizAnswerDto dto)
    {
        var userModule = await _context.UserModules.FindAsync(userModuleId);

        if (userModule is null)
            throw new Exception("Módulo do usuário não encontrado.");

        if (!dto.Questions.Any())
            throw new Exception("O questionário não possui perguntas.");

        var quantityQuestions = dto.Questions.Count;
        var points = dto.Questions.Count(q => q.AlternativeSelected.IsCorrect);

        var score = points * 100 / quantityQuestions;

        userModule.NumberOfTentatives++;

        if (score > userModule.QuizScore)
            userModule.QuizScore = score;

        if (score >= dto.MinScore)
        {
            userModule.QuizApproved = true;
            userModule.Completed = true;
            userModule.Progress = 100;
        }

        await _context.SaveChangesAsync();

        return userModule;
    }
}
