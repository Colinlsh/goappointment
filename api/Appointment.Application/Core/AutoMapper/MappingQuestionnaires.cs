using Appointment.Application.Questionnaire;
using Appointment.Domain.Tenant;
using AutoMapper;

namespace Appointment.Application.Core.AutoMapper
{
    public class MappingQuestionnaires : ProfileBase
    {
        protected override void MapDataTransferObjectToDomain()
        {
        }

        protected override void MapDomainToDataTransferObject()
        {
            CreateMap<Question, QuestionDto>()
                .ForMember(d => d.Question, o => o.MapFrom(s => s.DisplayValue))
                .ForMember(d => d.QuestionId, o => o.MapFrom(s => s.QuestionId));
            CreateMap<QuestionAnswer, AnswerDto>()
                .ForMember(d => d.Answer, o => o.MapFrom(s => s.Answer.DisplayValue))
                .ForMember(d => d.AnswerId, o => o.MapFrom(s => s.AnswerFk));
            CreateMap<AppUserQuestionAnswer, QuestionAnswerDto>()
                .ForMember(d => d.Answer, o => o.MapFrom(s => s.Answer.DisplayValue))
                .ForMember(d => d.AnswerId, o => o.MapFrom(s => s.AnswerFK))
                .ForMember(d => d.Question, o => o.MapFrom(s => s.Question.DisplayValue))
                .ForMember(d => d.QuestionId, o => o.MapFrom(s => s.Question.QuestionId));
        }
    }
}
